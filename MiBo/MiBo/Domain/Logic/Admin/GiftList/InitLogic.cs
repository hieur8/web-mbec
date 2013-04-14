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
            IList<OutputGiftModel> listGifts = null;
            MCodeCom mCodeCom = null;
            OutputGiftModel gift = null;

            // Variable initialize
            responseModel = new InitResponseModel();
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
            cbGiftStatus = MCodeCom.ToComboItems(resultObject.ListGiftStatus, null);
            responseModel.ListGiftStatus = cbGiftStatus.ListItems;
            responseModel.GiftStatus = cbGiftStatus.SeletedValue;
            var cbDeleteFlag = MCodeCom.ToComboItems(resultObject.ListDeleteFlag, null);
            responseModel.ListDeleteFlag = cbDeleteFlag.ListItems;
            responseModel.DeleteFlag = cbDeleteFlag.SeletedValue;
            responseModel.ListGifts = listGifts;

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
            // Check role
            if (!PageHelper.AuthRole(Logics.RL_GIFTS))
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
            AdminGiftListDao adminGiftListDao = null;

            // Variable initialize
            getResult = new InitDataModel();
            mCodeCom = new MCodeCom();
            adminGiftListDao = new AdminGiftListDao();

            // Get data
            var listDeleteFlag = mCodeCom.GetListCode(Logics.GROUP_DELETE_FLAG, null, true, false);
            var listGiftStatus = mCodeCom.GetListCode(Logics.GROUP_GIFT_STATUS, null, true, false);
            var listGifts = adminGiftListDao.GetListGifts();

            // Set value
            getResult.ListGiftStatus = listGiftStatus;
            getResult.ListDeleteFlag = listDeleteFlag;
            getResult.ListGifts = listGifts;

            // Return value
            return getResult;
        }
        #endregion
    }
}