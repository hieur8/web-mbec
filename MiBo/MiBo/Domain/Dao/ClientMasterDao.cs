using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Constants;

namespace MiBo.Domain.Dao
{
    public class ClientMasterDao : AbstractDao
    {
        public IList<Category> GetListCategories(string categoryDiv)
        {
            var listResult = from tbl in EntityManager.Categories
                             where tbl.CategoryDiv == categoryDiv
                             && tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl;

            return listResult.ToList();
        }

        /// <summary>
        /// Get list age
        /// </summary>
        /// <returns>List age</returns>
        public IList<Age> GetListAge()
        {
            var listResult = from tbl in EntityManager.Ages
                             where tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl;

            return listResult.ToList();
        }

        /// <summary>
        /// Get list gender
        /// </summary>
        /// <returns>List gender</returns>
        public IList<Gender> GetListGender()
        {
            var listResult = from tbl in EntityManager.Genders
                             where tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl;

            return listResult.ToList();
        }

        /// <summary>
        /// Get list brand
        /// </summary>
        /// <returns>List brand</returns>
        public IList<Brand> GetListBrand()
        {
            var listResult = from tbl in EntityManager.Brands
                             where tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl;

            return listResult.ToList();
        }

        /// <summary>
        /// Get list country
        /// </summary>
        /// <returns>List country</returns>
        public IList<Country> GetListCountry()
        {
            var listResult = from tbl in EntityManager.Countries
                             where tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl;

            return listResult.ToList();
        }
    }
}