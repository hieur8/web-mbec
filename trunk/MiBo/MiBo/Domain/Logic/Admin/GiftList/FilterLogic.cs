using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.GiftList;
using MiBo.Domain.Web.Admin.GiftList;
using Resources;

namespace MiBo.Domain.Logic.Admin.GiftList
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
            IList<OutputGiftModel> listGifts = null;
            MCodeCom mCodeCom = null;
            OutputGiftModel gift = null;

            // Variable initialize
            responseModel = new FilterResponseModel();
            listGifts = new List<OutputGiftModel>();
            mCodeCom = new MCodeCom();

            // Get value
            var deleteFlagName = string.Empty;
            ComboModel cbGiftStatus = null;
            foreach (var obj in resultObject.ListGifts)
            {
                gift = new OutputGiftModel();

                gift.GiftCd = DataHelper.ToString(obj.GiftCd);
                gift.GiftStatus = DataHelper.ToString(obj.GiftStatus);
                gift.StartDate = DataHelper.ToString(Formats.DATE, obj.StartDate);
                gift.EndDate = DataHelper.ToString(Formats.DATE, obj.EndDate);
                gift.Price = DataHelper.ToString(Formats.CURRENCY, obj.Price);
                gift.UpdateDate = DataHelper.ToString(Formats.UPDATE_DATE, obj.UpdateDate);
                gift.DeleteFlag = DataHelper.ToString(obj.DeleteFlag);
                deleteFlagName = mCodeCom.GetCodeName(Logics.GROUP_DELETE_FLAG, gift.DeleteFlag);
                gift.DeleteFlagName = DataHelper.ToString(deleteFlagName);
                cbGiftStatus = MCodeCom.ToComboItems(resultObject.ListGiftStatus, gift.GiftStatus);
                gift.ListGiftStatus = cbGiftStatus.ListItems;
                gift.GiftStatus = cbGiftStatus.SeletedValue;
                listGifts.Add(gift);
            }

            // Set value
            responseModel.ListGifts = listGifts;

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
            if (!PageHelper.AuthRole(Logics.RL_GIFTS))
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
            AdminGiftListDao adminGiftListDao = null;

            // Variable initialize
            getResult = new FilterDataModel();
            mCodeCom = new MCodeCom();
            adminGiftListDao = new AdminGiftListDao();

            // Get data
            var listGiftStatus = mCodeCom.GetListCode(Logics.GROUP_GIFT_STATUS, null, true, false);
            var listGifts = adminGiftListDao.GetListGifts(inputObject);

            // Set value
            getResult.ListGiftStatus = listGiftStatus;
            getResult.ListGifts = listGifts;

            // Return value
            return getResult;
        }
        #endregion
    }
}