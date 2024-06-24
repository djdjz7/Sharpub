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
        public List<Meta> Metas { get; set; } = new List<Meta>();

        /// <summary>
        /// link
        /// </summary>
        [XmlElement(ElementName = "link")]
        public List<MetadataLink> Links { get; set; }

        [XmlElement(ElementName = "contributor")]
        public List<Contributor> Contributors { get; set; }

        [XmlElement(ElementName = "coverage")]
        public List<Coverage> Coverages { get; set; }

        [XmlElement(ElementName = "creator")]
        public List<Creator> Creators { get; set; }

        [XmlElement(ElementName = "date")]
        public List<Date> Dates { get; set; }

        [XmlElement(ElementName = "description")]
        public List<Description> Descriptions { get; set; }

        [XmlElement(ElementName = "format")]
        public List<Format> Formats { get; set; }

        [XmlElement(ElementName = "publisher")]
        public List<Publisher> Publishers { get; set; }

        [XmlElement(ElementName = "relation")]
        public List<Relation> Relations { get; set; }

        [XmlElement(ElementName = "rights")]
        public List<Rights> RightsList { get; set; }

        [XmlElement(ElementName = "source")]
        public List<Source> Sources { get; set; }

        [XmlElement(ElementName = "subject")]
        public List<Subject> Subjects { get; set; }

        [XmlElement(ElementName = "type")]
        public List<Type> Types { get; set; }

        public EpubMetadata(
            EpubTitle title,
            List<EpubIdentifier> identifiers,
            List<EpubLanguage> languages
        )
        {
            Title = title;
            Identifiers = identifiers;
            Languages = languages;
        }

        public EpubMetadata(string title, string language)
        {
            Title = new EpubTitle(title);
            Languages = new List<EpubLanguage> { new EpubLanguage(language) };
            Identifiers = new List<EpubIdentifier> { new EpubIdentifier() };
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public EpubMetadata() { }
    }

    public class EpubIdentifier : XMLElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EpubIdentifier"/> class, specifying the identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="content"></param>
        public EpubIdentifier(string id, string content)
        {
            Id = id;
            Content = content;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EpubIdentifier"/> class. Automatically generates an identifier.
        /// </summary>
        public EpubIdentifier()
        {
            Id = "bookID";
            Content = $"urn:uuid:{Guid.NewGuid()}";
        }
    }

    public class EpubTitle : XMLElement
    {
        public EpubTitle(string title)
        {
            Content = title;
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public EpubTitle() { }
    }

    public class EpubLanguage : XMLElement
    {
        public EpubLanguage(string language)
        {
            Content = language;
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public EpubLanguage() { }
    }

    public class Meta : XMLElementExt
    {
        [XmlAttribute(AttributeName = "property")]
        public string Property { get; set; }

        [XmlAttribute(AttributeName = "refines")]
        public string Refines { get; set; }

        [XmlAttribute(AttributeName = "scheme")]
        public string Scheme { get; set; }

        public Meta(string property, string content)
        {
            Property = property;
            Content = content;
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public Meta() { }
    }

    public class MetadataLink
    {
        [XmlAttribute(AttributeName = "rel")]
        public string Rel { get; set; }

        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }

        [XmlAttribute(AttributeName = "hreflang")]
        public string HrefLang { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "media-type")]
        public string MediaType { get; set; }

        [XmlAttribute(AttributeName = "properties")]
        public string Properties { get; set; }

        [XmlAttribute(AttributeName = "refines")]
        public string Refines { get; set; }

        public MetadataLink(string rel, string href)
        {
            Rel = rel;
            Href = href;
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public MetadataLink() { }
    }

    public class Contributor : XMLElementExt
    {
        public Contributor(string name)
        {
            Content = name;
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public Contributor() { }
    }

    public class Coverage : XMLElementExt
    {
        public Coverage(string coverage)
        {
            Content = coverage;
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public Coverage() { }
    }

    public class Creator : XMLElementExt
    {
        public Creator(string name)
        {
            Content = name;
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public Creator() { }
    }

    public class Date
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlIgnore]
        public DateTime DateValue { get; set; }

        [XmlText]
        public string Content
        {
            get => DateValue.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
            set => DateValue = DateTime.Parse(value);
        }

        public Date(DateTime date)
        {
            DateValue = date;
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public Date() { }
    }

    public class Description : XMLElementExt
    {
        public Description(string description)
        {
            Content = description;
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public Description() { }
    }

    public class Format : XMLElement
    {
        public Format(string format)
        {
            Content = format;
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public Format() { }
    }

    public class Publisher : XMLElementExt
    {
        public Publisher(string name)
        {
            Content = name;
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public Publisher() { }
    }

    public class Relation : XMLElementExt
    {
        public Relation(string relation)
        {
            Content = relation;
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public Relation() { }
    }

    public class Rights : XMLElementExt
    {
        public Rights(string rights)
        {
            Content = rights;
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public Rights() { }
    }

    public class Source : XMLElement
    {
        public Source(string source)
        {
            Content = source;
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public Source() { }
    }

    public class Subject : XMLElementExt
    {
        public Subject(string subject)
        {
            Content = subject;
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public Subject() { }
    }

    public class Type : XMLElement
    {
        public Type(string type)
        {
            Content = type;
        }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public Type() { }
    }
}
