using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;

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
            StorageFileCom storageFileCom = null;

            // Variable initialize
            itemModel = new ItemModel();
            storageFileCom = new StorageFileCom();

            // Copy infomation
            DataHelper.CopyObject(item, itemModel);

            // Get value
            var storageFile = storageFileCom.GetSingle(item.FileId, true);
            var itemImage = storageFile != null ? storageFile.FileName : "default.jpg";
            var storageFiles = storageFileCom.GetListActive(item.FileId, true);

            // Set value
            itemModel.ItemImage = itemImage;
            itemModel.ItemImages = storageFiles;
            itemModel.ListOfferItems = new List<OfferItem>();

            // Check offer
            if (_comDao.HasOffer(itemModel.ItemCd))
            {
                var offer = _comDao.GetOffer(itemModel.ItemCd);

                itemModel.OfferDiv = offer.OfferDiv;
                itemModel.ItemDiv = Logics.TEXT_BLANK;

                if (itemModel.OfferDiv == Logics.CD_OFFER_DIV_DISCOUNT)
                {
                    itemModel.SalesPriceOld = itemModel.SalesPrice;
                    itemModel.SalesPrice = GetOfferPrice(itemModel.SalesPrice, offer.Percent);
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
        /// 
        /// </summary>
        /// <param name="itemCd"></param>
        /// <returns></returns>
        public bool HasOffer(string itemCd)
        {
            // Check param
            if (DataCheckHelper.IsNull(itemCd))
                throw new ParamInvalidException();

            // Return value
            return _comDao.HasOffer(itemCd);
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