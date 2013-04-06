using System;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Admin.BrandEntry;

namespace MiBo.Domain.Dao
{
    public class AdminBrandEntryDao : AbstractDao
    {
        public bool IsExistBrand(string brandCd)
        {
            return IsExist<Brand>(brandCd, true);
        }

        public Brand GetSingleBrand(string brandCd)
        {
            return GetSingle<Brand>(brandCd, true);
        }

        public void InsertBrand(SaveDataModel inputObject)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = new Brand();
            entity.BrandCd = inputObject.BrandCd;
            entity.BrandName = inputObject.BrandName;
            entity.BrandSearchName = inputObject.BrandSearchName;
            entity.FileId = inputObject.FileId;
            entity.Notes = inputObject.Notes;
            entity.SortKey = inputObject.SortKey;
            entity.CreateUser = PageHelper.UserName;
            entity.CreateDate = currentDate;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = inputObject.DeleteFlag;
            EntityManager.Brands.InsertOnSubmit(entity);

            // Submit
            EntityManager.SubmitChanges();
        }

        public void UpdateBrand(SaveDataModel inputObject)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = GetSingle<Brand>(inputObject.BrandCd, true);
            entity.BrandName = inputObject.BrandName;
            entity.BrandSearchName = inputObject.BrandSearchName;
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