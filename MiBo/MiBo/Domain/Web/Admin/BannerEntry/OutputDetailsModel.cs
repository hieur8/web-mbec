using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.BannerEntry
{
    public class OutputDetailsModel
    {
        public string Status { get; set; }
        public string BannerCd { get; set; }
        public string BannerName { get; set; }
        public string FileId { get; set; }
        public string OfferGroupCd { get; set; }
        public string SortKey { get; set; }
        public string DeleteFlag { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
        public IList<ComboItem> ListOfferGroup { get; set; }
    }
}