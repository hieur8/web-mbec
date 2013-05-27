using System;
using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Admin.OfferEntry;
using System.Collections.Generic;

namespace MiBo.Domain.Dao
{
    public class AdminOfferEntryDao : AbstractDao
    {
        public string GetOfferCd()
        {
            // Get value
            var listResult = from tbl in EntityManager.Offers
                             select Convert.ToInt64(tbl.OfferCd);

            var count = listResult.Count();
            var max = decimal.Zero;

            if (count == decimal.Zero) max = decimal.One;
            else max = listResult.Max() + 1;

            return Convert.ToString(max);
        }

        public IList<string> GetItemByBrand(string brandCd)
        {
            // Get value
            var listResult = from tbl in EntityManager.Items
                             where tbl.BrandCd == brandCd
                             && tbl.DeleteFlag == false
                             select tbl.ItemCd;

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

        public bool IsExistBrand(string brandCd)
        {
            return IsExist<Brand>(brandCd, true);
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
            entity.OfferGroupCd = inputObject.OfferGroupCd;
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

        public void InsertOffer(SaveByBrandDataModel inputObject)
        {
            // Get sysdate
            var currentDate = DateTime.Now;
            // Get list items
            var listItems = GetItemByBrand(inputObject.BrandCd);
            var offerCd = Convert.ToDecimal(inputObject.OfferCd);

            // Insert item
            foreach (var itemCd in listItems)
            {
                var entity = new Offer();
                entity.OfferCd = Convert.ToString(offerCd++);
                entity.ItemCd = itemCd;
                entity.StartDate = inputObject.StartDate;
                entity.EndDate = inputObject.EndDate;
                entity.OfferDiv = inputObject.OfferDiv;
                entity.Percent = inputObject.Percent;
                entity.SortKey = decimal.Zero;
                entity.OfferGroupCd = inputObject.OfferGroupCd;
                entity.Notes = inputObject.Notes;
                entity.CreateUser = PageHelper.UserName;
                entity.CreateDate = currentDate;
                entity.UpdateUser = PageHelper.UserName;
                entity.UpdateDate = currentDate;
                entity.DeleteFlag = false;

                EntityManager.Offers.InsertOnSubmit(entity);
            }

            // Submit
            EntityManager.SubmitChanges();
        }
    }
}