using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Common.Model
{
    public class ItemModel : Item
    {
        public decimal? SalesPriceOld { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Amount { get { return Quantity * SalesPrice; } }
        public string OfferDiv { get; set; }
        public string ItemImage { get; set; }
        public IList<StorageFile> ItemImages { get; set; }
        public IList<OfferItem> ListOfferItems { get; set; }
    }
}