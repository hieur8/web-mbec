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

        /// <summary>
        /// Get list category
        /// </summary>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List category</returns>
        public IEnumerable<Category> GetListCategory(bool ignoreDeleteFlag)
        {
            var listResult = GetList<Category>(ignoreDeleteFlag);
            if (listResult == null) listResult = new List<Category>();
            return listResult;
        }

        /// <summary>
        /// Get list age
        /// </summary>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List age</returns>
        public IEnumerable<Age> GetListAge(bool ignoreDeleteFlag)
        {
            var listResult = GetList<Age>(ignoreDeleteFlag);
            if (listResult == null) listResult = new List<Age>();
            return listResult;
        }

        /// <summary>
        /// Get list gender
        /// </summary>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List gender</returns>
        public IEnumerable<Gender> GetListGender(bool ignoreDeleteFlag)
        {
            var listResult = GetList<Gender>(ignoreDeleteFlag);
            if (listResult == null) listResult = new List<Gender>();
            return listResult;
        }

        /// <summary>
        /// Get list brand
        /// </summary>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List brand</returns>
        public IEnumerable<Brand> GetListBrand(bool ignoreDeleteFlag)
        {
            var listResult = GetList<Brand>(ignoreDeleteFlag);
            if (listResult == null) listResult = new List<Brand>();
            return listResult;
        }

        /// <summary>
        /// Get list country
        /// </summary>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List country</returns>
        public IEnumerable<Country> GetListCountry(bool ignoreDeleteFlag)
        {
            var listResult = GetList<Country>(ignoreDeleteFlag);
            if (listResult == null) listResult = new List<Country>();
            return listResult;
        }

        /// <summary>
        /// Get list unit
        /// </summary>
        /// <param name="ignoreDeleteFlag">IgnoreDeleteFlag</param>
        /// <returns>List unit</returns>
        public IEnumerable<Unit> GetListUnit(bool ignoreDeleteFlag)
        {
            var listResult = GetList<Unit>(ignoreDeleteFlag);
            if (listResult == null) listResult = new List<Unit>();
            return listResult;
        }
    }
}