using System;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Admin.CategoryEntry;

namespace MiBo.Domain.Dao
{
    public class AdminCategoryEntryDao : AbstractDao
    {
        public bool IsExistCategory(string categoryCd)
        {
            return IsExist<Category>(categoryCd, true);
        }

        public void InsertCategory(SaveDataModel inputObject)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = new Category();
            entity.CategoryCd = inputObject.CategoryCd;
            entity.CategoryName = inputObject.CategoryName;
            entity.CategorySearchName = inputObject.CategorySearchName;
            entity.CategoryDiv = inputObject.CategoryDiv;
            entity.Notes = string.Empty;
            entity.SortKey = inputObject.SortKey;
            entity.CreateUser = PageHelper.UserName;
            entity.CreateDate = currentDate;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = inputObject.DeleteFlag;

            EntityManager.Categories.InsertOnSubmit(entity);

            // Submit
            EntityManager.SubmitChanges();
        }
    }
}