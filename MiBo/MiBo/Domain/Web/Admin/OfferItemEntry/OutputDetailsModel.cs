using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.OfferItemEntry
{
    public class OutputDetailsModel
    {
        public string OfferCd { get; set; }
        public string DeleteFlag { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
    }
}