using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Admin.BrandList;

namespace MiBo.Domain.Dao
{
    public class AdminBrandListDao : AbstractDao
    {
        public IList<Brand> GetListBrands()
        {
            // Get value
            var listResult = from tbl in EntityManager.Brands
                             orderby tbl.SortKey ascending
                             select tbl;

            // Return value
            return listResult.ToList();
        }

        public IList<Brand> GetListBrands(FilterDataModel inputObject)
        {
            // Get value
            var listResult = from tbl in EntityManager.Brands
                             where (tbl.BrandCd.Contains(inputObject.BrandCd) || DataCheckHelper.IsNull(inputObject.BrandCd))
                             && (tbl.BrandName.Contains(inputObject.BrandName)
                                || tbl.BrandSearchName.Contains(inputObject.BrandName) 
                                || DataCheckHelper.IsNull(inputObject.BrandName))
                             && (tbl.DeleteFlag == inputObject.DeleteFlag || DataCheckHelper.IsNull(inputObject.DeleteFlag))
                             orderby tbl.SortKey ascending
                             select tbl;

            // Return value
            return listResult.ToList();
        }
    }
}