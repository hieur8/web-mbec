using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.BrandList
{
    public class FilterDataModel
    {
        public string BrandCd { get; set; }
        public string BrandName { get; set; }
        public bool? DeleteFlag { get; set; }

        public IList<Brand> ListBrands { get; set; }
    }
}