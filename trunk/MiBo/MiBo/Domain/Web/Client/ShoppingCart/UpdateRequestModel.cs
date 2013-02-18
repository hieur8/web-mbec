using System.Collections.Generic;

namespace MiBo.Domain.Web.Client.ShoppingCart
{
    public class UpdateRequestModel
    {
        public IList<OutputItemModel> ListItems { get; set; }
        public object Cart { get; set; }
    }
}