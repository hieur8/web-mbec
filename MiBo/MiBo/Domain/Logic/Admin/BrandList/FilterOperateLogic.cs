using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.BrandList;

namespace MiBo.Domain.Logic.Admin.BrandList
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