using Sharpub.Model;
using Sharpub.Model.Section;
using System.Xml.Serialization;

namespace Sharpub.Example
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var meta = new EpubMetadata("My ePub book", "en-US");
            //var package = new EpubPackage { Metadata = meta };
            //Console.WriteLine(meta.Title.Content);
            //var namespaces = new XmlSerializerNamespaces();
            //namespaces.Add("dc", "http://purl.org/dc/elements/1.1/");
            //var serializer = new XmlSerializer(typeof(EpubPackage));
            //using var xmlWriter = new StringWriter();
            //serializer.Serialize(xmlWriter, package, namespaces);
            //Console.WriteLine(xmlWriter.ToString());
            var book = new EpubBook(meta);
            book.AddChapter(new Chapter("Introduction", new List<ISection>()));
            await book.ExportAsync("1.zip");
            await book.ExportAsync("1.zip");
        }
    }
}
