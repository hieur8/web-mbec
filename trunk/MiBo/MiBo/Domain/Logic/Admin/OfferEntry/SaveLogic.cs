using System;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.OfferEntry;
using MiBo.Domain.Web.Admin.OfferEntry;

namespace MiBo.Domain.Logic.Admin.OfferEntry
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
            AdminOfferEntryDao adminOfferEntryDao = null;
            MCodeCom mCodeCom = null;

            // Variable initialize
            adminOfferEntryDao = new AdminOfferEntryDao();
            mCodeCom = new MCodeCom();
            
            // Check role
            if (!PageHelper.AuthRole(Logics.RL_OFFERS))
                throw new ExecuteException("E_MSG_00013");

            // Check valid
            if (DateTime.Compare(inputObject.StartDate, inputObject.EndDate) > 0)
                throw new ExecuteException("E_MSG_00015", "Ngày bắt đầu", "Ngày kết thúc");
            if (inputObject.Percent < 0)
                throw new ExecuteException("E_MSG_00011", "Giảm (%)");
            if (!mCodeCom.IsExist(Logics.GROUP_OFFER_DIV, inputObject.OfferDiv, false))
                throw new DataNotExistException("Dữ liệu");
            if (!adminOfferEntryDao.IsExistItem(inputObject.ItemCd))
                throw new DataNotExistException("Sản phẩm");
            if (adminOfferEntryDao.IsExistOffer(inputObject.OfferCd))
                throw new DataExistException("Khuyến mãi");
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
            AdminOfferEntryDao adminOfferEntryDao = null;

            // Variable initialize
            saveResult = new SaveDataModel();
            adminOfferEntryDao = new AdminOfferEntryDao();

            // Insert data
            adminOfferEntryDao.InsertOffer(inputObject);
            
            return saveResult;
        }
        #endregion
    }
}