using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Sharpub.Model
{
    [XmlRoot("package", Namespace = "http://www.idpf.org/2007/opf")]
    public class EpubPackage
    {
        [XmlAttribute("dir")]
        public XMLDir Direction { get; set; }
        [XmlAttribute("version")]
        public string Version { get; set; } = "3.0";
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlAttribute("prefix")]
        public string Prefix { get; set; }
        [XmlAttribute("unique-identifier")]
        public string UniqueIdentifier
        {
            get
            {
                if (Metadata.Identifiers.Count < 1)
                    throw new Exception("No identifier found in metadata");
                return Metadata.Identifiers[0].Id;
            }
            set
            {
                if (Metadata.Identifiers.Count < 1)
                    throw new Exception("No identifier found in metadata");
                Metadata.Identifiers[0].Id = value;
            }
        }
        [XmlAttribute("xml:lang")]
        public string Language { get; set; }

        [XmlElement("metadata")]
        public EpubMetadata Metadata { get; set; }
        [XmlElement("manifest")]
        public EpubManifest Manifest { get; set; }
        [XmlElement("spine")]
        public EpubSpine Spine { get; set; }
    }
}
