using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Dao
{
    public class ClientShoppingCartDao : AbstractDao
    {
        public bool IsExistItem(string itemCd)
        {
            return IsExist<Item>(itemCd, false);
        }

        public Item GetSingleItem(string itemCd)
        {
            return GetSingle<Item>(itemCd, false);
        }
    }
}