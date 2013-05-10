namespace MiBo.Domain.Model.Admin.OfferItemEntry
{
    public class SaveDataModel
    {
        public string OfferCd { get; set; }
        public string OfferItemCd { get; set; }
        public decimal? OfferItemQtty { get; set; }
        public bool? DeleteFlag { get; set; }
    }
}