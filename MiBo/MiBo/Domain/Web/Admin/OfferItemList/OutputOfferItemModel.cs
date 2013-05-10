using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.OfferItemList
{
    public class OutputOfferItemModel
    {
        public string OfferCd { get; set; }
        public string DetailNo { get; set; }
        public string OfferItemCd { get; set; }
        public string OfferItemQtty { get; set; }
        public string DeleteFlag { get; set; }
        public string UpdateDate { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
    }
}