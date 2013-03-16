using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Model.Admin.UserLogin;
using MiBo.Domain.Web.Admin.UserLogin;

namespace MiBo.Domain.Logic.Admin.UserLogin
{
    public class AuthLogic
    {
        #region Invoke Method
        /// <summary>
        /// Authotication process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public AuthResponseModel Invoke(AuthRequestModel request)
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
        private AuthDataModel Convert(AuthRequestModel request)
        {
            // Local variable declaration
            AuthDataModel inputObject = null;

            // Variable initialize
            inputObject = new AuthDataModel();

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
        private AuthResponseModel Convert(AuthDataModel resultObject)
        {
            // Local variable declaration
            AuthResponseModel response = null;

            // Variable initialize
            response = new AuthResponseModel();

            response.UserCd = DataHelper.ToString(resultObject.UserCd);
            response.UserName = DataHelper.ToString(resultObject.UserName);

            return response;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private AuthResponseModel Execute(AuthRequestModel request)
        {
            // Local variable declaration
            AuthResponseModel response = null;
            AuthDataModel inputObject = null;
            AuthDataModel resultObject = null;

            // Variable initialize
            response = new AuthResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // Auth infomation
            resultObject = AuthInfo(inputObject);

            // Execute convert ouput.
            response = Convert(resultObject);

            return response;
        }

        /// <summary>
        /// Auth infomation
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private AuthDataModel AuthInfo(AuthDataModel inputObject)
        {
            // Local variable declaration
            AuthDataModel authResult = null;
            UserCom userCom = null;

            // Variable initialize
            authResult = new AuthDataModel();
            userCom = new UserCom();

            // Check valid
            if (DataCheckHelper.IsNull(inputObject.UserName))
                throw new ExecuteException("E_MSG_00004", "Tên người dùng");
            if (DataCheckHelper.IsNull(inputObject.Password))
                throw new ExecuteException("E_MSG_00004", "Mật khẩu");

            // Auth infomation
            var user = userCom.GetSingle(inputObject.UserName, inputObject.Password);
            if (user == null) throw new ExecuteException("E_MSG_00008");
            if (!userCom.AuthUserInGroups(user.UserCd, Logics.GP_ADMINISTRATORS, false))
                throw new ExecuteException("E_MSG_00013");

            // Set value
            authResult.UserCd = user.UserCd;
            authResult.UserName = user.Email;

            // Return value
            return authResult;
        }
        #endregion
    }
}