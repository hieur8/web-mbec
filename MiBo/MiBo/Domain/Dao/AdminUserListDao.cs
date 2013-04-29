using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Admin.UserList;

namespace MiBo.Domain.Dao
{
    public class AdminUserListDao : AbstractDao
    {
        public IList<User> GetListUsers()
        {
            // Get value
            var listResult = from tbl in EntityManager.Users
                             where tbl.UserCd != PageHelper.UserCd
                             orderby tbl.UpdateDate ascending
                             select tbl;

            // Return value
            return listResult.ToList();
        }

        public IList<User> GetListUsers(FilterDataModel inputObject)
        {
            // Get value
            var listResult = from tbl in EntityManager.Users
                             where tbl.UserCd != PageHelper.UserCd
                             && (tbl.Email.Contains(inputObject.Email) || DataCheckHelper.IsNull(inputObject.Email))
                             && (tbl.FullName.Contains(inputObject.FullName) || DataCheckHelper.IsNull(inputObject.FullName))
                             && (tbl.CityCd == inputObject.CityCd || DataCheckHelper.IsNull(inputObject.CityCd))
                             && ((from sub in tbl.UserGroups select sub.GroupCd).Contains(inputObject.GroupCd)
                                 || DataCheckHelper.IsNull(inputObject.GroupCd))
                             && (tbl.DeleteFlag == inputObject.DeleteFlag || DataCheckHelper.IsNull(inputObject.DeleteFlag))
                             orderby tbl.UpdateDate ascending
                             select tbl;

            // Return value
            return listResult.ToList();
        }
    }
}