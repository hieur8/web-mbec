using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.OfferEntry;

namespace MiBo.Domain.Logic.Admin.OfferEntry
{
    public class SaveByBrandOperateLogic : IOperateLogic<SaveByBrandResponseModel>
    {
        public SaveByBrandResponseModel Invoke(object obj)
        {
            var logic = new SaveByBrandLogic();

            return logic.Invoke((SaveByBrandRequestModel)obj);
        }
    }
}