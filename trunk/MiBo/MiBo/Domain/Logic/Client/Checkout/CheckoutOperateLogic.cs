using MiBo.Domain.Common.Logic;
using MiBo.Domain.Web.Client.Index;
using MiBo.Domain.Web.Client.Checkout;

namespace MiBo.Domain.Logic.Client.Checkout
{
    public class CheckoutOperateLogic : IOperateLogic<CheckoutResponseModel>
    {
        public CheckoutResponseModel Invoke(object obj)
        {
            var logic = new CheckoutLogic();

            return logic.Invoke((CheckoutRequestModel)obj);
        }
    }
}