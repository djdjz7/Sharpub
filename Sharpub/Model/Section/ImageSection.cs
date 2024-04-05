using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace Sharpub.Model.Section
{
    public class ImageSection : ISection
    {
        private enum ImageDataType
        {
            URL,
            ByteArray,
        }
        private object _imageData;
        private ImageDataType _dataType;
        public ImageSection(string imageUrl)
        {
            _imageData = imageUrl;
            _dataType = ImageDataType.URL;
        }
        public ImageSection(byte[] data)
        {
            _imageData = data;
            _dataType = ImageDataType.ByteArray;
        }
        public Task<string> ToXHTMLStringAsync(ZipArchive epubArchive)
        {
            throw new NotImplementedException();
        }
    }
}
