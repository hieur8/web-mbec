using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.OfferItemEntry;
using MiBo.Domain.Web.Admin.OfferItemEntry;

namespace MiBo.Domain.Logic.Admin.OfferItemEntry
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
            response.OfferCd = DataHelper.ToString(resultObject.OfferCd);
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
            var adminOfferItemEntryDao = new AdminOfferItemEntryDao();
            var mCodeCom = new MCodeCom();

            // Check role
            if (!PageHelper.AuthRole(Logics.RL_OFFERS))
                throw new ExecuteException("E_MSG_00013");

            // Exist offer
            if (!adminOfferItemEntryDao.IsExistOffer(inputObject.OfferCd))
                throw new DataNotExistException("Khuyến mãi");

            // Check valid
            if (inputObject.OfferItemQtty <= 0)
                throw new ExecuteException("E_MSG_00011", "Số lượng");
            var dFlag = DataHelper.ToString(inputObject.DeleteFlag);
            if (!mCodeCom.IsExist(Logics.GROUP_DELETE_FLAG, dFlag, false))
                throw new DataNotExistException("Dữ liệu");
            if (!adminOfferItemEntryDao.IsExistItem(inputObject.OfferItemCd))
                throw new DataNotExistException("Mã sản phẩm");
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
            AdminOfferItemEntryDao adminOfferItemEntryDao = null;

            // Variable initialize
            saveResult = new SaveDataModel();
            adminOfferItemEntryDao = new AdminOfferItemEntryDao();

            // Insert data
            adminOfferItemEntryDao.InsertOfferItem(inputObject);

            // Set value
            saveResult.OfferCd = inputObject.OfferCd;

            // Return value
            return saveResult;
        }
        #endregion
    }
}