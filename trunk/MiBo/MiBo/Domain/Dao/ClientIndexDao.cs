using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Dao
{
    public class ClientIndexDao : AbstractDao
    {
        public IList<Item> GetListNewItems()
        {
            var listResult = from tbl in EntityManager.Items
                             where tbl.ItemNew == Logics.CD_ITEM_NEW_ON
                             && tbl.DeleteFlag == false
                             orderby tbl.SortKey descending
                             select tbl;

            return listResult.ToList();
        }
    }
}