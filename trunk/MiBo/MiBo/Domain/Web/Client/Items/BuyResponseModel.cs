using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.Items
{
    public class BuyResponseModel : MessageResponse
    {
        public IList<CartItem> Cart { get; set; }
    }
}