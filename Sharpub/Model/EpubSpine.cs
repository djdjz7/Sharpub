using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Sharpub.Model
{
    public class EpubSpine
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("page-progression-direction")]
        public XMLDir PageProgressionDirection { get; set; }

        [XmlElement("itemref")]
        public List<SpineItemRef> ItemRefs { get; set; } = new List<SpineItemRef>();
    }

    public class SpineItemRef
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("idref")]
        public string IdRef { get; set; }

        [XmlAttribute("linear")]
        public string Linear { get; set; }

        [XmlAttribute("properties")]
        public string Properties { get; set; }

        public SpineItemRef(string idRef)
        {
            IdRef = idRef;
        }

        public SpineItemRef(string idRef, bool isLinear)
        {
            IdRef = idRef;
            Linear = isLinear ? "yes" : "no";
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public SpineItemRef() { }
    }
}
