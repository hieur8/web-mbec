using System;
using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Admin.OfferEntry;

namespace MiBo.Domain.Dao
{
    public class AdminOfferEntryDao : AbstractDao
    {
        public string GetOfferCd()
        {
            // Get value
            var listResult = from tbl in EntityManager.Offers
                             select tbl.OfferCd;

            var cd = Convert.ToInt64(listResult.Max());

            return Convert.ToString(cd + 1);
        }

        public bool IsExistOffer(string offerCd)
        {
            return IsExist<Offer>(offerCd, true);
        }

        public bool IsExistItem(string itemCd)
        {
            return IsExist<Item>(itemCd, true);
        }

        public void InsertOffer(SaveDataModel inputObject)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = new Offer();
            entity.OfferCd = inputObject.OfferCd;
            entity.ItemCd = inputObject.ItemCd;
            entity.StartDate = inputObject.StartDate;
            entity.EndDate = inputObject.EndDate;
            entity.OfferDiv = inputObject.OfferDiv;
            entity.Percent = inputObject.Percent;
            entity.SortKey = decimal.Zero;
            entity.Notes = inputObject.Notes;
            entity.CreateUser = PageHelper.UserName;
            entity.CreateDate = currentDate;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = false;

            EntityManager.Offers.InsertOnSubmit(entity);

            // Submit
            EntityManager.SubmitChanges();
        }
    }
}