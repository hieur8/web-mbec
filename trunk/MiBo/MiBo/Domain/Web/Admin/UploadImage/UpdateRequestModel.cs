using System.Collections.Generic;

namespace MiBo.Domain.Web.Admin.UploadImage
{
    public class UpdateRequestModel
    {
        public IList<OutputImageModel> ListFiles { get; set; }
    }
}