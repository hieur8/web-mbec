using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiBo.Domain.Web.Client.Register;
using MiBo.Domain.Model.Client.Register;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Dao;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Web.Client.Register;

namespace MiBo.Domain.Logic.Client.Register
{
    public class RegisterLogic
    {
        #region Invoke Method
        /// <summary>
        /// Login process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public RegisterResponseModel Invoke(RegisterRequestModel request)
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
        private InitDataModel Convert(RegisterRequestModel request)
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
        private RegisterResponseModel Convert(InitDataModel resultObject)
        {
            // Local variable declaration
            RegisterResponseModel responseModel = null;

            // Variable initialize
            responseModel = new RegisterResponseModel();

            responseModel.StatusFlag = resultObject.StatusFlag;

            return responseModel;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private RegisterResponseModel Execute(RegisterRequestModel request)
        {
            // Local variable declaration
            RegisterResponseModel responseModel = null;
            InitDataModel inputObject = null;
            InitDataModel resultObject = new InitDataModel();
            // Variable initialize
            responseModel = new RegisterResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // insert infomation
            UserComDao userCom = new UserComDao();

            if (userCom.IsExistUserName(inputObject.email))
            {
                resultObject.StatusFlag = 2;
            }
            else
            {
                User param = new User();
                param.UserCd = Guid.NewGuid();
                param.UserName = inputObject.email;
                param.Password = inputObject.pass;

                try
                {
                    userCom.registerUser(param);
                    resultObject.StatusFlag = 0;
                }
                catch (Exception e)
                {
                    resultObject.StatusFlag = 1;
                }
            }

           

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
        }

        #endregion
    }
}