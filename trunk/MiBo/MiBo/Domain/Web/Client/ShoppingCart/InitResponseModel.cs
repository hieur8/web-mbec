using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.ShoppingCart
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputItemModel> ListItems { get; set; }
        public IList<OutputItemModel> ListOfferItems { get; set; }
        public string TotalAmount { get; set; }
        public decimal TotalAmountDecimal { get; set; }
    }
}