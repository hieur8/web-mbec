using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.OfferList
{
    public class OutputOfferModel
    {
        public string OfferCd { get; set; }
        public string ItemCd { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string OfferDiv { get; set; }
        public string OfferDivName { get; set; }
        public string Percent { get; set; }
        public string DeleteFlag { get; set; }
        public string UpdateDate { get; set; }
        public string Notes { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
    }
}