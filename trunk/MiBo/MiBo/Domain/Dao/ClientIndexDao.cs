using System;
using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Dao
{
    public class ClientIndexDao : AbstractDao
    {
        public IList<Banner> GetListBanners()
        {
            var listResult = from tbl in EntityManager.Banners
                             where tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl;

            return listResult.ToList();
        }

        public IList<Item> GetListNewItems()
        {
            var listResult = from tbl in EntityManager.Items
                             where tbl.ItemNew == Logics.CD_ITEM_NEW_ON
                             && tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl;

            return listResult.ToList();
        }

        public IList<Item> GetListHotItems()
        {
            var listResult = from tbl in EntityManager.Items
                             where tbl.DeleteFlag == false
                             orderby tbl.Viewer descending
                             select tbl;

            return listResult.Take(5).ToList();
        }

        public IList<Item> GetListOfferItems()
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Get list offers
            var listOffers = from tbl in EntityManager.Offers
                             where tbl.StartDate <= currentDate
                             && tbl.EndDate > currentDate
                             && tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl.ItemCd;

            // Get data
            var listResult = from tbl in EntityManager.Items
                             where listOffers.Contains(tbl.ItemCd)
                             && tbl.DeleteFlag == false
                             orderby tbl.Viewer descending
                             select tbl;

            // Return value
            return listResult.ToList();
        }
    }
}