using System.IO;
using MiBo.Domain.Common.Validate;

namespace MiBo.Domain.Web.Admin.UploadImage
{
    public class UploadRequestModel
    {
        [ValidRequired(MessageParam = "Mã tập tin")]
        public string FileId { get; set; }
        [ValidRequired(MessageParam = "Nhóm tập tin")]
        public string FileGroup { get; set; }
        [ValidRequired(MessageParam = "Thứ tự")]
        public string SortKey { get; set; }
        public Stream InputStream { get; set; }
    }
}