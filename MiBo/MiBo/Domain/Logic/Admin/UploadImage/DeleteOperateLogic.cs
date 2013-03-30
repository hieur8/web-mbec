using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.UploadImage;

namespace MiBo.Domain.Logic.Admin.UploadImage
{
    public class DeleteOperateLogic : IOperateLogic<DeleteResponseModel>
    {
        public DeleteResponseModel Invoke(object obj)
        {
            var logic = new DeleteLogic();

            return logic.Invoke((DeleteRequestModel)obj);
        }
    }
}