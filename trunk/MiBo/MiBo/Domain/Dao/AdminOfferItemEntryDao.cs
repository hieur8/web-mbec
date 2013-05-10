using System;
using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Admin.OfferItemEntry;

namespace MiBo.Domain.Dao
{
    public class AdminOfferItemEntryDao : AbstractDao
    {
        public bool IsExistOffer(string offerCd)
        {
            return IsExist<Offer>(offerCd, true);
        }

        public bool IsExistItem(string itemCd)
        {
            return IsExist<Item>(itemCd, true);
        }

        public decimal GetMaxOffer(string offerCd)
        {
            var listResult = from tbl in EntityManager.OfferItems
                             where tbl.OfferCd == offerCd
                             select tbl.DetailNo;

            var count = listResult.LongCount();
            if (count == decimal.Zero) return decimal.Zero;

            return listResult.Max();
        }

        public void InsertOfferItem(SaveDataModel inputObject)
        {
            // Get sysdate
            var currentDate = DateTime.Now;
            
            // Get max
            var max = GetMaxOffer(inputObject.OfferCd);

            // Set item
            var entity = new OfferItem();
            entity.OfferCd = inputObject.OfferCd;
            entity.DetailNo = max + 1;
            entity.OfferItemCd = inputObject.OfferItemCd;
            entity.OfferItemQtty = inputObject.OfferItemQtty;
            entity.SortKey = decimal.Zero;
            entity.CreateUser = PageHelper.UserName;
            entity.CreateDate = currentDate;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = inputObject.DeleteFlag;

            EntityManager.OfferItems.InsertOnSubmit(entity);

            // Submit
            EntityManager.SubmitChanges();
        }
    }
}