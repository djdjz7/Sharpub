using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Sharpub.Utils
{
    internal static class ZipExtensions
    {
        public static async Task AddEntryAsync(this ZipArchive zipArchive, string entryName, byte[] entryData)
        {
            var entry = zipArchive.CreateEntry(entryName);
            using (var stream = entry.Open())
                await stream.WriteAsync(entryData, 0, entryData.Length);
        }
    }
}
