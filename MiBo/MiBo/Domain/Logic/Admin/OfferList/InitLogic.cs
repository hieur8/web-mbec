using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.OfferList;
using MiBo.Domain.Web.Admin.OfferList;
using Resources;

namespace MiBo.Domain.Logic.Admin.OfferList
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
            IList<OutputOfferModel> listOffers = null;
            OutputOfferModel offer = null;
            MCodeCom mCodeCom = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listOffers = new List<OutputOfferModel>();
            mCodeCom = new MCodeCom();

            // Get value
            var cbDeleteFlag = new ComboModel();
            var offerDivName = string.Empty;
            foreach (var obj in resultObject.ListOffers)
            {
                offer = new OutputOfferModel();
                offer.OfferCd = DataHelper.ToString(obj.OfferCd);
                offer.OfferGroupCd = DataHelper.ToString(obj.OfferGroupCd);
                offer.ItemCd = DataHelper.ToString(obj.ItemCd);
                offer.StartDate = DataHelper.ToString(Formats.DATE, obj.StartDate);
                offer.EndDate = DataHelper.ToString(Formats.DATE, obj.EndDate);
                offer.Percent = DataHelper.ToString(Formats.NUMBER, obj.Percent);
                offer.Notes = DataHelper.ToString(obj.Notes);
                offer.DeleteFlag = DataHelper.ToString(obj.DeleteFlag);
                offer.UpdateDate = DataHelper.ToString(Formats.UPDATE_DATE, obj.UpdateDate);

                offerDivName = mCodeCom.GetCodeName(Logics.GROUP_OFFER_DIV, obj.OfferDiv);
                offer.OfferDiv = DataHelper.ToString(obj.OfferDiv);
                offer.OfferDivName = DataHelper.ToString(offerDivName);

                cbDeleteFlag = MCodeCom.ToComboItems(resultObject.ListDeleteFlag, offer.DeleteFlag);
                offer.ListDeleteFlag = cbDeleteFlag.ListItems;
                offer.DeleteFlag = cbDeleteFlag.SeletedValue;

                listOffers.Add(offer);
            }

            var cbOfferDiv = MCodeCom.ToComboItems(resultObject.ListOfferDiv, null);
            cbDeleteFlag = MCodeCom.ToComboItems(resultObject.ListDeleteFlag, null);

            // Set value
            responseModel.ListOfferDiv = cbOfferDiv.ListItems;
            responseModel.ListDeleteFlag = cbDeleteFlag.ListItems;
            responseModel.ListOffers = listOffers;

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
            // Check role
            if (!PageHelper.AuthRole(Logics.RL_OFFERS))
                throw new ExecuteException("E_MSG_00013");
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
            AdminOfferListDao adminOfferListDao = null;

            // Variable initialize
            getResult = new InitDataModel();
            mCodeCom = new MCodeCom();
            adminOfferListDao = new AdminOfferListDao();

            // Get data
            var listDeleteFlag = mCodeCom.GetListCode(Logics.GROUP_DELETE_FLAG, null, true, false);
            var listOfferDiv = mCodeCom.GetListCode(Logics.GROUP_OFFER_DIV, null, true, false);
            var listOffers = adminOfferListDao.GetListOffers();

            // Set value
            getResult.ListDeleteFlag = listDeleteFlag;
            getResult.ListOfferDiv = listOfferDiv;
            getResult.ListOffers = listOffers;

            // Return value
            return getResult;
        }
        #endregion
    }
}