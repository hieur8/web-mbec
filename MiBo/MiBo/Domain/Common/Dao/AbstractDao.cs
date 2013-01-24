using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using Resources;

namespace MiBo.Domain.Common.Dao
{
    public abstract class AbstractDao
    {
        public EntitiesDataContext EntityManager { get; set; }
        private const string DELETE_FLAG = "DeleteFlag";

        /// <summary>
        /// AbstractDao
        /// </summary>
        protected AbstractDao()
        {
            EntityManager = new EntitiesDataContext();

            if (EntityManager.DatabaseExists() == false)
            {
                var message = MessageHelper.GetMessageFatal(
                    "F_MSG_00001", Messages.F_MSG_00001_T, Messages.F_MSG_00001_H);
                throw new SysRuntimeException(message);
            }
        }

        /// <summary>
        /// Get expression (SelectSingle)
        /// </summary>
        /// <typeparam name="T">The entity object</typeparam>
        /// <param name="keys">The values of primary key</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>Expression</returns>
        private Expression<Func<T, bool>> ExpressionSelectSingle<T>(string[] keys, bool ignoreDeleteFlag) where T : class
        {
            // Get Type
            var type = typeof(T);
            // Declare table
            var param = Expression.Parameter(type, "tbl");
            // Declare member expression
            var meKeys = new List<MemberExpression>();
            var meDeleteFlag = Expression.Property(param, DELETE_FLAG);
            // Get table type
            var userMeta = EntityManager.Mapping.GetTable(type);
            var dataMembers = userMeta.RowType.PersistentDataMembers;
            // Add key members field
            foreach (var key in dataMembers.Where(o => o.IsPrimaryKey))
            {
                meKeys.Add(Expression.Property(param, key.Name));
            }
            // Declare constant expression
            var ceKeys = new List<ConstantExpression>();
            var ceDeleteFlag = Expression.Constant(false, typeof(bool?));
            var ceIgnoreDeleteFlag = Expression.Constant(ignoreDeleteFlag);
            // Add constant keys
            foreach (var key in keys)
            {
                ceKeys.Add(Expression.Constant(key));
            }
            // Declare binary expression
            var beKeys = new List<BinaryExpression>();
            var beDeleteFlag = Expression.Equal(meDeleteFlag, ceDeleteFlag);
            // Add binary keys
            for (int i = 0; i < meKeys.Count; i++)
            {
                beKeys.Add(Expression.Equal(meKeys[i], ceKeys[i]));
            }
            // Expression keys
            BinaryExpression exKeys = null;
            if (beKeys.Count > 0)
                exKeys = GetExpressionKey(beKeys, beKeys.Count - 1);
            // Expression deleteFlag
            var exDeleteFlag = Expression.Or(beDeleteFlag, ceIgnoreDeleteFlag);
            // Expression
            BinaryExpression ex = null;
            if (exKeys != null) ex = Expression.And(exKeys, exDeleteFlag);
            else ex = exDeleteFlag;
            // Return value
            return Expression.Lambda<Func<T, bool>>(ex, param);
        }

        /// <summary>
        /// Get expression key
        /// </summary>
        /// <param name="beKeys">List expression key</param>
        /// <param name="index">Index</param>
        /// <returns>Expression key</returns>
        private BinaryExpression GetExpressionKey(List<BinaryExpression> beKeys, int index)
        {
            // Check index
            if (index == 0)
                return beKeys[0];
            // Return value
            return Expression.And(beKeys[index], GetExpressionKey(beKeys, index - 1));
        }

        /// <summary>
        /// Get expression (SelectList)
        /// </summary>
        /// <typeparam name="T">The entity object</typeparam>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>Expression</returns>
        private Expression<Func<T, bool>> ExpressionSelectList<T>(bool ignoreDeleteFlag) where T : class
        {
            // Get Type
            var type = typeof(T);
            // Declare table
            var param = Expression.Parameter(type, "tbl");
            // Declare member expression
            var meDeleteFlag = Expression.Property(param, DELETE_FLAG);
            // Declare constant expression
            var ceDeleteFlag = Expression.Constant(false, typeof(bool?));
            var ceIgnoreDeleteFlag = Expression.Constant(ignoreDeleteFlag);
            // Declare binary expression
            var beDeleteFlag = Expression.Equal(meDeleteFlag, ceDeleteFlag);
            // Expression deleteFlag
            var exDeleteFlag = Expression.Or(beDeleteFlag, ceIgnoreDeleteFlag);
            // Expression
            var ex = exDeleteFlag;
            // Return value
            return Expression.Lambda<Func<T, bool>>(ex, param);
        }

        /// <summary>
        /// Check exist (T)
        /// </summary>
        /// <typeparam name="T">The entity object</typeparam>
        /// <param name="keys">The values of primary key</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>True/False</returns>
        public bool IsExist<T>(string[] keys, bool ignoreDeleteFlag) where T : class
        {
            // Get table
            var table = EntityManager.GetTable<T>();
            // Get expression (SelectSingle)
            var predicate = ExpressionSelectSingle<T>(keys, ignoreDeleteFlag);
            // Get long count
            var count = table.LongCount(predicate);
            // Return value
            return count >= decimal.One;
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
            return IsExist<T>(new string[] { key }, ignoreDeleteFlag);
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
            // Get table
            var table = EntityManager.GetTable<T>();
            // Get expression (SelectSingle)
            var predicate = ExpressionSelectSingle<T>(keys, ignoreDeleteFlag);
            // Return value
            return table.SingleOrDefault(predicate);
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
            // Get table
            var table = EntityManager.GetTable<T>();
            // Get expression (SelectList)
            var predicate = ExpressionSelectList<T>(ignoreDeleteFlag);
            // Return value
            return table.Where(predicate);
        }
    }
}