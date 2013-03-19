using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Web.Admin.ItemList
{
    public class InitResponseModel : MessageResponse
    {
        public IList<OutputItemModel> ListItems { get; set; }
        public IList<ComboItem> ListCategory { get; set; }
        public string CategoryCd { get; set; }
        public IList<ComboItem> ListAge { get; set; }
        public string AgeCd { get; set; }
        public IList<ComboItem> ListGender { get; set; }
        public string GenderCd { get; set; }
        public IList<ComboItem> ListBrand { get; set; }
        public string BrandCd { get; set; }
        public IList<ComboItem> ListCountry { get; set; }
        public string CountryCd { get; set; }
        public IList<ComboItem> ListUnit { get; set; }
        public string UnitCd { get; set; }
        public IList<ComboItem> ListItemDiv { get; set; }
        public string ItemDiv { get; set; }
        public IList<ComboItem> ListDeleteFlag { get; set; }
        public string DeleteFlag { get; set; }
    }
}