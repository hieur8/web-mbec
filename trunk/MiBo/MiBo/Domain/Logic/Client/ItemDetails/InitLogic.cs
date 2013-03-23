using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Client.ItemDetails;
using MiBo.Domain.Web.Client.ItemDetails;
using Resources;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Model;

namespace MiBo.Domain.Logic.Client.ItemDetails
{
    public class InitLogic
    {
        #region Invoke Method
        /// <summary>
        /// Initialization process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public InitResponseModel Invoke(InitRequestModel request)
        {
            var responseModel = Execute(request);
            return responseModel;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Execute convert input.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>DataModel</returns>
        private InitDataModel Convert(InitRequestModel request)
        {
            // Local variable declaration
            InitDataModel inputObject = null;

            // Variable initialize
            inputObject = new InitDataModel();

            // Convert data input
            DataHelper.ConvertInput(request, inputObject);

            // Return value
            return inputObject;
        }

        /// <summary>
        /// Execute convert ouput.
        /// </summary>
        /// <param name="resultObject">DataModel</param>
        /// <returns>ResponseModel</returns>
        private InitResponseModel Convert(InitDataModel resultObject)
        {
            // Local variable declaration
            InitResponseModel responseModel = null;
            OutputDetailsModel details = null;
            IList<OutputImageModel> listImages = null;
            IList<OutputItemModel> listOfferItems = null;
            IList<MiBo.Domain.Web.Client.Index.OutputItemModel> listlq = null;
            OutputItemModel offerItem = null;
            OutputImageModel imageItem = null;
            MiBo.Domain.Web.Client.Index.OutputItemModel lqItem = null;
            // Variable initialize
            responseModel = new InitResponseModel();
            details = new OutputDetailsModel();
            listImages = new List<OutputImageModel>();
            listOfferItems = new List<OutputItemModel>();
            listlq = new List<MiBo.Domain.Web.Client.Index.OutputItemModel>();
            // Get value
            var item = resultObject.Item;

            details.ItemCd = DataHelper.ToString(item.ItemCd);
            details.ItemName = DataHelper.ToString(item.ItemName);
            details.CategoryCd = DataHelper.ToString(item.CategoryCd);
            details.CategoryName = DataHelper.ToString(item.Category.CategoryName);
            details.ItemImage = DataHelper.ToString(item.ItemImage);
            foreach (var obj in FileHelper.GetSmallImages(item.ImagePath, Logics.EXT_JPEG))
            {
                imageItem = new OutputImageModel();
                imageItem.ItemCd = DataHelper.ToString(item.ItemCd);
                imageItem.ItemImage = DataHelper.ToString(obj.Name);
                listImages.Add(imageItem);
            }
            details.ListImages = listImages;
            details.ItemDiv = DataHelper.ToString(item.ItemDiv);
            details.OfferDiv = DataHelper.ToString(item.OfferDiv);
            details.Price = DataHelper.ToString(Formats.CURRENCY, item.SalesPrice);
            details.PriceOld = DataHelper.ToString(Formats.CURRENCY, item.SalesPriceOld);
            details.BrandCd = DataHelper.ToString(item.BrandCd);
            details.BrandName = DataHelper.ToString(item.Brand.BrandName);
            details.CountryCd = DataHelper.ToString(item.CountryCd);
            details.CountryName = DataHelper.ToString(item.Country.CountryName);
            details.Notes = DataHelper.ToString(item.Notes);
            foreach (var obj in item.ListOfferItems)
            {
                offerItem = new OutputItemModel();
                offerItem.ItemCd = DataHelper.ToString(obj.OfferItemCd);
                offerItem.ItemName = DataHelper.ToString(obj.Item.ItemName);
                offerItem.ItemImage = DataHelper.ToString(FileHelper.GetSmallImage(ItemCom.GetImagePath(obj.Item.ItemCd), Logics.EXT_JPEG));
                offerItem.Quantity = DataHelper.ToString(Formats.NUMBER, obj.OfferItemQtty);
                listOfferItems.Add(offerItem);
            }
            details.ListOfferItems = listOfferItems;

            ClientItemsDao itemDao = new ClientItemsDao();
            ItemCom itemCom = null;
            itemCom = new ItemCom();
            IList<ItemModel> lstItem = itemCom.ToListItemModel(itemDao.GetListItemsByCategoryCd(details.CategoryCd));
            foreach (var obj in lstItem)
            {
                lqItem = new MiBo.Domain.Web.Client.Index.OutputItemModel();

                lqItem.ItemCd = DataHelper.ToString(obj.ItemCd);
                lqItem.ItemName = DataHelper.ToString(obj.ItemName);
                lqItem.ItemImage = DataHelper.ToString(obj.ItemImage);
                lqItem.BrandCd = DataHelper.ToString(obj.BrandCd);
                lqItem.BrandName = DataHelper.ToString(obj.Brand.BrandName);
                lqItem.ItemDiv = DataHelper.ToString(obj.ItemDiv);
                lqItem.OfferDiv = DataHelper.ToString(obj.OfferDiv);
                lqItem.Price = DataHelper.ToString(Formats.CURRENCY, obj.SalesPrice);
                lqItem.PriceOld = DataHelper.ToString(Formats.CURRENCY, obj.SalesPriceOld);
                lqItem.Notes = DataHelper.ToString(obj.Notes);

                listlq.Add(lqItem);
            }
            details.lstItem = listlq; 
            // Set value
            responseModel.Details = new List<OutputDetailsModel>() { details };

            // Return value
            return responseModel;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private InitResponseModel Execute(InitRequestModel request)
        {
            // Local variable declaration
            InitResponseModel responseModel = null;
            InitDataModel inputObject = null;
            InitDataModel resultObject = null;

            // Variable initialize
            responseModel = new InitResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // Check infomation
            Check(inputObject);

            // Get infomation
            resultObject = GetInfo(inputObject);

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
        }

        /// <summary>
        /// Check processing.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        private void Check(InitDataModel inputObject)
        {
            // Local variable declaration
            ClientItemDetailsDao clientItemDetailsDao = null;

            // Variable initialize
            clientItemDetailsDao = new ClientItemDetailsDao();

            // Check valid
            if (!clientItemDetailsDao.IsExistItem(inputObject.ItemCd))
                throw new DataNotExistException(string.Format("Sản phẩm ({0})", inputObject.ItemCd));
        }

        /// <summary>
        /// Get infomation
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private InitDataModel GetInfo(InitDataModel inputObject)
        {
            // Local variable declaration
            InitDataModel getResult = null;
            ClientItemDetailsDao clientItemDetailsDao = null;
            ItemCom itemCom = null;

            // Variable initialize
            getResult = new InitDataModel();
            clientItemDetailsDao = new ClientItemDetailsDao();
            itemCom = new ItemCom();

            // Get data
            var item = clientItemDetailsDao.GetItem(inputObject);

            // Update data
            itemCom.UpdateViewer(inputObject.ItemCd);

            // Set value
            getResult.Item = itemCom.ToItemModel(item);

            // Return value
            return getResult;
        }
        #endregion
    }
}