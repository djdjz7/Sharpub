using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Sharpub.Model;
using Sharpub.Utils;

namespace Sharpub
{
    public class EpubBook
    {
        public List<Chapter> Chapters { get; set; } = new List<Chapter>();
        public EpubMetadata Metadata { get; }
        private XmlSerializer _packageSerializer = new XmlSerializer(typeof(EpubPackage));
        private XmlSerializer _tocSerializer = new XmlSerializer(typeof(NavigationRoot));

        public EpubBook(EpubMetadata metadata)
        {
            Metadata = metadata;
        }

        public async Task ExportAsync(string epubFilePath, EpubGenerationOptions options = null)
        {
            if (Chapters.Count == 0)
                throw new Exception("Book is empty.");
            using (var fileStream = new FileStream(epubFilePath, FileMode.Create))
            {
                using (var zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create))
                {
                    await zipArchive.AddEntryAsync(
                        "mimetype",
                        "application/epub+zip",
                        CompressionLevel.NoCompression
                    );
                    await zipArchive.AddEntryAsync(
                        "META-INF/container.xml",
                        Constants.Constants.ContainerContent
                    );

                    // TODO: Generate TOC

                    // Copy the metas so we can recover them later to remove the modified date
                    var originalMetas = Metadata.Metas.ToList();

                    Metadata.Metas.Add(
                        new Meta(
                            "dcterms:modified",
                            DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
                        )
                    );

                    var manifest = new EpubManifest();
                    var spine = new EpubSpine();
                    var toc = new EpubNavigation() { Type = "toc" };
                    toc.OrderedList.ListItems = new List<ListItem>(Chapters.Count);
                    manifest.Items.Add(
                        new ManifestItem("toc", "toc.xhtml", "application/xhtml+xml")
                        {
                            Properties = "nav"
                        }
                    );
                    spine.ItemRefs.Add(new SpineItemRef("toc"));

                    var css = options?.CustomCSS ?? "";
                    await zipArchive.AddEntryAsync("OEBPS/Styles/style.css", css);
                    manifest.Items.Add(new ManifestItem("css", "Styles/style.css", "text/css"));

                    for (int i = 0; i < Chapters.Count; i++)
                    {
                        var chapter = Chapters[i];
                        var chapterFile = await chapter.GenerateContentAsync(
                            zipArchive,
                            manifest,
                            spine
                        );
                        await zipArchive.AddEntryAsync(
                            $"OEBPS/Text/chapter_{i}.xhtml",
                            chapterFile
                        );
                        manifest.Items.Add(
                            new ManifestItem(
                                $"chapter_{i}",
                                $"Text/chapter_{i}.xhtml",
                                "application/xhtml+xml"
                            )
                        );
                        spine.ItemRefs.Add(new SpineItemRef($"chapter_{i}"));
                        toc.OrderedList.ListItems.Add(
                            new ListItem(chapter.Title, $"Text/chapter_{i}.xhtml")
                        );
                    }
                    var package = new EpubPackage
                    {
                        Metadata = Metadata,
                        Manifest = manifest,
                        Spine = spine
                    };
                    var navigation = new NavigationRoot(Metadata.Title.Content, toc);

                    var packageNamespaces = new XmlSerializerNamespaces();
                    packageNamespaces.Add("dc", "http://purl.org/dc/elements/1.1/");
                    using (var stream = new MemoryStream())
                    {
                        using (
                            var textWriter = XmlWriter.Create(
                                stream,
                                new XmlWriterSettings { Encoding = System.Text.Encoding.UTF8 }
                            )
                        )
                        {
                            _packageSerializer.Serialize(textWriter, package, packageNamespaces);
                            var packageXml = stream.ToArray();

                            await zipArchive.AddEntryAsync("OEBPS/package.opf", packageXml);
                        }
                    }

                    var tocNamespaces = new XmlSerializerNamespaces();
                    packageNamespaces.Add("epub", "http://www.idpf.org/2007/ops");
                    using (var stream = new MemoryStream())
                    {
                        using (
                            var textWriter = XmlWriter.Create(
                                stream,
                                new XmlWriterSettings { Encoding = System.Text.Encoding.UTF8 }
                            )
                        )
                        {
                            _tocSerializer.Serialize(textWriter, navigation, packageNamespaces);
                            var tocXml = stream.ToArray();
                            await zipArchive.AddEntryAsync("OEBPS/toc.xhtml", tocXml);
                        }
                    }

                    Metadata.Metas = originalMetas;
                }
            }
        }

        public void AddChapter(Chapter chapter)
        {
            Chapters.Add(chapter);
        }
    }
}
