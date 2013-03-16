using System;
using System.Collections.Generic;
using System.Linq;

namespace MiBo.Domain.Common.Dao
{
    public class UserComDao : AbstractDao
    {
        /// <summary>
        /// Check exist user
        /// </summary>
        /// <param name="userCd">UserCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>True/False</returns>
        public bool IsExist(Guid userCd, bool ignoreDeleteFlag)
        {
            var result = from tbl in EntityManager.Users
                         where tbl.UserCd == userCd
                         && (tbl.DeleteFlag == false || ignoreDeleteFlag)
                         select tbl;

            var count = result.LongCount();

            return count == decimal.One;
        }

        /// <summary>
        /// Get single user
        /// </summary>
        /// <param name="userCd">UserCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>User</returns>
        public User GetSingle(Guid userCd, bool ignoreDeleteFlag)
        {
            var listResult = from tbl in EntityManager.Users
                             where tbl.UserCd == userCd
                             && (tbl.DeleteFlag == false || ignoreDeleteFlag)
                             select tbl;

            return listResult.SingleOrDefault();
        }

        /// <summary>
        /// Get single user with username and password
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <returns>User</returns>
        public User GetSingle(string userName, string password)
        {
            var listResult = from tbl in EntityManager.Users
                             where tbl.Email == userName
                             && tbl.Password == password
                             && tbl.DeleteFlag == false
                             select tbl;

            return listResult.SingleOrDefault();
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <param name="userCd">UserCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List users</returns>
        public IList<User> GetList(Guid userCd, bool ignoreDeleteFlag)
        {
            var listResult = from tbl in EntityManager.Users
                             where tbl.UserCd == userCd
                                   && (tbl.DeleteFlag == false || ignoreDeleteFlag)
                             orderby tbl.UpdateDate descending
                             select tbl;

            return listResult.ToList();
        }

        /// <summary>
        /// Update password
        /// </summary>
        /// <param name="param">User</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        public void UpdatePassword(User param, bool ignoreDeleteFlag)
        {
            // Get account
            var entity = GetSingle(param.UserCd, ignoreDeleteFlag);

            // Setting value
            entity.Password = param.Password;
            entity.UpdateUser = param.UpdateUser;
            entity.UpdateDate = param.UpdateDate;

            // Submit
            EntityManager.SubmitChanges();
        }

        /// <summary>
        /// Check exist user
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>True/False</returns>
        public bool IsExistEmail(string email, bool ignoreDeleteFlag)
        {
            var result = from tbl in EntityManager.Users
                         where tbl.Email == email
                         && (tbl.DeleteFlag == false || ignoreDeleteFlag)
                         select tbl;

            var count = result.LongCount();

            return count == decimal.One;
        }

        /// <summary>
        /// Authenticate user in group
        /// </summary>
        /// <param name="userCd">UserCd</param>
        /// <param name="groupCd">GroupCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>True/False</returns>
        public bool AuthUserInGroups(Guid userCd, string groupCd, bool ignoreDeleteFlag)
        {
            var result = from tbl in EntityManager.UserGroups
                         where tbl.UserCd == userCd && tbl.GroupCd == groupCd
                         && (tbl.DeleteFlag == false || ignoreDeleteFlag)
                         select tbl;

            var count = result.LongCount();

            return count == decimal.One;
        }
    }
}