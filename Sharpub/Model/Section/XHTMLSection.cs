using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace Sharpub.Model.Section
{
    public class XHTMLSection : ISection
    {
        public Task<string> ToXHTMLStringAsync(
            ZipArchive epubArchive,
            EpubManifest epubManifest,
            EpubSpine epubSpine
        )
        {
            throw new NotImplementedException();
        }
    }
}
