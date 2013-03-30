using System.Collections.Generic;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.ItemEntry
{
    public class OutputDetailsModel
    {
        public string Status { get; set; }
        public string ItemCd { get; set; }
        public string ItemName { get; set; }
        public string ItemSearchName { get; set; }
        public string CategoryCd { get; set; }
        public string AgeCd { get; set; }
        public string GenderCd { get; set; }
        public string BrandCd { get; set; }
        public string CountryCd { get; set; }
        public string UnitCd { get; set; }
        public string ItemDiv { get; set; }
        public string LinkVideo { get; set; }
        public string Material { get; set; }
        public string SummaryNotes { get; set; }
        public string Notes { get; set; }
        public string SortKey { get; set; }
        public string FileId { get; set; }
        public string SalesPrice { get; set; }
        public string BuyingPrice { get; set; }
        public string DeleteFlag { get; set; }
        public IList<ComboItem> ListCategory { get; set; }
        public IList<ComboItem> ListAge { get; set; }
        public IList<ComboItem> ListGender { get; set; }
        public IList<ComboItem> ListBrand { get; set; }
        public IList<ComboItem> ListCountry { get; set; }
        public IList<ComboItem> ListUnit { get; set; }
        public IList<ComboItem> ListItemDiv { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
    }
}