using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.GroupList;

namespace MiBo.Domain.Logic.Admin.GroupList
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