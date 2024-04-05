using Sharpub.Model;
using Sharpub.Model.Section;
using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace Sharpub
{
    public class EpubFile
    {
        public Chapter[] Chapters { get; set; }
        public EpubMetadata Metadata { get; }
        public EpubFile(EpubMetadata metadata)
        {
            Metadata = metadata;
        }

        public Task ExportAsync(string epubFilePath)
        {
            using (var fileStream = new FileStream(epubFilePath, FileMode.Create))
            {
                using (var zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create))
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
