using System;
using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;

namespace MiBo.Domain.Dao
{
    public class AdminGroupListDao : AbstractDao
    {
        public IList<Group> GetListGroups()
        {
            // Get value
            var listResult = from tbl in EntityManager.Groups
                             orderby tbl.SortKey ascending
                             select tbl;

            // Return value
            return listResult.ToList();
        }

        public bool IsExistGroup(string groupCd)
        {
            return IsExist<Group>(groupCd, true);
        }

        public void UpdateGroup(Group param)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Set item
            var entity = GetSingle<Group>(param.GroupCd, true);
            entity.GroupName = param.GroupName;
            entity.SortKey = param.SortKey;
            entity.DeleteFlag = param.DeleteFlag;
            entity.UpdateUser = PageHelper.UserName;
            entity.UpdateDate = currentDate;
        }
    }
}