using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Dao
{
    public class ClientMasterDao : AbstractDao
    {
        public IList<Category> GetListCategories()
        {
            var listResult = from tbl in EntityManager.Categories
                             where tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl;

            return listResult.ToList();
        }
    }
}