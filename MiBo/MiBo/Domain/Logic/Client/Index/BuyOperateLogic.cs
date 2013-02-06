using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Client.Index;

namespace MiBo.Domain.Logic.Client.Index
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