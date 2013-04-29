using System;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Admin.GroupEntry;

namespace MiBo.Domain.Dao
{
    public class AdminGroupEntryDao : AbstractDao
    {
        public bool IsExistGroup(string groupCd)
        {
            return IsExist<Group>(groupCd, true);
        }

        public void InsertGroup(SaveDataModel inputObject)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = new Group();
            entity.GroupCd = inputObject.GroupCd;
            entity.GroupName = inputObject.GroupName;
            entity.SortKey = inputObject.SortKey;
            entity.CreateUser = PageHelper.UserName;
            entity.CreateDate = currentDate;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = inputObject.DeleteFlag;

            EntityManager.Groups.InsertOnSubmit(entity);

            // Submit
            EntityManager.SubmitChanges();
        }
    }
}