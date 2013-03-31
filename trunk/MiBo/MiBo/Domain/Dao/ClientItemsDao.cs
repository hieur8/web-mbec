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
        public bool IsExistItem(string itemCd)
        {
            return IsExist<Item>(itemCd, false);
        }

        public IList<Offer> GetListOffers()
        {
            // Get sysdate
            var currentDate = DateTime.Now;

            // Get value
            var listResult = from tbl in EntityManager.Offers
                             where tbl.StartDate <= currentDate
                             && tbl.EndDate > currentDate
                             && tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl;

            // Return value
            return listResult.ToList();
        }

        public IList<Item> GetListItems(InitDataModel inputObject)
        {
            if (inputObject.ShowCd == Logics.CD_SHOW_ITEMS_NEW)
                return GetListNewItems();
            if (inputObject.ShowCd == Logics.CD_SHOW_ITEMS_OFFER)
                return GetListOfferItems();
            if (inputObject.ShowCd == Logics.CD_SHOW_ITEMS_HOT)
                return GetListHotItems();

            // Get price
            var price = (from tbl in EntityManager.Prices
                             where tbl.PriceCd == inputObject.PriceCd
                             && tbl.DeleteFlag == false
                             select tbl).SingleOrDefault();
            if (price == null) price = new Price();

            var listItemOfferByPrice = from tbl in GetListOffers()
                     where tbl.OfferDiv == Logics.CD_OFFER_DIV_DISCOUNT
                     && EntityManager.Items.Any(sub => sub.ItemCd == tbl.ItemCd
                         && decimal.Subtract(sub.SalesPrice.Value, decimal.Multiply(sub.SalesPrice.Value, tbl.Percent.Value / 100)) >= price.PriceStart
                         && (decimal.Subtract(sub.SalesPrice.Value, decimal.Multiply(sub.SalesPrice.Value, tbl.Percent.Value / 100)) < price.PriceEnd 
                         || price.PriceDiv == Logics.CD_PRICE_DIV_MORE))
                     select tbl.ItemCd;

            var listResult = from tbl in EntityManager.Items
                             where (tbl.ItemName.Contains(inputObject.SearchText)
                             || tbl.ItemSearchName.Contains(inputObject.SearchText)
                             || tbl.Category.CategoryName.Contains(inputObject.SearchText)
                             || tbl.Category.CategorySearchName.Contains(inputObject.SearchText)
                             || tbl.Brand.BrandName.Contains(inputObject.SearchText)
                             || tbl.Brand.BrandSearchName.Contains(inputObject.SearchText)
                             || DataCheckHelper.IsNull(inputObject.SearchText))
                             && (tbl.CategoryCd == inputObject.CategoryCd 
                             || DataCheckHelper.IsNull(inputObject.CategoryCd))
                             && (tbl.AgeCd == inputObject.AgeCd 
                             || DataCheckHelper.IsNull(inputObject.AgeCd))
                             && (tbl.GenderCd == inputObject.GenderCd 
                             || DataCheckHelper.IsNull(inputObject.GenderCd))
                             && (tbl.BrandCd == inputObject.BrandCd 
                             || DataCheckHelper.IsNull(inputObject.BrandCd))
                             && (DataCheckHelper.IsNull(inputObject.PriceCd)
                             || (!(from sub1 in GetListOffers()
                                   where sub1.OfferDiv == Logics.CD_OFFER_DIV_DISCOUNT
                                   select sub1.ItemCd).Contains(tbl.ItemCd)
                                   && tbl.SalesPrice >= price.PriceStart
                                   && (tbl.SalesPrice < price.PriceEnd
                                   || price.PriceDiv == Logics.CD_PRICE_DIV_MORE))
                             || listItemOfferByPrice.Contains(tbl.ItemCd))
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

        public string GetCategoryName(string categoryCd)
        {
            var listResult = from tbl in EntityManager.Categories
                             where tbl.CategoryCd == categoryCd
                             && tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl.CategoryName;

            return listResult.SingleOrDefault();
        }

        public string GetBrandName(string brandCd)
        {
            var listResult = from tbl in EntityManager.Brands
                             where tbl.BrandCd == brandCd
                             && tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl.BrandName;

            return listResult.SingleOrDefault();
        }

        public string GetAgeName(string ageCd)
        {
            var listResult = from tbl in EntityManager.Ages
                             where tbl.AgeCd == ageCd
                             && tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl.AgeName;

            return listResult.SingleOrDefault();
        }

        public string GetGenderName(string genderCd)
        {
            var listResult = from tbl in EntityManager.Genders
                             where tbl.GenderCd == genderCd
                             && tbl.DeleteFlag == false
                             orderby tbl.SortKey ascending
                             select tbl.GenderName;

            return listResult.SingleOrDefault();
        }

    }
}