using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Model.Client.Items
{
    public class BuyDataModel
    {
        public string ItemCd { get; set; }
        public decimal? ItemQtty { get; set; }
        public IList<CartItem> Cart { get; set; }
    }
}