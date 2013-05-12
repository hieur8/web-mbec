using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Dao
{
    public class AdminBannerListDao : AbstractDao
    {
        public IList<Banner> GetListBanners()
        {
            // Get value
            var listResult = from tbl in EntityManager.Banners
                             where tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl;

            // Return value
            return listResult.ToList();
        }
    }
}