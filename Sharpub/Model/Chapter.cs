using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Sharpub.Model.Section;

namespace Sharpub.Model
{
    public class Chapter
    {
        public string Title { get; set; }
        public List<ISection> Sections { get; set; }
        public Chapter(string title, List<ISection> sections)
        {
            Title = title;
            Sections = sections;
        }
        public async Task<string> AddToEpub(ZipArchive epubArchive, EpubManifest epubManifest, EpubSpine epubSpine)
        {
            var builder = new StringBuilder();
            foreach (var section in Sections)
            {
                builder.AppendLine(await section.ToXHTMLStringAsync(epubArchive, epubManifest, epubSpine));
            }
            return builder.ToString();
        }
    }
}
