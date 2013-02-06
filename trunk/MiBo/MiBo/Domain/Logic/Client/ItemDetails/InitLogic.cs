using System.Collections.Generic;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Client.ItemDetails;
using MiBo.Domain.Web.Client.ItemDetails;
using Resources;

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
            IList<string> listImages = null;
            IList<OutputItemModel> listOfferItems = null;
            OutputItemModel offerItem = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listImages = new List<string>();
            listOfferItems = new List<OutputItemModel>();

            // Get value
            var item = resultObject.Item;

            // Set value
            responseModel.ItemCd = DataHelper.ToString(item.ItemCd);
            responseModel.ItemName = DataHelper.ToString(item.ItemName);
            responseModel.ItemImage = DataHelper.ToString(item.ItemImage);
            foreach (var obj in item.ItemImages)
            {
                listImages.Add(obj.Image);
            }
            responseModel.ListImages = listImages;
            responseModel.ItemDiv = DataHelper.ToString(item.ItemDiv);
            responseModel.OfferDiv = DataHelper.ToString(item.OfferDiv);
            responseModel.Price = DataHelper.ToString(Formats.CURRENCY, item.SalesPrice);
            responseModel.PriceOld = DataHelper.ToString(Formats.CURRENCY, item.SalesPriceOld);
            responseModel.Notes = DataHelper.ToString(item.Notes);
            foreach (var obj in item.ListOfferItems)
            {
                offerItem = new OutputItemModel();
                offerItem.ItemCd = DataHelper.ToString(obj.OfferItemCd);
                offerItem.ItemName = DataHelper.ToString(obj.Item.ItemName);
                offerItem.ItemImage = DataHelper.ToString(obj.Item.ItemImages[0].Image);
                offerItem.Quantity = DataHelper.ToString(Formats.NUMBER, obj.OfferItemQtty);
                listOfferItems.Add(offerItem);
            }
            responseModel.ListOfferItems = listOfferItems;

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

            // Set value
            getResult.Item = itemCom.ToItemModel(item);

            // Return value
            return getResult;
        }
        #endregion
    }
}