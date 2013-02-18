using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.ShoppingCart
{
    public class UpdateResponseModel : MessageResponse
    {
        public IList<CartItem> Cart { get; set; }
    }
}