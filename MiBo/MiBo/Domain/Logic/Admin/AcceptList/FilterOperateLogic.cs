using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.AcceptList;

namespace MiBo.Domain.Logic.Admin.AcceptList
{
    public class FilterOperateLogic : IOperateLogic<FilterResponseModel>
    {
        public FilterResponseModel Invoke(object obj)
        {
            var logic = new FilterLogic();

            return logic.Invoke((FilterRequestModel)obj);
        }
    }
}