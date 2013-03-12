using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.ItemEntry
{
    public class InitDataModel
    {
        public string ItemCd { get; set; }

        public Item Item { get; set; }
        public string ImagePath { get; set; }
        public IList<MCode> ListCategory { get; set; }
        public IList<MCode> ListAge { get; set; }
        public IList<MCode> ListGender { get; set; }
        public IList<MCode> ListBrand { get; set; }
        public IList<MCode> ListCountry { get; set; }
        public IList<MCode> ListUnit { get; set; }
        public IList<MCode> ListItemDiv { get; set; }
        public IList<MCode> ListDeleteFlag { get; set; }
    }
}