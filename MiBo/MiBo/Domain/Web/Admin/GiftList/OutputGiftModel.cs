using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.GiftList
{
    public class OutputGiftModel
    {
        public string GiftCd { get; set; }
        public string GiftStatus { get; set; }
        public string Price { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string UpdateDate { get; set; }
        public string DeleteFlag { get; set; }
        public string DeleteFlagName { get; set; }
        public IList<ComboItem> ListGiftStatus { get; set; }
    }
}