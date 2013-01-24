using System;
using System.Linq;

namespace MiBo.Domain.Common.Dao
{
    public class ItemComDao : AbstractDao
    {
        public bool HasOffer(string itemCd)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Get value
            var listResult = from tbl in EntityManager.Offers
                             where tbl.ItemCd == itemCd
                             && tbl.StartDate <= currentDate
                             && tbl.EndDate > currentDate
                             && tbl.DeleteFlag == false
                             orderby tbl.SortKey descending
                             select tbl;

            // Get long count
            var count = listResult.LongCount();

            // Return value
            return count >= decimal.One;
        }

        public Offer GetOffer(string itemCd)
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Get value
            var listResult = from tbl in EntityManager.Offers
                             where tbl.ItemCd == itemCd
                             && tbl.StartDate <= currentDate
                             && tbl.EndDate > currentDate
                             && tbl.DeleteFlag == false
                             orderby tbl.SortKey descending
                             select tbl;

            // Return value
            return listResult.Take(1).SingleOrDefault();
        }

        public void UpdateViewer(string itemCd)
        {
            // Get entity
            var entity = GetSingle<Item>(itemCd, false);

            // Setting value
            entity.Viewer += 1;

            // Submit
            EntityManager.SubmitChanges();
        }
    }
}