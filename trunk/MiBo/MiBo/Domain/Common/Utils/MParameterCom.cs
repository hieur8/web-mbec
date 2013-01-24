using System;
using System.Collections.Generic;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;

namespace MiBo.Domain.Common.Utils
{
    public class MParameterCom
    {
        private readonly MParameterComDao _comDao;
        public MParameterCom() { _comDao = new MParameterComDao(); }

        /// <summary>
        /// Get parameter type
        /// </summary>
        /// <param name="paramCd">ParamCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>Parameter type</returns>
        public string GetType(string paramCd, bool ignoreDeleteFlag)
        {
            // Check param
            if (DataCheckHelper.IsNull(paramCd))
                throw new ParamInvalidException();

            //Return value
            return _comDao.GetType(paramCd, ignoreDeleteFlag);
        }

        /// <summary>
        /// Get parameter value (String)
        /// </summary>
        /// <param name="paramCd">ParamCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>Parameter value</returns>
        public string GetString(string paramCd, bool ignoreDeleteFlag)
        {
            // Check param
            if (DataCheckHelper.IsNull(paramCd))
                throw new ParamInvalidException();

            //Return value
            return _comDao.GetString(paramCd, ignoreDeleteFlag);
        }

        /// <summary>
        /// Get parameter value (Number)
        /// </summary>
        /// <param name="paramCd">ParamCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>Parameter value</returns>
        public decimal? GetNumber(string paramCd, bool ignoreDeleteFlag)
        {
            // Check param
            if (DataCheckHelper.IsNull(paramCd))
                throw new ParamInvalidException();

            //Return value
            return _comDao.GetNumber(paramCd, ignoreDeleteFlag);
        }

        /// <summary>
        /// Get parameter value (Date)
        /// </summary>
        /// <param name="paramCd">ParamCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>Parameter value</returns>
        public DateTime? GetDate(string paramCd, bool ignoreDeleteFlag)
        {
            // Check param
            if (DataCheckHelper.IsNull(paramCd))
                throw new ParamInvalidException();

            //Return value
            return _comDao.GetDate(paramCd, ignoreDeleteFlag);
        }

        /// <summary>
        /// Check exist
        /// </summary>
        /// <param name="paramCd">ParamCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>True/False</returns>
        public bool IsExist(string paramCd, bool ignoreDeleteFlag)
        {
            // Check param
            if (DataCheckHelper.IsNull(paramCd))
                throw new ParamInvalidException();

            //Return value
            return _comDao.IsExist(paramCd, ignoreDeleteFlag);
        }

        /// <summary>
        /// Get single master parameter
        /// </summary>
        /// <param name="paramCd">ParamCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>MParameter</returns>
        public MParameter GetSingle(string paramCd, bool ignoreDeleteFlag)
        {
            // Check param
            if (DataCheckHelper.IsNull(paramCd))
                throw new ParamInvalidException();

            //Return value
            return _comDao.GetSingle(paramCd, ignoreDeleteFlag);
        }

        /// <summary>
        /// Get list master parameter
        /// </summary>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List master parameter</returns>
        public List<MParameter> GetList(bool ignoreDeleteFlag)
        {
            //Return value
            return _comDao.GetList(ignoreDeleteFlag);
        }

        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="param">Entity</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        public void Update(MParameter entity, bool ignoreDeleteFlag)
        {
            // Check param
            if (DataCheckHelper.IsNull(entity.ParamCd))
                throw new ParamInvalidException();

            //Update value
            _comDao.Update(entity, ignoreDeleteFlag);
        }
    }
}