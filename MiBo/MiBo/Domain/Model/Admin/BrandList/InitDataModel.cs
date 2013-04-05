using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Model.Admin.BrandList
{
    public class InitDataModel
    {
        public IList<Brand> ListBrands { get; set; }
        public IList<MCode> ListDeleteFlag { get; set; }
    }
}