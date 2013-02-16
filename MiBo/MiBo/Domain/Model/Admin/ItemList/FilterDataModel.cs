using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.ItemList
{
    public class FilterDataModel
    {
        public string CategoryCd { get; set; }
        public string AgeCd { get; set; }
        public string GenderCd { get; set; }
        public string BrandCd { get; set; }
        public string CountryCd { get; set; }
        public string UnitCd { get; set; }
        public string ItemDiv { get; set; }

        public IList<Item> ListItems { get; set; }
    }
}