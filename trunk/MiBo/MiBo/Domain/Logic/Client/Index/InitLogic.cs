using System.Collections.Generic;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Client.Index;
using MiBo.Domain.Web.Client.Index;
using Resources;

namespace MiBo.Domain.Logic.Client.Index
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
            IList<ItemOutputModel> listNewItems = null;
            ItemOutputModel newItem = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listNewItems = new List<ItemOutputModel();

            // Get value
            foreach (var obj in resultObject.ListNewItems)
            {
                newItem = new ItemOutputModel();

                newItem.ItemCd = DataHelper.ToString(obj.ItemCd);
                newItem.ItemName = DataHelper.ToString(obj.ItemName);
                newItem.ItemImage = DataHelper.ToString(obj.ItemImages);
                newItem.Price = DataHelper.ToString(Formats.CURRENCY, obj.SalesPrice);
                newItem.PriceOld = DataHelper.ToString(Formats.CURRENCY, obj.SalesPriceOld);
                newItem.Notes = DataHelper.ToSubString(obj.Notes, 20);

                listNewItems.Add(newItem);
            }

            // Set value
            responseModel.ListNewItems = listNewItems;

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

            // Get infomation
            resultObject = GetInfo(inputObject);

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
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
            ClientIndexDao clientIndexDao = null;
            ItemCom itemCom = null;

            // Variable initialize
            getResult = new InitDataModel();
            clientIndexDao = new ClientIndexDao();
            itemCom = new ItemCom();

            // Get data
            var listNewItems = itemCom.ToListItemModel(clientIndexDao.GetListNewItems());

            // Set value
            getResult.ListNewItems = listNewItems;

            // Return value
            return getResult;
        }
        #endregion
    }
}