using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Model.Client.ShoppingCart
{
    public class InitDataModel
    {
        /** Request Data **/
        public IList<CartItem> Cart { get; set; }

        /** Response Data **/
        public IList<ItemModel> ListItems { get; set; }
        public decimal TotalAmount { get; set; }
    }
}