using System;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Admin.BannerEntry;

namespace MiBo.Domain.Dao
{
    public class AdminBannerEntryDao : AbstractDao
    {
        public bool IsExistBanner(string bannerCd)
        {
            return IsExist<Banner>(bannerCd, true);
        }

        public Banner GetSingleBanner(string bannerCd)
        {
            return GetSingle<Banner>(bannerCd, true);
        }

        public void InsertBanner(SaveDataModel inputObject)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = new Banner();
            entity.BannerCd = inputObject.BannerCd;
            entity.BannerName = inputObject.BannerName;
            entity.FileId = inputObject.FileId;
            entity.Notes = inputObject.Notes;
            entity.SortKey = inputObject.SortKey;
            entity.CreateUser = PageHelper.UserName;
            entity.CreateDate = currentDate;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = inputObject.DeleteFlag;
            EntityManager.Banners.InsertOnSubmit(entity);

            // Submit
            EntityManager.SubmitChanges();
        }

        public void UpdateBanner(SaveDataModel inputObject)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = GetSingle<Banner>(inputObject.BannerCd, true);
            entity.BannerName = inputObject.BannerName;
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