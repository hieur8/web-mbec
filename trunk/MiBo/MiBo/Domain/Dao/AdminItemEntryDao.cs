using System;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Admin.ItemEntry;

namespace MiBo.Domain.Dao
{
    public class AdminItemEntryDao : AbstractDao
    {
        public bool IsExistItem(string itemCd)
        {
            return IsExist<Item>(itemCd, true);
        }

        public Item GetSingleItem(string itemCd)
        {
            return GetSingle<Item>(itemCd, true);
        }

        public void InsertItem(SaveDataModel inputObject)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = new Item();
            entity.ItemCd = inputObject.ItemCd;
            entity.ItemName = inputObject.ItemName;
            entity.ItemSearchName = inputObject.ItemSearchName;
            entity.CategoryCd = inputObject.CategoryCd;
            entity.AgeCd = inputObject.AgeCd;
            entity.GenderCd = inputObject.GenderCd;
            entity.BrandCd = inputObject.BrandCd;
            entity.CountryCd = inputObject.CountryCd;
            entity.UnitCd = inputObject.UnitCd;
            entity.ItemDiv = inputObject.ItemDiv;
            entity.BuyingPrice = inputObject.BuyingPrice;
            entity.SalesPrice = inputObject.SalesPrice;
            entity.Viewer = decimal.Zero;
            entity.Packing = inputObject.Packing;
            entity.SummaryNotes = inputObject.SummaryNotes;
            entity.Notes = inputObject.Notes;
            entity.SortKey = inputObject.SortKey;
            entity.CreateUser = PageHelper.UserName;
            entity.CreateDate = currentDate;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = inputObject.DeleteFlag;
            EntityManager.Items.InsertOnSubmit(entity);

            // Submit
            EntityManager.SubmitChanges();
        }

        public void UpdateItem(SaveDataModel inputObject)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = GetSingle<Item>(inputObject.ItemCd, true);
            entity.ItemName = inputObject.ItemName;
            entity.ItemSearchName = inputObject.ItemSearchName;
            entity.CategoryCd = inputObject.CategoryCd;
            entity.AgeCd = inputObject.AgeCd;
            entity.GenderCd = inputObject.GenderCd;
            entity.BrandCd = inputObject.BrandCd;
            entity.CountryCd = inputObject.CountryCd;
            entity.UnitCd = inputObject.UnitCd;
            entity.ItemDiv = inputObject.ItemDiv;
            entity.BuyingPrice = inputObject.BuyingPrice;
            entity.SalesPrice = inputObject.SalesPrice;
            entity.Notes = inputObject.Notes;
            entity.SortKey = inputObject.SortKey;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = inputObject.DeleteFlag;

            // Submit
            EntityManager.SubmitChanges();
        }
    }
}