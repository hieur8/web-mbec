using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Client.ShoppingCart
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputItemModel> ListItems { get; set; }
        public string TotalAmount { get; set; }
    }
}