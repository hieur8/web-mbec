using System;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.GiftEntry;
using MiBo.Domain.Web.Admin.GiftEntry;

namespace MiBo.Domain.Logic.Admin.GiftEntry
{
    public class SaveLogic
    {
        #region Invoke Method
        /// <summary>
        /// Save process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public SaveResponseModel Invoke(SaveRequestModel request)
        {
            var response = Execute(request);
            return response;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// Execute convert input.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>DataModel</returns>
        private SaveDataModel Convert(SaveRequestModel request)
        {
            // Local variable declaration
            SaveDataModel inputObject = null;

            // Variable initialize
            inputObject = new SaveDataModel();

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
        private SaveResponseModel Convert(SaveDataModel resultObject)
        {
            // Local variable declaration
            SaveResponseModel response = null;

            // Variable initialize
            response = new SaveResponseModel();

            // Set value
            response.AddMessage(MessageHelper.GetMessageInfo("I_MSG_00001"));

            // Return value
            return response;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private SaveResponseModel Execute(SaveRequestModel request)
        {
            // Local variable declaration
            SaveResponseModel response = null;
            SaveDataModel inputObject = null;
            SaveDataModel resultObject = null;

            // Variable initialize
            response = new SaveResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // Check processing
            Check(inputObject);

            // Save infomation
            resultObject = SaveInfo(inputObject);

            // Execute convert ouput.
            response = Convert(resultObject);

            return response;
        }

        /// <summary>
        /// Check processing
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private void Check(SaveDataModel inputObject)
        {
            // Local variable declaration
            AdminGiftEntryDao adminGiftEntryDao = null;

            // Variable initialize
            adminGiftEntryDao = new AdminGiftEntryDao();

            // Check role
            if (!PageHelper.AuthRole(Logics.RL_GIFT_ENTRY))
                throw new ExecuteException("E_MSG_00013");

            // Check valid
            if(DateTime.Compare(inputObject.StartDate, inputObject.EndDate) > 0)
                throw new ExecuteException("E_MSG_00015", "Ngày bắt đầu", "Ngày kết thúc");

            if (inputObject.Price < 0)
                throw new ExecuteException("E_MSG_00011", "Số tiền");

            if (adminGiftEntryDao.IsExistGift(inputObject.GiftCd))
                throw new DataExistException("Thẻ");
        }

        /// <summary>
        /// Save infomation
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private SaveDataModel SaveInfo(SaveDataModel inputObject)
        {
            // Local variable declaration
            SaveDataModel saveResult = null;
            AdminGiftEntryDao adminGiftEntryDao = null;

            // Variable initialize
            saveResult = new SaveDataModel();
            adminGiftEntryDao = new AdminGiftEntryDao();

            // Insert data
            adminGiftEntryDao.InsertGift(inputObject);

            return saveResult;
        }
        #endregion
    }
}