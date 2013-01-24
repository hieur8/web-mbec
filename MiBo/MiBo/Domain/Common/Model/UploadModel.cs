using System.IO;
using MiBo.Domain.Common.Constants;

namespace MiBo.Domain.Common.Model
{
    public class UploadModel
    {
        public static UploadModel Empty = new UploadModel();

        public Stream Stream { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string FullUrl { get { return Url + FileName; } }

        public string UrlImageSmall { get { return Url + Logics.URL_IMAGE_SMALL + FileName; } }
        public string UrlImageNormal { get { return Url + Logics.URL_IMAGE_NORMAL + FileName; } }
        public string UrlImageLarger { get { return Url + Logics.URL_IMAGE_LARGER + FileName; } }
    }
}