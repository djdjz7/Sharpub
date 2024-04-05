using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Sharpub.Model
{
    public class EpubManifest
    {
        [XmlElement("item")]
        public List<ManifestItem> Items { get; set; }
        [XmlAttribute("id")]
        public string Id { get; set; }
    }

    public class ManifestItem
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlAttribute("href")]
        public string Href { get; set; }
        [XmlAttribute("media-type")]
        public string MediaType { get; set; }
        [XmlAttribute("fallback")]
        public string Fallback { get; set; }
        [XmlAttribute("media-overlay")]
        public string MediaOverlay { get; set; }
        [XmlAttribute("properties")]
        public string Properties { get; set; }

        public ManifestItem(string id, string href, string mediaType)
        {
            Id = id;
            Href = href;
            MediaType = mediaType;
        }
        [Obsolete("This parameterless constructor is preserved for XmlSerializer. Use the other constructor instead.")]
        public ManifestItem()
        {

        }
    }
}
