using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Model.Client.ItemDetails;
using System.Collections.Generic;

namespace MiBo.Domain.Dao
{
    public class ClientItemDetailsDao : AbstractDao
    {
        public Item GetItem(InitDataModel inputObject)
        {
            var listResult = from tbl in EntityManager.Items
                             where tbl.ItemCd == inputObject.ItemCd
                             && tbl.DeleteFlag == false
                             select tbl;

            return listResult.SingleOrDefault();
        }

        public bool IsExistItem(string itemCd)
        {
            return IsExist<Item>(itemCd, false);
        }

        public IList<Item> GetListItemsByCategoryCd(string categoryCd,string itemCd)
        {
            var listResult = from tbl in EntityManager.Items
                             where tbl.CategoryCd == categoryCd
                             && tbl.DeleteFlag == false
                             && tbl.ItemCd != itemCd
                             select tbl;
            return listResult.Take(10).ToList();
        }
    }
}