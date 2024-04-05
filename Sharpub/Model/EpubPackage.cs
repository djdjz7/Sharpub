﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Sharpub.Model
{
    public class EpubPackage
    {
        [XmlElement("metadata")]
        public EpubMetadata Metadata { get; set; }
        [XmlElement("manifest")]
        public EpubManifest Manifest { get; set; }

        public EpubPackage()
        {

        }
    }
}