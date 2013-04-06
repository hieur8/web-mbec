using System;
using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Admin.GiftList;
using MiBo.Domain.Common.Constants;

namespace MiBo.Domain.Dao
{
    public class AdminGiftListDao : AbstractDao
    {
        public IList<GiftCard> GetListGifts()
        {
            // Get value
            var listResult = from tbl in EntityManager.GiftCards
                             orderby tbl.UpdateDate ascending
                             select tbl;

            // Return value
            return listResult.ToList();
        }

        public IList<GiftCard> GetListGifts(FilterDataModel inputObject)
        {
            // Get value
            var listResult = from tbl in EntityManager.GiftCards
                             where (tbl.GiftCd.Contains(inputObject.GiftCd) || DataCheckHelper.IsNull(inputObject.GiftCd))
                             && (tbl.GiftStatus == inputObject.GiftStatus || DataCheckHelper.IsNull(inputObject.GiftStatus))
                             && (tbl.DeleteFlag == inputObject.DeleteFlag || DataCheckHelper.IsNull(inputObject.DeleteFlag))
                             orderby tbl.UpdateDate ascending
                             select tbl;

            // Return value
            return listResult.ToList();
        }

        public bool IsExistGift(string giftCd)
        {
            return IsExist<GiftCard>(giftCd, false);
        }

        public void UpdateGift(GiftCard param)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = GetSingle<GiftCard>(param.GiftCd, false);
            entity.GiftStatus = param.GiftStatus;
            if (entity.GiftStatus == Logics.CD_GIFT_STATUS_ACTIVE)
                entity.StartDate = currentDate;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
        }
    }
}