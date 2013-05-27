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
    public class FilterLogic
    {
        #region Invoke Method
        /// <summary>
        /// Filter process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public FilterResponseModel Invoke(FilterRequestModel request)
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
        private FilterDataModel Convert(FilterRequestModel request)
        {
            // Local variable declaration
            FilterDataModel inputObject = null;

            // Variable initialize
            inputObject = new FilterDataModel();

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
        private FilterResponseModel Convert(FilterDataModel resultObject)
        {
            // Local variable declaration
            FilterResponseModel responseModel = null;
            IList<OutputOfferModel> listOffers = null;
            MCodeCom mCodeCom = null;
            OutputOfferModel offer = null;

            // Variable initialize
            responseModel = new FilterResponseModel();
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

            // Set value
            responseModel.ListOffers = listOffers;

            // Return value
            return responseModel;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private FilterResponseModel Execute(FilterRequestModel request)
        {
            // Local variable declaration
            FilterResponseModel responseModel = null;
            FilterDataModel inputObject = null;
            FilterDataModel resultObject = null;

            // Variable initialize
            responseModel = new FilterResponseModel();

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
        private void Check(FilterDataModel inputObject)
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
        private FilterDataModel GetInfo(FilterDataModel inputObject)
        {
            // Local variable declaration
            FilterDataModel getResult = null;
            MCodeCom mCodeCom = null;
            AdminOfferListDao adminOfferListDao = null;

            // Variable initialize
            getResult = new FilterDataModel();
            mCodeCom = new MCodeCom();
            adminOfferListDao = new AdminOfferListDao();

            // Get data
            var listDeleteFlag = mCodeCom.GetListCode(Logics.GROUP_DELETE_FLAG, null, true, false);
            var listOffers = adminOfferListDao.GetListOffers(inputObject);

            // Set value
            getResult.ListDeleteFlag = listDeleteFlag;
            getResult.ListOffers = listOffers;

            // Return value
            return getResult;
        }
        #endregion
    }
}