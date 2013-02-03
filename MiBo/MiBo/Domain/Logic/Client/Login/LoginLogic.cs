using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiBo.Domain.Web.Client.Login;
using MiBo.Domain.Model.Client.Login;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Dao;
using MiBo.Domain.Common.Dao;

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
            InitDataModel resultObject = null;
            // Variable initialize
            responseModel = new LoginResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // Get infomation
            resultObject = CheckLogin(inputObject);

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
        }

        /// <summary>
        /// Get infomation
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private InitDataModel CheckLogin(InitDataModel inputObject)
        {
            // Local variable declaration
            InitDataModel getResult = null;
            ClientLoginDao clientLoginDao = null;


            // Variable initialize
            getResult = new InitDataModel();
            getResult.StatusFlag = false;
            clientLoginDao = new ClientLoginDao();


            User result = clientLoginDao.GetUserInfo(inputObject);
            if (result != null)
            {
                getResult.StatusFlag = true;
                getResult.UserName = result.UserName;
            }
            // Return value
            return getResult;
        }
        #endregion
    }
}