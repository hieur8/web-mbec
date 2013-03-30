using System.Collections.Generic;

namespace MiBo.Domain.Web.Admin.UploadImage
{
    public class DeleteRequestModel
    {
        public IList<OutputImageModel> ListFiles { get; set; }
    }
}