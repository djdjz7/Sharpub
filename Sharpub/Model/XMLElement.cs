using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Sharpub.Model
{
    public enum XMLDir
    {
        [XmlEnum("ltr")]
        LTR,

        [XmlEnum("rtl")]
        RTL,

        [XmlEnum("auto")]
        Auto,
    }

    public class XMLElement
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlText]
        public string Content { get; set; }
    }

    public class XMLElement<T>
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        public T Content { get; set; }
    }

    public class XMLElementExt : XMLElement
    {
        [XmlAttribute("dir")]
        public XMLDir Dir { get; set; }

        /// <summary>
        /// xml:lang
        /// </summary>
        [XmlAttribute("xml:lang")]
        public string Lang { get; set; }
    }

    public class XMLElementExt<T> : XMLElement<T>
    {
        [XmlAttribute("dir")]
        public XMLDir Dir { get; set; }

        /// <summary>
        /// xml:lang
        /// </summary>
        [XmlAttribute("xml:lang")]
        public string Lang { get; set; }
    }
}
