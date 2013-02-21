using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiBo.Domain.Web.Client.Login;
using MiBo.Domain.Model.Client.Login;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Dao;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;

namespace MiBo.Domain.Logic.Client.Login
{
    public class LoginLogic
    {
        #region Invoke Method
        /// <summary>
        /// Login process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public LoginResponseModel Invoke(LoginRequestModel request)
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
        private InitDataModel Convert(LoginRequestModel request)
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
        private LoginResponseModel Convert(InitDataModel resultObject)
        {
            // Local variable declaration
            LoginResponseModel responseModel = null;

            // Variable initialize
            responseModel = new LoginResponseModel();

            responseModel.StatusFlag = resultObject.StatusFlag;
            responseModel.UserName = resultObject.UserName;
            responseModel.UserCd = resultObject.UserCd;
            return responseModel;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private LoginResponseModel Execute(LoginRequestModel request)
        {
            // Local variable declaration
            LoginResponseModel responseModel = null;
            InitDataModel inputObject = null;
            InitDataModel resultObject = new InitDataModel();
            // Variable initialize
            responseModel = new LoginResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // Get infomation
            UserComDao userCom = new UserComDao();
            User result = userCom.GetSingle(inputObject.UserName, DataHelper.GetMd5Hash(inputObject.Password));

            if (result != null)
            {
                resultObject.StatusFlag = true;
                resultObject.UserName = result.Email;
                resultObject.UserCd = result.UserCd.ToString();
            }
            else
            {
                resultObject.StatusFlag = false;
                throw new ExecuteException("E_MSG_00008");

            }

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
        }

        #endregion
    }
}