using System.Collections.Generic;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Client.Items;
using MiBo.Domain.Web.Client.Items;
using Resources;

namespace MiBo.Domain.Logic.Client.Items
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
            IList<OutputItemModel> listItems = null;
            OutputItemModel item = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listItems = new List<OutputItemModel>();

            // Get value
            foreach (var obj in resultObject.ListItems)
            {
                item = new OutputItemModel();

                item.ItemCd = DataHelper.ToString(obj.ItemCd);
                item.ItemName = DataHelper.ToString(obj.ItemName);
                item.ItemImage = DataHelper.ToString(obj.ItemImage);
                item.ItemDiv = DataHelper.ToString(obj.ItemDiv);
                item.OfferDiv = DataHelper.ToString(obj.OfferDiv);
                item.Price = DataHelper.ToString(Formats.CURRENCY, obj.SalesPrice);
                item.PriceOld = DataHelper.ToString(Formats.CURRENCY, obj.SalesPriceOld);
                item.Notes = DataHelper.ToSubString(obj.Notes, 200);

                listItems.Add(item);
            }

            // Set value
            responseModel.ListItems = listItems;

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
            ClientItemsDao clientItemsDao = null;
            ItemCom itemCom = null;

            // Variable initialize
            getResult = new InitDataModel();
            clientItemsDao = new ClientItemsDao();
            itemCom = new ItemCom();

            // Get data
            var listItems = clientItemsDao.GetListItems(inputObject);

            // Set value
            getResult.ListItems = itemCom.ToListItemModel(listItems);

            // Return value
            return getResult;
        }
        #endregion
    }
}