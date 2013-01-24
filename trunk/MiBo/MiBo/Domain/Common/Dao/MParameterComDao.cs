using System;
using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Constants;

namespace MiBo.Domain.Common.Dao
{
    public class MParameterComDao : AbstractDao
    {
        /// <summary>
        /// Get parameter type
        /// </summary>
        /// <param name="paramCd">ParamCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>ParamType</returns>
        public string GetType(string paramCd, bool ignoreDeleteFlag)
        {
            var result = from tbl in EntityManager.MParameters
                         where tbl.ParamCd == paramCd
                               && (tbl.DeleteFlag == false || ignoreDeleteFlag)
                         select tbl.ParamType;

            return result.SingleOrDefault();
        }

        /// <summary>
        /// Get parameter value (String)
        /// </summary>
        /// <param name="paramCd">ParamCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>ParamValue</returns>
        public string GetString(string paramCd, bool ignoreDeleteFlag)
        {
            var pt = GetType(paramCd, ignoreDeleteFlag);
            if (pt != Logics.PT_STRING)
                return string.Empty;

            var result = from tbl in EntityManager.MParameters
                         where tbl.ParamCd == paramCd
                               && (tbl.DeleteFlag == false || ignoreDeleteFlag)
                         select tbl.ParamValue;

            return result.SingleOrDefault();
        }

        /// <summary>
        /// Get parameter value (Number)
        /// </summary>
        /// <param name="paramCd">ParamCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>ParamValue</returns>
        public decimal? GetNumber(string paramCd, bool ignoreDeleteFlag)
        {
            var pt = GetType(paramCd, ignoreDeleteFlag);
            if (pt != Logics.PT_NUMBER)
                return null;

            var result = from tbl in EntityManager.MParameters
                         where tbl.ParamCd == paramCd
                               && (tbl.DeleteFlag == false || ignoreDeleteFlag)
                         select tbl.ParamValue;

            decimal val;
            if (decimal.TryParse(result.SingleOrDefault(), out val))
                return val;

            return null;
        }

        /// <summary>
        /// Get parameter value (Date)
        /// </summary>
        /// <param name="paramCd">ParamCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>ParamValue</returns>
        public DateTime? GetDate(string paramCd, bool ignoreDeleteFlag)
        {
            var pt = GetType(paramCd, ignoreDeleteFlag);
            if (pt != Logics.PT_DATE)
                return null;

            var result = from tbl in EntityManager.MParameters
                         where tbl.ParamCd == paramCd
                               && (tbl.DeleteFlag == false || ignoreDeleteFlag)
                         select tbl.ParamValue;

            DateTime val;
            if (DateTime.TryParse(result.SingleOrDefault(), out val))
                return val;

            return null;
        }

        /// <summary>
        /// Check exist
        /// </summary>
        /// <param name="paramCd">ParamCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>True/False</returns>
        public bool IsExist(string paramCd, bool ignoreDeleteFlag)
        {
            var result = from tbl in EntityManager.MParameters
                         where tbl.ParamCd == paramCd
                               && (tbl.DeleteFlag == false || ignoreDeleteFlag)
                         select tbl;

            var count = result.LongCount();

            return count == decimal.One;
        }

        /// <summary>
        /// Get single master parameter
        /// </summary>
        /// <param name="paramCd">ParamCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>MParameter</returns>
        public MParameter GetSingle(string paramCd, bool ignoreDeleteFlag)
        {
            var listResult = from tbl in EntityManager.MParameters
                             where tbl.ParamCd == paramCd
                                   && (tbl.DeleteFlag == false || ignoreDeleteFlag)
                             select tbl;

            return listResult.SingleOrDefault();
        }

        /// <summary>
        /// Get list master parameter
        /// </summary>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List master parameter</returns>
        public List<MParameter> GetList(bool ignoreDeleteFlag)
        {
            var listResult = from tbl in EntityManager.MParameters
                             where (tbl.DeleteFlag == false || ignoreDeleteFlag)
                             select tbl;

            return listResult.ToList();
        }

        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="param">Entity</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        public void Update(MParameter param, bool ignoreDeleteFlag)
        {
            // Get entity
            var entity = GetSingle(param.ParamCd, ignoreDeleteFlag);

            // Set value
            entity.ParamValue = param.ParamValue;
            entity.UpdateUser = param.UpdateUser;
            entity.UpdateDate = DateTime.Now;

            // Update
            EntityManager.SubmitChanges();
        }
    }
}