using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Client.Profile;
using MiBo.Domain.Web.Client.Profile;

namespace MiBo.Domain.Logic.Client.Profile
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
            SaveResponseModel responseModel = null;

            // Variable initialize
            responseModel = new SaveResponseModel();

            // Get value
            var message = MessageHelper.GetMessageInfo("I_MSG_00001");

            // Set value
            responseModel.AddMessage(message);

            // Return value
            return responseModel;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private SaveResponseModel Execute(SaveRequestModel request)
        {
            // Local variable declaration
            SaveResponseModel responseModel = null;
            SaveDataModel inputObject = null;
            SaveDataModel resultObject = null;

            // Variable initialize
            responseModel = new SaveResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // Check processing.
            Check(inputObject);

            // Save infomation
            resultObject = SaveInfo(inputObject);

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
        }

        /// <summary>
        /// Check processing.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        private void Check(SaveDataModel inputObject)
        {
            // Local variable declaration
            UserCom userCom = null;

            // Variable initialize
            userCom = new UserCom();

            // Check valid
            if (!PageHelper.HasAuthenticated)
                throw new ExecuteException("E_MSG_00010");

            if (inputObject.HasChagngePassword)
            {
                if (DataCheckHelper.IsNull(inputObject.Password))
                    throw new ExecuteException("E_MSG_00004", "Mật khẩu");
                if (DataCheckHelper.IsNull(inputObject.NewPassword))
                    throw new ExecuteException("E_MSG_00004", "Mật khẩu mới");
                if (!userCom.IsValidPassword(PageHelper.UserCd, inputObject.Password))
                    throw new ExecuteException("E_MSG_00001", "Mật khẩu");
                if (inputObject.NewPassword != inputObject.NewPasswordConf)
                    throw new ExecuteException("E_MSG_00001", "Mật khẩu và mật khẩu xát nhận");
            }



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
            ClientProfileDao clientProfileDao = null;

            // Variable initialize
            saveResult = new SaveDataModel();
            clientProfileDao = new ClientProfileDao();

            // Save data
            clientProfileDao.UpdateUser(inputObject);

            // Return value
            return saveResult;
        }
        #endregion
    }
}