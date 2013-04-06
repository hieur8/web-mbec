using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.BrandEntry
{
    public class OutputDetailsModel
    {
        public string Status { get; set; }
        public string BrandCd { get; set; }
        public string BrandName { get; set; }
        public string BrandSearchName { get; set; }
        public string FileId { get; set; }
        public string Notes { get; set; }
        public string SortKey { get; set; }
        public string DeleteFlag { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
    }
}