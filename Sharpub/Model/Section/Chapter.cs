using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sharpub.Model.Section
{
    public class Chapter : ISection
    {
        public List<ISection> SubSections { get; set; }
        public Chapter(List<ISection> sections)
        {
            SubSections = sections;
        }
        public Task<string> ToXHTMLStringAsync(ZipArchive epubArchive)
        {
            return new Task<string>(() =>
            {
                var builder = new StringBuilder();
                foreach (var section in SubSections)
                {
                    builder.AppendLine(section.ToString());
                }
                return builder.ToString();
            });
        }
    }
}
