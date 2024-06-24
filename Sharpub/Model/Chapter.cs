using Sharpub.Model.Section;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

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

        public void AddSection(ISection section)
        {
            Sections.Add(section);
        }

        public async Task<string> GenerateContentAsync(
            ZipArchive epubArchive,
            EpubManifest epubManifest,
            EpubSpine epubSpine
        )
        {
            var builder = new StringBuilder();
            foreach (var section in Sections)
            {
                builder.AppendLine(
                    await section.ToXHTMLStringAsync(epubArchive, epubManifest, epubSpine)
                );
            }
            var content = builder.ToString();
            return string.Format(Constants.Constants.ChapterTemplate, Title, content);
        }
    }
}
