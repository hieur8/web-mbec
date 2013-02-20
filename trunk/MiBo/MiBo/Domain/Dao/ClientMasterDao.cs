using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Constants;

namespace MiBo.Domain.Dao
{
    public class ClientMasterDao : AbstractDao
    {
        public IList<Category> GetListCategories(string categoryDiv)
        {
            var listResult = from tbl in EntityManager.Categories
                             where tbl.CategoryDiv == categoryDiv
                             && tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl;

            return listResult.ToList();
        }
    }
}