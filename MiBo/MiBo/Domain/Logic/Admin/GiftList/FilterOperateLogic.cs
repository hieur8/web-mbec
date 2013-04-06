using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.GiftList;

namespace MiBo.Domain.Logic.Admin.GiftList
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