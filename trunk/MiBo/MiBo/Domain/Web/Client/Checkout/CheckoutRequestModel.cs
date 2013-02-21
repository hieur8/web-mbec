using MiBo.Domain.Common.Dao;
namespace MiBo.Domain.Web.Client.Checkout
{
    public class CheckoutRequestModel
    {
        public Accept Accept { get; set; }
        public object Cart { get; set; }
    }
}