using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.CategoryList;

namespace MiBo.Domain.Logic.Admin.CategoryList
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