using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.OfferItemList;
using MiBo.Domain.Web.Admin.OfferItemList;
using Resources;

namespace MiBo.Domain.Logic.Admin.OfferItemList
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
            IList<OutputOfferItemModel> listOfferItems = null;
            OutputOfferItemModel offerItem = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listOfferItems = new List<OutputOfferItemModel>();

            // Get value
            var cbDeleteFlag = new ComboModel();
            foreach (var obj in resultObject.ListOfferItems)
            {
                offerItem = new OutputOfferItemModel();
                offerItem.OfferCd = DataHelper.ToString(obj.OfferCd);
                offerItem.DetailNo = DataHelper.ToString(obj.DetailNo);
                offerItem.OfferItemCd = DataHelper.ToString(obj.OfferItemCd);
                offerItem.OfferItemQtty = DataHelper.ToString(Formats.NUMBER, obj.OfferItemQtty);
                offerItem.DeleteFlag = DataHelper.ToString(obj.DeleteFlag);
                offerItem.UpdateDate = DataHelper.ToString(Formats.UPDATE_DATE, obj.UpdateDate);

                cbDeleteFlag = MCodeCom.ToComboItems(resultObject.ListDeleteFlag, offerItem.DeleteFlag);
                offerItem.ListDeleteFlag = cbDeleteFlag.ListItems;
                offerItem.DeleteFlag = cbDeleteFlag.SeletedValue;

                listOfferItems.Add(offerItem);
            }

            // Set value
            responseModel.OfferCd = resultObject.OfferCd;
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

            // Return value
            return responseModel;
        }

        /// <summary>
        /// Check processing.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        private void Check(InitDataModel inputObject)
        {
            // Local variable declaration
            var adminOfferItemListDao = new AdminOfferItemListDao();

            // Check role
            if (!PageHelper.AuthRole(Logics.RL_OFFERS))
                throw new ExecuteException("E_MSG_00013");

            // Exist group
            if (!adminOfferItemListDao.IsExistOffer(inputObject.OfferCd))
                throw new DataNotExistException("Khuyến mãi");
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
            MCodeCom mCodeCom = null;
            AdminOfferItemListDao adminOfferItemListDao = null;

            // Variable initialize
            getResult = new InitDataModel();
            mCodeCom = new MCodeCom();
            adminOfferItemListDao = new AdminOfferItemListDao();

            // Get data
            var listDeleteFlag = mCodeCom.GetListCode(Logics.GROUP_DELETE_FLAG, null, false, false);
            var listOfferItems = adminOfferItemListDao.GetListOfferItems(inputObject.OfferCd);

            // Set value
            getResult.OfferCd = inputObject.OfferCd;
            getResult.ListDeleteFlag = listDeleteFlag;
            getResult.ListOfferItems = listOfferItems;

            // Return value
            return getResult;
        }
        #endregion
    }
}