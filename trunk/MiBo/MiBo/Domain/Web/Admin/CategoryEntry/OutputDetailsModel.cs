using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.CategoryEntry
{
    public class OutputDetailsModel
    {
        public string CategoryDiv { get; set; }
        public string DeleteFlag { get; set; }
        public IList<ComboItem> ListCategoryDiv { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
    }
}