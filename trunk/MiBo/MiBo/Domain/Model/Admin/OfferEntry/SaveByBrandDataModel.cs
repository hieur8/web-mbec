using System;

namespace MiBo.Domain.Model.Admin.OfferEntry
{
    public class SaveByBrandDataModel
    {
        public string OfferCd { get; set; }
        public string BrandCd { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OfferDiv { get; set; }
        public decimal Percent { get; set; }
        public string OfferGroupCd { get; set; }
        public string Notes { get; set; }
    }
}