using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Admin.ItemList;

namespace MiBo.Domain.Dao
{
    public class AdminItemListDao : AbstractDao
    {
        public IList<Item> GetListItems()
        {
            // Get value
            var listResult = from tbl in EntityManager.Items
                             where tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl;

            // Return value
            return listResult.ToList();
        }

        public IList<Item> GetListItems(FilterDataModel inputObject)
        {
            // Get value
            var listResult = from tbl in EntityManager.Items
                             where (tbl.CategoryCd == inputObject.CategoryCd || DataCheckHelper.IsNull(inputObject.CategoryCd))
                             && (tbl.AgeCd == inputObject.AgeCd || DataCheckHelper.IsNull(inputObject.AgeCd))
                             && (tbl.GenderCd == inputObject.GenderCd || DataCheckHelper.IsNull(inputObject.GenderCd))
                             && (tbl.BrandCd == inputObject.BrandCd || DataCheckHelper.IsNull(inputObject.BrandCd))
                             && (tbl.CountryCd == inputObject.CountryCd || DataCheckHelper.IsNull(inputObject.CountryCd))
                             && (tbl.UnitCd == inputObject.UnitCd || DataCheckHelper.IsNull(inputObject.UnitCd))
                             && (tbl.ItemDiv == inputObject.ItemDiv || DataCheckHelper.IsNull(inputObject.ItemDiv))
                             && tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl;

            // Return value
            return listResult.ToList();
        }
        
    }
}