using System;
using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Model.Client.Items;

namespace MiBo.Domain.Dao
{
    public class ClientItemsDao : AbstractDao
    {
        public IList<Item> GetListItems(InitDataModel inputObject)
        {
            if (inputObject.IsNew.Value)
                return GetListNewItems();
            if (inputObject.IsOffer.Value)
                return GetListOfferItems();
            if (inputObject.IsHot.Value)
                return GetListHotItems();

            // Get price
            var price = (from tbl in EntityManager.Prices
                             where tbl.PriceCd == inputObject.PriceCd
                             && tbl.DeleteFlag == false
                             select tbl).SingleOrDefault();

            var listResult = from tbl in EntityManager.Items
                             where (tbl.CategoryCd == inputObject.CategoryCd 
                             || DataCheckHelper.IsNull(inputObject.CategoryCd))
                             && (tbl.AgeCd == inputObject.AgeCd 
                             || DataCheckHelper.IsNull(inputObject.AgeCd))
                             && (tbl.GenderCd == inputObject.GenderCd 
                             || DataCheckHelper.IsNull(inputObject.GenderCd))
                             && (tbl.BrandCd == inputObject.BrandCd 
                             || DataCheckHelper.IsNull(inputObject.BrandCd))
                             && (DataCheckHelper.IsNull(inputObject.PriceCd) 
                             || (from sub in tbl.Packs 
                                 where sub.SalesPrice >= price.PriceStart
                                 && (sub.SalesPrice < price.PriceEnd 
                                 || price.PriceDiv == Logics.CD_PRICE_DIV_MORE)
                                 select sub.ItemCd).Contains(tbl.ItemCd))
                             && tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl;

            return listResult.ToList();

        }

        public IList<Item> GetListNewItems()
        {
            var listResult = from tbl in EntityManager.Items
                             where tbl.ItemDiv == Logics.CD_ITEM_DIV_NEW
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

            return listResult.Take(10).ToList();
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