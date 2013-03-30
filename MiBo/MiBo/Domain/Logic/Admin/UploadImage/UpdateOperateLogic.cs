using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.UploadImage;

namespace MiBo.Domain.Logic.Admin.UploadImage
{
    public class UpdateOperateLogic : IOperateLogic<UpdateResponseModel>
    {
        public UpdateResponseModel Invoke(object obj)
        {
            var logic = new UpdateLogic();

            return logic.Invoke((UpdateRequestModel)obj);
        }
    }
}