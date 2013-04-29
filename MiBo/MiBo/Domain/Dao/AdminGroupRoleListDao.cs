using System;
using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;

namespace MiBo.Domain.Dao
{
    public class AdminGroupRoleListDao : AbstractDao
    {
        public IList<GroupRole> GetListGroupRoles(string groupCd)
        {
            // Get value
            var listResult = from tbl in EntityManager.GroupRoles
                             where tbl.GroupCd == groupCd
                             orderby tbl.UpdateDate ascending
                             select tbl;

            // Return value
            return listResult.ToList();
        }

        public bool IsExistGroup(string groupCd)
        {
            return IsExist<Group>(groupCd, true);
        }

        public bool IsExistGroupRole(string groupCd, string roleCd)
        {
            return IsExist<GroupRole>(new string[] { groupCd, roleCd }, true);
        }

        public void UpdateGroupRole(GroupRole param)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = GetSingle<GroupRole>(new string[] { param.GroupCd, param.RoleCd }, true);
            entity.DeleteFlag = param.DeleteFlag;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
        }
    }
}