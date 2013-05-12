using System;
using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Admin.OfferList;

namespace MiBo.Domain.Dao
{
    public class AdminOfferListDao : AbstractDao
    {
        public IList<Offer> GetListOffers()
        {
            // Get value
            var listResult = from tbl in EntityManager.Offers
                             orderby tbl.UpdateDate ascending
                             select tbl;

            // Return value
            return listResult.ToList();
        }

        public IList<Offer> GetListOffers(FilterDataModel inputObject)
        {
            // Get value
            var listResult = from tbl in EntityManager.Offers
                             where (tbl.ItemCd.Contains(inputObject.ItemCd) || DataCheckHelper.IsNull(inputObject.ItemCd))
                             && (tbl.OfferDiv == inputObject.OfferDiv || DataCheckHelper.IsNull(inputObject.OfferDiv))
                             && (tbl.DeleteFlag == inputObject.DeleteFlag || DataCheckHelper.IsNull(inputObject.DeleteFlag))
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

        public void UpdateOffer(Offer param)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = GetSingle<Offer>(param.OfferCd, true);
            entity.ItemCd = param.ItemCd;
            entity.StartDate = param.StartDate;
            entity.EndDate = param.EndDate;
            entity.Percent = param.Percent;
            entity.Notes = param.Notes;
            entity.DeleteFlag = param.DeleteFlag;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
        }
    }
}