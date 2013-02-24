using System.Collections.Generic;

namespace MiBo.Domain.Web.Client.ItemDetails
{
    public class OutputDetailsModel
    {
        public string ItemCd { get; set; }
        public string ItemName { get; set; }
        public string ItemImage { get; set; }
        public IList<OutputImageModel> ListImages { get; set; }
        public string ItemDiv { get; set; }
        public string OfferDiv { get; set; }
        public string Price { get; set; }
        public string PriceOld { get; set; }
        public string BrandCd { get; set; }
        public string BrandName { get; set; }
        public string CountryCd { get; set; }
        public string CountryName { get; set; }
        public string Notes { get; set; }
        public IList<OutputItemModel> ListOfferItems { get; set; }
    }
}