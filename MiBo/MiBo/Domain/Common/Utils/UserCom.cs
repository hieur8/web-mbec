using System;
using System.Collections.Generic;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;

namespace MiBo.Domain.Common.Utils
{
    public class UserCom
    {
        private readonly UserComDao _comDao;
        public UserCom() { _comDao = new UserComDao(); }

        /// <summary>
        /// Check exist user
        /// </summary>
        /// <param name="userCd">UserCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>True/False</returns>
        public bool IsExist(Guid userCd, bool ignoreDeleteFlag)
        {
            // Local variable declaration
            var result = true;

            // Check param
            if (DataCheckHelper.IsNull(userCd))
                throw new ParamInvalidException();

            // Get infomation
            result = _comDao.IsExist(userCd, ignoreDeleteFlag);

            //Return value
            return result;
        }

        /// <summary>
        /// Get single user
        /// </summary>
        /// <param name="userCd">UserCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>User</returns>
        public User GetSingle(Guid userCd, bool ignoreDeleteFlag)
        {
            // Local variable declaration
            User result = null;

            // Check param
            if (DataCheckHelper.IsNull(userCd))
                throw new ParamInvalidException();

            // Get infomation
            result = _comDao.GetSingle(userCd, ignoreDeleteFlag);

            // Return value
            return result;
        }

        /// <summary>
        /// Get single user with username and password
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <returns>User</returns>
        public User GetSingle(string userName, string password)
        {
            // Local variable declaration
            User result = null;
            string hashPass = string.Empty;

            // Check param
            if (DataCheckHelper.IsNull(userName)
                || DataCheckHelper.IsNull(password))
                throw new ParamInvalidException();

            // Get hash password
            hashPass = DataHelper.GetMd5Hash(password);

            // Get infomation
            result = _comDao.GetSingle(userName, hashPass);

            // Return value
            return result;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <param name="userCd">UserCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List users</returns>
        public IList<User> GetList(Guid userCd, bool ignoreDeleteFlag)
        {
            // Local variable declaration
            IList<User> resultList = null;

            // Check param
            if (DataCheckHelper.IsNull(userCd))
                throw new ParamInvalidException();

            // Get infomation
            resultList = _comDao.GetList(userCd, ignoreDeleteFlag);

            // Return value
            return resultList;
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="userCd">UserCd</param>
        /// <returns>True/False</returns>
        public bool Authenticate(Guid userCd)
        {
            // Check param
            if (DataCheckHelper.IsNull(userCd))
                return false;

            // Return value
            return GetSingle(userCd, false) != null;
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <returns>True/False</returns>
        public bool Authenticate(string userName, string password)
        {
            // Check param
            if (DataCheckHelper.IsNull(userName)
                || DataCheckHelper.IsNull(password))
                return false;

            // Return value
            return GetSingle(userName, password) != null;
        }

        /// <summary>
        /// Check valid password
        /// </summary>
        /// <param name="userCd">UserCd</param>
        /// <param name="password">Password</param>
        /// <returns>True/False</returns>
        public bool IsValidPassword(Guid userCd, string password)
        {
            // Local variable declaration
            var result = true;
            User account = null;

            // Check param
            if (DataCheckHelper.IsNull(userCd)
                || DataCheckHelper.IsNull(password))
                throw new ParamInvalidException();

            // Get information
            var passHash = DataHelper.GetMd5Hash(password);
            account = GetSingle(userCd, false);

            if (account == null || passHash.Equals(account.Password) == false)
            {
                result = false;
            }

            // Return value
            return result;
        }

        /// <summary>
        /// Update password
        /// </summary>
        /// <param name="userCd">userCd</param>
        /// <param name="userName">UserNname</param>
        /// <param name="password">Data</param>
        public void UpdatePassword(Guid userCd, string password, string updateUser, bool ignoreDeleteFlag)
        {
            // Local variable declaration
            User param = null;

            // Variable initialize
            param = new User();

            // Check param
            if (DataCheckHelper.IsNull(userCd)
                || DataCheckHelper.IsNull(password)
                || DataCheckHelper.IsNull(updateUser))
                throw new ParamInvalidException();

            // Get system date
            var currentDate = DateTime.Now;

            // Set value
            param.UserCd = userCd;
            param.Password = DataHelper.GetMd5Hash(password);
            param.UpdateUser = updateUser;
            param.UpdateDate = currentDate;

            // Update value
            _comDao.UpdatePassword(param, ignoreDeleteFlag);
        }

        /// <summary>
        /// Check exist email
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>True/False</returns>
        public bool IsExistEmail(String email, bool ignoreDeleteFlag)
        {
            // Local variable declaration
            var result = true;

            // Check param
            if (DataCheckHelper.IsNull(email))
                throw new ParamInvalidException();

            // Get infomation
            result = _comDao.IsExistEmail(email, ignoreDeleteFlag);

            //Return value
            return result;
        }

        public void registerUser(User param)
        {
            DateTime dateNow = DateTime.Now;
            param.Password = DataHelper.GetMd5Hash(param.Password);
            param.CreateUser = "init";
            param.CreateDate = dateNow;
            param.UpdateUser = "init";
            param.UpdateDate = dateNow;
            param.DeleteFlag = false;
            _comDao.EntityManager.Users.InsertOnSubmit(param);
            // Submit
            _comDao.EntityManager.SubmitChanges();
        }
    }
}