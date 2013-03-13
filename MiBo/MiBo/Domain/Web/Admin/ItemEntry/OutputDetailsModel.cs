using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace MiBo.Domain.Web.Admin.ItemEntry
{
    public class OutputDetailsModel
    {
        public string Status { get; set; }
        public string ItemCd { get; set; }
        public string ItemName { get; set; }
        public string CategoryCd { get; set; }
        public string AgeCd { get; set; }
        public string GenderCd { get; set; }
        public string BrandCd { get; set; }
        public string CountryCd { get; set; }
        public string UnitCd { get; set; }
        public string ItemDiv { get; set; }
        public string Notes { get; set; }
        public string SortKey { get; set; }
        public string ImagePath { get; set; }
        public string SalesPrice { get; set; }
        public string BuyingPrice { get; set; }
        public string DeleteFlag { get; set; }
        public ListItem[] ListCategory { get; set; }
        public ListItem[] ListAge { get; set; }
        public ListItem[] ListGender { get; set; }
        public ListItem[] ListBrand { get; set; }
        public ListItem[] ListCountry { get; set; }
        public ListItem[] ListUnit { get; set; }
        public ListItem[] ListItemDiv { get; set; }
        public ListItem[] ListDeleteFlag { get; set; }
    }
}