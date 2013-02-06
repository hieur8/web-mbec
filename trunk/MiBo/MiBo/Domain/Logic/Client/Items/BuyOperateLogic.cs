using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Client.Items;

namespace MiBo.Domain.Logic.Client.Items
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