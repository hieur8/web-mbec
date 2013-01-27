using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Common.Model
{
    public class ItemModel : Item
    {
        public decimal? SalesPriceOld { get; set; }
        public decimal? SalesPrice { get; set; }
        public string OfferDiv { get; set; }
        public string ItemImage { get; set; }
    }
}