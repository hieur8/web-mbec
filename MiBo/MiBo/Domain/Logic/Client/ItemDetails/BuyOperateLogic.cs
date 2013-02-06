using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Client.ItemDetails;

namespace MiBo.Domain.Logic.Client.ItemDetails
{
    public class BuyOperateLogic : IOperateLogic<BuyResponseModel>
    {
        public BuyResponseModel Invoke(object obj)
        {
            var logic = new BuyLogic();

            return logic.Invoke((BuyRequestModel)obj);
        }
    }
}