using System.Collections.Generic;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Common.Utils
{
    public class DataCom
    {
        private readonly DataComDao _comDao;
        public DataCom() { _comDao = new DataComDao(); }

        /// <summary>
        /// Check exist (T)
        /// </summary>
        /// <typeparam name="T">The entity object</typeparam>
        /// <param name="keys">The values of primary key</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>True/False</returns>
        public bool IsExist<T>(string[] keys, bool ignoreDeleteFlag) where T : class
        {
            // Local variable declaration
            var result = true;
            // Get infomation
            result = _comDao.IsExist<T>(keys, ignoreDeleteFlag);
            //Return value
            return result;
        }

        /// <summary>
        /// Get entity object (T)
        /// </summary>
        /// <typeparam name="T">The entity object</typeparam>
        /// <param name="keys">The values of primary key</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>Entity object</returns>
        public T GetSingle<T>(string[] keys, bool ignoreDeleteFlag) where T : class
        {
            // Local variable declaration
            T result = null;
            // Get infomation
            result = _comDao.GetSingle<T>(keys, ignoreDeleteFlag);
            // Return value
            return result;
        }

        /// <summary>
        /// Check exist (T)
        /// </summary>
        /// <typeparam name="T">The entity object</typeparam>
        /// <param name="key">The value of primary key</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>True/False</returns>
        public bool IsExist<T>(string key, bool ignoreDeleteFlag) where T : class
        {
            // Return value
            return IsExist<T>(new string[] { key }, ignoreDeleteFlag);
        }

        /// <summary>
        /// Get entity object (T)
        /// </summary>
        /// <typeparam name="T">The entity object</typeparam>
        /// <param name="key">The value of primary key</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>Entity object</returns>
        public T GetSingle<T>(string key, bool ignoreDeleteFlag) where T : class
        {
            // Return value
            return GetSingle<T>(new string[] { key }, ignoreDeleteFlag);
        }

        /// <summary>
        /// Get list entity object (T)
        /// </summary>
        /// <typeparam name="T">The entity object</typeparam>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List entity object</returns>
        public IEnumerable<T> GetList<T>(bool ignoreDeleteFlag) where T : class
        {
            // Return value
            return _comDao.GetList<T>(ignoreDeleteFlag);
        }
    }
}