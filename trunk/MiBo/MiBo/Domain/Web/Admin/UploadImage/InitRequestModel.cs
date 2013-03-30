using MiBo.Domain.Common.Validate;
namespace MiBo.Domain.Web.Admin.UploadImage
{
    public class InitRequestModel
    {
        public string FileId { get; set; }

        [ValidRequired(MessageParam = "Nhóm tập tin")]
        public string FileGroup { get; set; }
    }
}