using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Admin.OfferEntry;

namespace MiBo.Domain.Logic.Admin.OfferEntry
{
    public class SaveOperateLogic : IOperateLogic<SaveResponseModel>
    {
        public SaveResponseModel Invoke(object obj)
        {
            var logic = new SaveLogic();

            return logic.Invoke((SaveRequestModel)obj);
        }
    }
}