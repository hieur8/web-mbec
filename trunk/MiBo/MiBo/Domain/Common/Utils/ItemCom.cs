using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Constants;

namespace MiBo.Domain.Common.Utils
{
    public class ItemCom
    {
        private readonly ItemComDao _comDao;
        public ItemCom() { _comDao = new ItemComDao(); }

        /// <summary>
        /// Update viewer
        /// </summary>
        /// <param name="itemCd">ItemCd</param>
        public void UpdateViewer(string itemCd)
        {
            // Check param
            if (DataCheckHelper.IsNull(itemCd))
                throw new ParamInvalidException();

            // Update
            _comDao.UpdateViewer(itemCd);
        }

        /// <summary>
        /// Get offer price
        /// </summary>
        /// <param name="salesPrice">SalesPrice</param>
        /// <param name="offerPercent">oOfferPercent</param>
        /// <returns>Offer price</returns>
        public decimal? GetOfferPrice(decimal? salesPrice, decimal? offerPercent)
        {
            // Local variable declaration
            var priceOffer = decimal.Zero;

            // Check param
            if (DataCheckHelper.IsNull(salesPrice)
                || DataCheckHelper.IsNull(offerPercent))
                throw new ParamInvalidException();

            // Get infomation
            priceOffer = decimal.Multiply(salesPrice.Value, offerPercent.Value / 100);

            // Return value
            return decimal.Subtract(salesPrice.Value, priceOffer);
        }

        /// <summary>
        /// Convert item to item model
        /// </summary>
        /// <param name="item">Item</param>
        /// <returns>Item model</returns>
        public ItemModel ToItemModel(Item item)
        {
            // Local variable declaration
            ItemModel itemModel = null;

            // Variable initialize
            itemModel = new ItemModel();

            // Copy infomation
            DataHelper.CopyObject(item, itemModel);

            // Get value
            var salesPrice = _comDao.GetSalesPrice(itemModel.ItemCd, itemModel.UnitCd);
            var itemImage = _comDao.GetItemImage(itemModel.ItemCd);

            // Set value
            itemModel.SalesPrice = salesPrice;
            itemModel.ItemImage = itemImage;

            // Check offer
            if (_comDao.HasOffer(itemModel.ItemCd))
            {
                var offer = _comDao.GetOffer(itemModel.ItemCd);

                itemModel.OfferDiv = offer.OfferDiv;
                itemModel.ItemDiv = Logics.TEXT_BLANK;

                if (itemModel.OfferDiv == Logics.CD_OFFER_DIV_DISCOUNT)
                {
                    itemModel.SalesPriceOld = salesPrice;
                    itemModel.SalesPrice = GetOfferPrice(salesPrice, offer.Percent);
                }
                else
                {
                    itemModel.ListOfferItems = offer.OfferItems;
                }
            }

            // Return value
            return itemModel;
        }

        /// <summary>
        /// Convert list item to list item model
        /// </summary>
        /// <param name="listItem">List item</param>
        /// <returns>List item model</returns>
        public IList<ItemModel> ToListItemModel(IList<Item> listItem)
        {
            // Local variable declaration
            IList<ItemModel> listResult = null;
            ItemModel itemModel = null;

            // Variable initialize
            listResult = new List<ItemModel>();

            // Get infomation
            foreach (var item in listItem)
            {
                itemModel = ToItemModel(item);
                listResult.Add(itemModel);
            }

            // Return value
            return listResult;
        }
    }
}