using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Client.Register;
using MiBo.Domain.Web.Client.Register;
using System;

namespace MiBo.Domain.Logic.Client.Register
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

            // Set data
            responseModel.AddMessage(MessageHelper.GetMessageInfo("I_MSG_00002"));

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
            if (userCom.IsExistEmail(inputObject.Email, true))
                throw new ExecuteException("E_MSG_00010");
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
            ClientRegisterDao clientRegisterDao = null;

            // Variable initialize
            saveResult = new SaveDataModel();
            clientRegisterDao = new ClientRegisterDao();
            inputObject.UserCd = Guid.NewGuid();
            // Insert infomation
            clientRegisterDao.Insert(inputObject);

            // Send mail
            SendEmail(inputObject);
            clientRegisterDao.SubmitChanges();
            // Return value
            return saveResult;
        }

        /// <summary>
        /// Execute send email.
        /// </summary>
        /// <param name="param">String</param>
        /// <returns>EmailModel</returns>
        private void SendEmail(SaveDataModel inputObject)
        {
            // Local variable declaration
            MParameterCom mParameterCom = null;

            // Variable initialize
            mParameterCom = new MParameterCom();

            // Get data
            var emailModel = GetEmailModel(inputObject);
            var fileTemplate = FileHelper.ToString("/pages/media/email/active.html");

            var email = mParameterCom.GetString(Logics.PR_EMAIL_SUPPORT, false);
            var emailPass = mParameterCom.GetString(Logics.PR_EMAIL_SUPPORT_PASS, false);
            var hostMail = mParameterCom.GetString(Logics.PR_MAIL_SERVER, false);
            var subject = "Xác nhận tài khoản";
            var body = DataHelper.FormatString(fileTemplate, emailModel);

            MailHelper.SendMail(email, inputObject.Email, subject, body, hostMail, emailPass);
        }

        /// <summary>
        /// Execute get email model.
        /// </summary>
        /// <param name="param">String</param>
        /// <returns>EmailModel</returns>
        private OutputEmailModel GetEmailModel(SaveDataModel inputObject)
        {
            // Local variable declaration
            OutputEmailModel emailModel = null;
            UserCom userCom = null;
            MParameterCom mParameterCom = null;

            // Variable initialize
            emailModel = new OutputEmailModel();
            userCom = new UserCom();
            mParameterCom = new MParameterCom();

            // Get data

            var strHotline = mParameterCom.GetString(Logics.PR_HOTLINE, false);
            var strEmail = mParameterCom.GetString(Logics.PR_EMAIL_SUPPORT, false);
            var strChatYahoo = mParameterCom.GetString(Logics.PR_CHAT_YAHOO, false);

            // Set data
            emailModel.UserCd = DataHelper.ToString(inputObject.UserCd);
            emailModel.FullName = DataHelper.ToString(inputObject.Fullname);
            emailModel.Hotline = DataHelper.ToString(strHotline);
            emailModel.EmailSupport = DataHelper.ToString(strEmail);
            emailModel.ChatYahoo = DataHelper.ToString(strChatYahoo); ;

            // Return value;
            return emailModel;
        }
        #endregion
    }
}