using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Model.Client.ShoppingCart
{
    public class UpdateDataModel
    {
        public IList<ItemModel> ListItems { get; set; }
        public IList<CartItem> Cart { get; set; }
    }
}