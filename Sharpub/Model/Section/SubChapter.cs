using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sharpub.Model.Section
{
    public class SubChapter : ISection
    {
        public string Title { get; set; }
        public string TextContent { get; set; }
        public List<SubChapter> SubChapters { get; set; }

        public string ToString(int depth)
        {
            depth = depth <= 6 ? depth : 6;
            var sb = new StringBuilder();
            sb.AppendLine($"<h{depth}>{Title}</h{depth}>");
            sb.AppendLine(HttpUtility.HtmlEncode(TextContent).Replace("\n", "<br/>\n"));
            foreach (var subChapter in SubChapters)
            {
                sb.AppendLine(subChapter.ToString(depth + 1));
            }
            return sb.ToString();
        }

        public SubChapter(string title, string textContent)
        {
            Title = title;
            TextContent = textContent;
            SubChapters = new List<SubChapter>();
        }

        public SubChapter(string title, List<SubChapter> subChapters)
        {
            Title = title;
            SubChapters = subChapters;
        }

        public SubChapter(string title, string textContent, List<SubChapter> subChapters)
        {
            Title = title;
            TextContent = textContent;
            SubChapters = subChapters;
        }

        public async Task<string> ToXHTMLStringAsync(
            ZipArchive epubArchive,
            EpubManifest epubManifest,
            EpubSpine epubSpine
        )
        {
            return ToString(1);
        }
    }
}
