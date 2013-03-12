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
            entity.CategoryCd = inputObject.CategoryCd;
            entity.AgeCd = inputObject.AgeCd;
            entity.GenderCd = inputObject.GenderCd;
            entity.BrandCd = inputObject.BrandCd;
            entity.CountryCd = inputObject.CountryCd;
            entity.UnitCd = inputObject.UnitCd;
            entity.ItemDiv = inputObject.ItemDiv;
            entity.Notes = inputObject.Notes;
            entity.SortKey = inputObject.SortKey;
            entity.CreateUser = PageHelper.UserName;
            entity.CreateDate = currentDate;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = inputObject.DeleteFlag;
            EntityManager.Items.InsertOnSubmit(entity);

            // Set pack
            Pack entityPack = null;
            foreach (var obj in inputObject.ListPacks)
        	{
		        entityPack = new Pack();
                entityPack.ItemCd = obj.ItemCd;
                entityPack.UnitCd = obj.UnitCd;
                entityPack.BuyingPrice = obj.BuyingPrice;
                entityPack.SalesPrice = obj.SalesPrice;
                entityPack.Notes = obj.Notes;
                entityPack.SortKey = obj.SortKey;
                entityPack.CreateUser = PageHelper.UserName;
                entityPack.CreateDate = currentDate;
                entityPack.UpdateUser = PageHelper.UserName;
                entityPack.UpdateDate = currentDate;
                entityPack.DeleteFlag = inputObject.DeleteFlag;
                EntityManager.Packs.InsertOnSubmit(entityPack);
        	}

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
            entity.CategoryCd = inputObject.CategoryCd;
            entity.AgeCd = inputObject.AgeCd;
            entity.GenderCd = inputObject.GenderCd;
            entity.BrandCd = inputObject.BrandCd;
            entity.CountryCd = inputObject.CountryCd;
            entity.UnitCd = inputObject.UnitCd;
            entity.ItemDiv = inputObject.ItemDiv;
            entity.Notes = inputObject.Notes;
            entity.SortKey = inputObject.SortKey;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = inputObject.DeleteFlag;

            // Set pack
            Pack entityPack = null;
            string[] keyPack = null;
            foreach (var obj in inputObject.ListPacks)
            {
                keyPack = new string[] { obj.ItemCd, obj.UnitCd };
                entityPack = GetSingle<Pack>(keyPack, true);
                entityPack.BuyingPrice = obj.BuyingPrice;
                entityPack.SalesPrice = obj.SalesPrice;
                entityPack.Notes = obj.Notes;
                entityPack.SortKey = obj.SortKey;
                entityPack.UpdateUser = PageHelper.UserName;
                entityPack.UpdateDate = currentDate;
                entityPack.DeleteFlag = inputObject.DeleteFlag;
            }

            // Submit
            EntityManager.SubmitChanges();
        }
    }
}