using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Sharpub.Model
{
    public class EpubMetadata
    {
        /// <summary>
        /// dc:title
        /// </summary>
        [XmlElement(ElementName = "title", Namespace = "http://purl.org/dc/elements/1.1/")]
        public EpubTitle Title { get; set; }
        /// <summary>
        /// dc:identifier
        /// </summary>
        [XmlElement(ElementName = "identifier", Namespace = "http://purl.org/dc/elements/1.1/")]
        public List<EpubIdentifier> Identifiers { get; }
        /// <summary>
        /// dc:language
        /// </summary>
        [XmlElement(ElementName = "language", Namespace = "http://purl.org/dc/elements/1.1/")]
        public List<EpubLanguage> Languages { get; }
        /// <summary>
        /// meta
        /// </summary>
        [XmlElement(ElementName = "meta")]
        public List<Meta> Metas { get; set; }

        public EpubMetadata(EpubTitle title, List<EpubIdentifier> identifiers, List<EpubLanguage> languages)
        {
            Title = title;
            Identifiers = identifiers;
            Languages = languages;
        }

        [Obsolete("This parameterless constructor is preserved for XmlSerializer. Use the other constructor instead.")]
        public EpubMetadata()
        {

        }
    }

    public class EpubIdentifier : XHTMLElement
    {
        public EpubIdentifier(string id, string content)
        {
            Id = id;
            Content = content;
        }
        [Obsolete("This parameterless constructor is preserved for XmlSerializer. Use the other constructor instead.")]
        public EpubIdentifier()
        {

        }
    }

    public class EpubTitle : XHTMLElement
    {
        public EpubTitle(string title)
        {
            Content = title;
        }
        [Obsolete("This parameterless constructor is preserved for XmlSerializer. Use the other constructor instead.")]
        public EpubTitle()
        {

        }
    }

    public class EpubLanguage : XHTMLElement
    {
        public EpubLanguage(string language)
        {
            Content = language;
        }
        [Obsolete("This parameterless constructor is preserved for XmlSerializer. Use the other constructor instead.")]
        public EpubLanguage()
        {

        }
    }

    public class Meta : XHTMLElementExt
    {
        [XmlAttribute(AttributeName = "property")]
        public string Property { get; }
        [XmlAttribute(AttributeName = "refines")]
        public string Refines { get; set; }
        [XmlAttribute(AttributeName = "scheme")]
        public string Scheme { get; set; }
        public Meta(string property, string content)
        {
            Property = property;
            Content = content;
        }
        [Obsolete("This parameterless constructor is preserved for XmlSerializer. Use the other constructor instead.")]
        public Meta()
        {

        }
    }
}
