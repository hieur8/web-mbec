using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.UploadImage;

namespace MiBo.Domain.Logic.Admin.UploadImage
{
    public class UploadOperateLogic : IOperateLogic<UploadResponseModel>
    {
        public UploadResponseModel Invoke(object obj)
        {
            var logic = new UploadLogic();

            return logic.Invoke((UploadRequestModel)obj);
        }
    }
}