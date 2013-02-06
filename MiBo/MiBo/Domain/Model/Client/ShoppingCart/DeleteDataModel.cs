using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Model.Client.ShoppingCart
{
    public class DeleteDataModel
    {
        /** Request Data **/
        public IList<CartItem> Cart { get; set; }
        public string ItemCd { get; set; }

        /** Response Data **/
        public IList<ItemModel> ListItems { get; set; }
        public decimal TotalAmount { get; set; }
    }
}