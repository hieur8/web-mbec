using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.ItemEntry
{
    public class SaveDataModel
    {
        public string UserName { get; set; }

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

        public IList<Pack> ListPacks { get; set; }
        public IList<ItemImage> ListImages { get; set; }
    }
}