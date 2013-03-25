using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.CategoryList
{
    public class OutputCategoryModel
    {
        public string CategoryCd { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDiv { get; set; }
        public string SortKey { get; set; }
        public string DeleteFlag { get; set; }
        public string UpdateDate { get; set; }
        public IList<ComboItem> ListCategoryDiv { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
    }
}