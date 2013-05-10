using System;
using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;

namespace MiBo.Domain.Dao
{
    public class AdminOfferItemListDao : AbstractDao
    {
        public IList<OfferItem> GetListOfferItems(string offerCd)
        {
            // Get value
            var listResult = from tbl in EntityManager.OfferItems
                             where tbl.OfferCd == offerCd
                             orderby tbl.UpdateDate ascending
                             select tbl;

            // Return value
            return listResult.ToList();
        }

        public bool IsExistOffer(string offerCd)
        {
            return IsExist<Offer>(offerCd, true);
        }

        public bool IsExistItem(string itemCd)
        {
            return IsExist<Item>(itemCd, true);
        }

        public bool IsExistOfferItem(string offerCd, decimal detailNo)
        {
            // Get value
            var listResult = from tbl in EntityManager.OfferItems
                             where tbl.OfferCd == offerCd
                             where tbl.DetailNo == detailNo
                             select tbl;

            var count = listResult.LongCount();

            return count == decimal.One;
        }

        public OfferItem GetSingleOfferItem(string offerCd, decimal detailNo)
        {
            // Get value
            var listResult = from tbl in EntityManager.OfferItems
                             where tbl.OfferCd == offerCd
                             where tbl.DetailNo == detailNo
                             select tbl;

            return listResult.SingleOrDefault();
        }

        public void UpdateOfferItem(OfferItem param)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = GetSingleOfferItem(param.OfferCd, param.DetailNo);
            entity.OfferItemCd = param.OfferItemCd;
            entity.OfferItemQtty = param.OfferItemQtty;
            entity.DeleteFlag = param.DeleteFlag;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
        }
    }
}