using System.Collections.Generic;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.ItemEntry
{
    public class InitResponseModel : MessageResponse
    {
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

        public IList<OutputPackModel> ListPacks { get; set; }
        public IList<OutputImageModel> ListImages { get; set; }

        public ListItem[] ListCategory { get; set; }
        public ListItem[] ListAge { get; set; }
        public ListItem[] ListGender { get; set; }
        public ListItem[] ListBrand { get; set; }
        public ListItem[] ListCountry { get; set; }
        public ListItem[] ListUnit { get; set; }
        public ListItem[] ListItemDiv { get; set; }
    }
}