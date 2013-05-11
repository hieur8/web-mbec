using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.Checkout
{
    public class CheckoutResponseModel : MessageResponse
    {
        public string AcceptSlipNo { get; set; }
        
    }
}