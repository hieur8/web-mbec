using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.OfferList;

namespace MiBo.Domain.Logic.Admin.OfferList
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