using System;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Admin.GiftEntry;

namespace MiBo.Domain.Dao
{
    public class AdminGiftEntryDao : AbstractDao
    {
        public bool IsExistGift(string giftCd)
        {
            return IsExist<GiftCard>(giftCd, true);
        }

        public void InsertGift(SaveDataModel inputObject)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = new GiftCard();
            entity.GiftCd = inputObject.GiftCd;
            entity.GiftStatus = Logics.CD_GIFT_STATUS_ACTIVE;
            entity.Price = inputObject.Price;
            entity.StartDate = inputObject.StartDate;
            entity.EndDate = inputObject.EndDate;
            entity.Notes = inputObject.Notes;

            entity.CreateDate = currentDate;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = false;

            EntityManager.GiftCards.InsertOnSubmit(entity);

            // Submit
            EntityManager.SubmitChanges();
        }
    }
}