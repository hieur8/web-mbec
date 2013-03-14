using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Exceptions;

namespace MiBo.Domain.Common.Utils
{
    public class CompanyCom
    {
        private readonly CompanyComDao _comDao;
        public CompanyCom() { _comDao = new CompanyComDao(); }

        /// <summary>
        /// Get CompanyInfo
        /// </summary>
        /// <param name="infoCd">InfoCd</param>
        /// <returns>CompanyInfo</returns>
        public CompanyInfo GetInfo(string infoCd)
        {
            // Check param
            if (DataCheckHelper.IsNull(infoCd))
                throw new ParamInvalidException();

            //Return value
            return _comDao.GetInfo(infoCd);
        }

        /// <summary>
        /// Get List
        /// </summary>
        /// <returns>List CompanyInfo</returns>
        public IList<CompanyInfo> GetList()
        {
            //Return value
            return _comDao.GetList();
        }

        /// <summary>
        /// Get info name
        /// </summary>
        /// <param name="infoCd">InfoCd</param>
        /// <returns>InfoName</returns>
        public string GetName(string infoCd)
        {
            // Check param
            if (DataCheckHelper.IsNull(infoCd))
                throw new ParamInvalidException();

            //Return value
            return _comDao.GetName(infoCd);
        }

        /// <summary>
        /// Get InfoValue
        /// </summary>
        /// <param name="infoCd">InfoCd</param>
        /// <returns>InfoValue</returns>
        public string GetValue(string infoCd)
        {
            // Check param
            if (DataCheckHelper.IsNull(infoCd))
                throw new ParamInvalidException();

            //Return value
            return _comDao.GetValue(infoCd);
        }
    }
}