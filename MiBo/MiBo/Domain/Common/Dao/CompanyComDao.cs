using System.Collections.Generic;
using System.Linq;

namespace MiBo.Domain.Common.Dao
{
    public class CompanyComDao : AbstractDao
    {
        /// <summary>
        /// Get CompanyInfo
        /// </summary>
        /// <param name="infoCd">InfoCd</param>
        /// <returns>CompanyInfo</returns>
        public CompanyInfo GetInfo(string infoCd)
        {
            var result = from tbl in EntityManager.CompanyInfos
                         where tbl.InfoCd == infoCd
                         select tbl;

            return result.SingleOrDefault();
        }

        /// <summary>
        /// Get List
        /// </summary>
        /// <returns>List CompanyInfo</returns>
        public IList<CompanyInfo> GetList()
        {
            var result = from tbl in EntityManager.CompanyInfos
                         select tbl;

            return result.ToList();
        }

        /// <summary>
        /// Get info name
        /// </summary>
        /// <param name="infoCd">InfoCd</param>
        /// <returns>InfoName</returns>
        public string GetName(string infoCd)
        {
            var result = from tbl in EntityManager.CompanyInfos
                         where tbl.InfoCd == infoCd
                         select tbl.InfoName;

            return result.SingleOrDefault();
        }

        /// <summary>
        /// Get info value
        /// </summary>
        /// <param name="infoCd">InfoCd</param>
        /// <returns>InfoValue</returns>
        public string GetValue(string infoCd)
        {
            var result = from tbl in EntityManager.CompanyInfos
                         where tbl.InfoCd == infoCd
                         select tbl.InfoValue;

            return result.SingleOrDefault();
        }
    }
}