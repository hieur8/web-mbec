using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.ShoppingCart
{
    public class GiftResponseModel : MessageResponse
    {
        public bool IsExit { get; set; }
        public string GiftCd { get; set; }
        public decimal Price { get; set; }
    }
}