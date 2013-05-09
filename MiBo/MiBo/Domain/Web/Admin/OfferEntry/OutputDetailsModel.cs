using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.OfferEntry
{
    public class OutputDetailsModel
    {
        public string OfferCd { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string OfferDiv { get; set; }
        public IList<ComboItem> ListOfferDiv { get; set; }
    }
}