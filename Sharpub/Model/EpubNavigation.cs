using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace Sharpub.Model
{
    [XmlRoot("html", Namespace = "http://www.w3.org/1999/xhtml")]
    public class NavigationRoot
    {
        [XmlElement("head")]
        public Head Head { get; set; } = new Head();

        [XmlElement("body")]
        public Body Body { get; set; } = new Body();

        public NavigationRoot() { }

        public NavigationRoot(string title, EpubNavigation epubNavigation)
        {
            Head.Title = title;
            Body.Navigation = epubNavigation;
        }
    }

    public class Head
    {
        [XmlElement("title")]
        public string Title { get; set; }
    }

    public class Body
    {
        [XmlElement("nav")]
        public EpubNavigation Navigation { get; set; }
    }

    public class EpubNavigation
    {
        [XmlElement("h1")]
        public Heading Heading { get; set; }

        [XmlElement("ol")]
        public OrderedList OrderedList { get; set; } = new OrderedList();

        [XmlAttribute("type", Namespace = "http://www.idpf.org/2007/ops")]
        public string Type { get; set; }

        public EpubNavigation() { }
    }

    public class OrderedList
    {
        [XmlElement("li")]
        public List<ListItem> ListItems { get; set; }
    }

    public class ListItem
    {
        [XmlElement("a")]
        public Anchor Anchor { get; set; }

        [Obsolete(
            "This parameterless constructor is reserved for XmlSerializer. Use the other constructor instead."
        )]
        public ListItem() { }

        public ListItem(string title, string href)
        {
            Anchor = new Anchor { Content = title, Href = href };
        }
    }
}
