using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Model.Client.ItemDetails;

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
    }
}