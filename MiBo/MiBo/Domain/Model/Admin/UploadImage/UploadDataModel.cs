using System.IO;

namespace MiBo.Domain.Model.Admin.UploadImage
{
    public class UploadDataModel
    {
        public string FileId { get; set; }
        public string FileGroup { get; set; }
        public decimal? SortKey { get; set; }
        public Stream InputStream { get; set; }
    }
}