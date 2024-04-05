using System.IO.Compression;
using System.Threading.Tasks;

namespace Sharpub.Model.Section
{
    public interface ISection
    {
        Task<string> ToXHTMLStringAsync(ZipArchive epubArchive, EpubManifest epubManifest, EpubSpine epubSpine);
    }
}
