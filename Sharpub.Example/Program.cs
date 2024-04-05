using Sharpub.Model;
using System.Xml.Serialization;

namespace Sharpub.Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var meta = new EpubMetadata(
                new EpubTitle("My ePub book"),
                new List<EpubIdentifier>
                {
                    new EpubIdentifier("bookId", "urn:uuid:12345678-1234-567812345678")
                },
                new List<EpubLanguage> { new EpubLanguage("en-US") }
            );
            Console.WriteLine(meta.Title.Content);
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("dc", "http://purl.org/dc/elements/1.1/");
            var serializer = new XmlSerializer(typeof(EpubMetadata));
            using var xmlWriter = new StringWriter();
            serializer.Serialize(xmlWriter, meta, namespaces);
            Console.WriteLine(xmlWriter.ToString());
        }
    }
}
