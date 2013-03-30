using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.UploadImage
{
    public class InitResponseModel : MessageResponse
    {
        public string FileId { get; set; }
        public string FileGroup { get; set; }
        public IList<OutputImageModel> ListFiles { get; set; }
    }
}