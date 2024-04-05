using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Sharpub.Model
{

    public class XHTMLElement
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlText]
        public string Content { get; set; }
    }
    public class XHTMLElement<T>
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        public T Content { get; set; }
    }
    public class XHTMLElementExt : XHTMLElement
    {
        [XmlAttribute("dir")]
        public string Dir { get; set; }
        /// <summary>
        /// xml:lang
        /// </summary>
        [XmlAttribute("xml:lang")]
        public string Lang { get; set; }
    }
    public class XHTMLElementExt<T> : XHTMLElement<T>
    {
        [XmlAttribute("dir")]
        public string Dir { get; set; }
        /// <summary>
        /// xml:lang
        /// </summary>
        [XmlAttribute("xml:lang")]
        public string Lang { get; set; }
    }
}
