using System;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Model.Client.Register;
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
            responseModel.StatusFlag = true;
            responseModel.AddMessage(MessageHelper.GetMessageInfo("I_MSG_00002"));

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
            UserCom userCom = new UserCom();

            if (userCom.IsExistEmail(inputObject.email,false))
            {
                throw new ExecuteException("E_MSG_00010");
                
            }
            else
            {
                User param = new User();
                param.UserCd = Guid.NewGuid();
                param.FullName = inputObject.fullname; 
                param.Email = inputObject.email;
                param.Password = inputObject.pass;
                userCom.registerUser(param);
                
            }
            // Execute convert ouput.
            responseModel = Convert(resultObject);
            return responseModel;
        }

        #endregion
    }
}