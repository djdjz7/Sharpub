using Sharpub.Model;
using Sharpub.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Sharpub
{
    public class EpubBook
    {
        public List<Chapter> Chapters { get; set; } = new List<Chapter>();
        public EpubMetadata Metadata { get; }
        private XmlSerializer _packageSerializer = new XmlSerializer(typeof(EpubPackage));

        public EpubBook(EpubMetadata metadata)
        {
            Metadata = metadata;
        }

        public async Task ExportAsync(string epubFilePath)
        {
            if (Chapters.Count == 0)
                throw new Exception("Book is empty.");
            using (var fileStream = new FileStream(epubFilePath, FileMode.Create))
            {
                using (var zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create))
                {
                    await zipArchive.AddEntryAsync("mimetype", "application/epub+zip", CompressionLevel.NoCompression);
                    await zipArchive.AddEntryAsync("META-INF/container.xml", Constants.Constants.ContainerContent);

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
                    for (int i = 0; i < Chapters.Count; i++)
                    {
                        var Chapter = Chapters[i];
                        var chapterFile = await Chapter.GenerateContentAsync(
                            zipArchive,
                            manifest,
                            spine
                        );
                        await zipArchive.AddEntryAsync($"OEBPS/chapter_{i}.xhtml", chapterFile);
                        manifest.Items.Add(
                            new ManifestItem(
                                $"chapter_{i}",
                                $"chapter_{i}.xhtml",
                                "application/xhtml+xml"
                            )
                        );
                        spine.ItemRefs.Add(new SpineItemRef($"chapter_{i}"));
                    }
                    var package = new EpubPackage
                    {
                        Metadata = Metadata,
                        Manifest = manifest,
                        Spine = spine
                    };

                    var namespaces = new XmlSerializerNamespaces();
                    namespaces.Add("dc", "http://purl.org/dc/elements/1.1/");
                    using (var stream = new MemoryStream())
                    {
                        using (
                            var textWriter = XmlWriter.Create(
                                stream,
                                new XmlWriterSettings { Encoding = System.Text.Encoding.UTF8 }
                            )
                        )
                        {
                            _packageSerializer.Serialize(textWriter, package, namespaces);
                            var packageXml = stream.ToArray();

                            await zipArchive.AddEntryAsync("OEBPS/package.opf", packageXml);
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
