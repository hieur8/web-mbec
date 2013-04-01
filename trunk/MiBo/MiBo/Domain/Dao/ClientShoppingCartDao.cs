using MiBo.Domain.Common.Dao;
using System.Linq;
using System;
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

        public GiftCard getSingleGift(string giftCd)
        {
            var result = (from tbl in EntityManager.GiftCards 
                         where tbl.GiftCd == giftCd
                         && tbl.DeleteFlag == false
                         && tbl.StartDate <= DateTime.Now
                         && tbl.EndDate >= DateTime.Now
                          select tbl).SingleOrDefault<GiftCard>();
            return result;
        }
    }
}