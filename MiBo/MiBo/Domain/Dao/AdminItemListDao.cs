using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Dao;

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
        
    }
}