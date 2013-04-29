using System;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Admin.GroupRoleEntry;

namespace MiBo.Domain.Dao
{
    public class AdminGroupRoleEntryDao : AbstractDao
    {
        public bool IsExistGroup(string groupCd)
        {
            return IsExist<Group>(groupCd, true);
        }

        public bool IsExistGroupRole(string groupCd, string roleCd)
        {
            return IsExist<GroupRole>(new string[] { groupCd, roleCd }, true);
        }

        public Group GetGroup(string groupCd)
        {
            return GetSingle<Group>(groupCd, true);
        }

        public void InsertGroupRole(SaveDataModel inputObject)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = new GroupRole();
            entity.GroupCd = inputObject.GroupCd;
            entity.RoleCd = inputObject.RoleCd;
            entity.CreateUser = PageHelper.UserName;
            entity.CreateDate = currentDate;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
            entity.DeleteFlag = inputObject.DeleteFlag;

            EntityManager.GroupRoles.InsertOnSubmit(entity);

            // Submit
            EntityManager.SubmitChanges();
        }
    }
}