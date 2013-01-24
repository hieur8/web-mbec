using System.Collections.Generic;
using System.Linq;

namespace MiBo.Domain.Common.Dao
{
    public class MCodeComDao : AbstractDao
    {
        /// <summary>
        /// Get code name
        /// </summary>
        /// <param name="codeGroupCd">CodeGroupCd</param>
        /// <param name="codeCd">codeCd</param>
        /// <returns>CodeName</returns>
        public string GetCodeName(string codeGroupCd, string codeCd)
        {
            var result = from tbl in EntityManager.MCodes
                         where tbl.CodeGroupCd == codeGroupCd
                               && tbl.CodeCd == codeCd
                               && tbl.DeleteFlag == false
                         select tbl.CodeName;

            return result.SingleOrDefault();
        }

        /// <summary>
        /// Get single master code
        /// </summary>
        /// <param name="codeGroupCd">CodeGroupCd</param>
        /// <param name="codeCd">CodeCd</param>
        /// <returns>MCode</returns>
        public MCode GetSingle(string codeGroupCd, string codeCd)
        {
            var listResult = from tbl in EntityManager.MCodes
                             where tbl.CodeGroupCd == codeGroupCd
                                   && tbl.CodeCd == codeCd
                             select tbl;

            return listResult.SingleOrDefault();
        }

        /// <summary>
        /// Get list code
        /// </summary>
        /// <param name="codeGroupCd">CodeGroupCd</param>
        /// <param name="skipCodes">SkipCodes</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>IList<MCode></returns>
        public IList<MCode> GetListCode(string codeGroupCd, string[] skipCodes, bool ignoreDeleteFlag)
        {
            var listResult = from tbl in EntityManager.MCodes
                             where tbl.CodeGroupCd == codeGroupCd
                                   && (tbl.DeleteFlag == false || ignoreDeleteFlag)
                                   && skipCodes.Contains(tbl.CodeCd) == false
                             orderby tbl.UpdateDate ascending
                             select tbl;

            return listResult.ToList();
        }

        /// <summary>
        /// Check exist code
        /// </summary>
        /// <param name="codeGroupCd">CodeGroupCd</param>
        /// <param name="codeCd">CodeCd</param>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>True/False</returns>
        public bool IsExist(string codeGroupCd, string codeCd, bool ignoreDeleteFlag)
        {
            var result = from tbl in EntityManager.MCodes
                         where tbl.CodeGroupCd == codeGroupCd
                               && tbl.CodeCd == codeCd
                               && (tbl.DeleteFlag == false || ignoreDeleteFlag)
                         select tbl;

            var count = result.LongCount();

            return count == decimal.One;
        }
    }
}