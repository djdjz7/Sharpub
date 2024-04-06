using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sharpub.Model.Section
{
    public class TextSection : ISection
    {
        public string Content { get; set; }
        public Task<string> ToXHTMLStringAsync(ZipArchive epubArchive, EpubManifest epubManifest, EpubSpine epubSpine)
        {
            return Task.FromResult(HttpUtility.HtmlEncode(Content));
        }

        public TextSection(string content)
        {
            Content = content;
        }
    }
}
