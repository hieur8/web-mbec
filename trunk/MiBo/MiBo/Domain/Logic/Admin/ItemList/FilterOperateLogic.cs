using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.ItemList;

namespace MiBo.Domain.Logic.Admin.ItemList
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