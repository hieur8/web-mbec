using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Model.Client.Profile;
using MiBo.Domain.Web.Client.Profile;

namespace MiBo.Domain.Logic.Client.Profile
{
    public class InitLogic
    {
        #region Invoke Method
        /// <summary>
        /// Initialization process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public InitResponseModel Invoke(InitRequestModel request)
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
        private InitDataModel Convert(InitRequestModel request)
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
        private InitResponseModel Convert(InitDataModel resultObject)
        {
            // Local variable declaration
            InitResponseModel responseModel = null;

            // Variable initialize
            responseModel = new InitResponseModel();

            // Get value
            var user = resultObject.User;

            // Set value
            responseModel.FullName = DataHelper.ToString(user.FullName);
            responseModel.Address = DataHelper.ToString(user.Address);
            responseModel.HasNewsletter = DataHelper.ToString(user.HasNewsletter);

            // Return value
            return responseModel;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private InitResponseModel Execute(InitRequestModel request)
        {
            // Local variable declaration
            InitResponseModel responseModel = null;
            InitDataModel inputObject = null;
            InitDataModel resultObject = null;

            // Variable initialize
            responseModel = new InitResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            // Check processing.
            Check(inputObject);

            // Get infomation
            resultObject = GetInfo(inputObject);

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
        }

        /// <summary>
        /// Check processing.
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        private void Check(InitDataModel inputObject)
        {
            if (!PageHelper.HasAuthenticated)
                throw new ExecuteException("E_MSG_00010");
        }

        /// <summary>
        /// Get infomation
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private InitDataModel GetInfo(InitDataModel inputObject)
        {
            // Local variable declaration
            InitDataModel getResult = null;
            UserCom userCom = null;

            // Variable initialize
            getResult = new InitDataModel();
            userCom = new UserCom();

            // Get data
            var user = userCom.GetSingle(PageHelper.UserCd, false);

            // Set value
            getResult.User = user;

            // Return value
            return getResult;
        }
        #endregion
    }
}