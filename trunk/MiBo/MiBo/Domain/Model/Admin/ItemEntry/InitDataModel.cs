using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.ItemEntry
{
    public class InitDataModel
    {
        public Item Item { get; set; }
        public IList<Category> ListCategory { get; set; }
        public IList<Age> ListAge { get; set; }
        public IList<Gender> ListGender { get; set; }
        public IList<Brand> ListBrand { get; set; }
        public IList<Country> ListCountry { get; set; }
        public IList<Unit> ListUnit { get; set; }
        public IList<MCode> ListItemDiv { get; set; }
    }
}