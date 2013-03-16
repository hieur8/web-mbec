using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Model.Admin.UserChangePassword;
using MiBo.Domain.Web.Admin.UserChangePassword;

namespace MiBo.Domain.Logic.Admin.UserChangePassword
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
        private void Check(SaveDataModel inputObject)
        {
            // Local variable declaration
            UserCom userCom = null;

            // Variable initialize
            userCom = new UserCom();

            // Check valid
            if (!userCom.IsValidPassword(PageHelper.UserCd, inputObject.Password))
                throw new ExecuteException("E_MSG_00009", "Mật khẩu");
            if (inputObject.NewPassword != inputObject.NewPasswordConfirm)
                throw new ExecuteException("E_MSG_00001", "Mật khẩu mới và mật khẩu xác nhận");
            if (!userCom.IsExist(PageHelper.UserCd, true))
                throw new DataNotExistException("Người dùng");
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
            UserCom userCom = null;

            // Variable initialize
            saveResult = new SaveDataModel();
            userCom = new UserCom();

            // Update info
            userCom.UpdatePassword(PageHelper.UserCd, inputObject.NewPassword, PageHelper.UserName, true);

            // Return value
            return saveResult;
        }
        #endregion
    }
}