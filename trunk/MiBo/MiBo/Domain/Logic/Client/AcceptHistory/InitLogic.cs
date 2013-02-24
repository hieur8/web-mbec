using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Client.AcceptHistory;
using MiBo.Domain.Web.Client.AcceptHistory;
using Resources;

namespace MiBo.Domain.Logic.Client.AcceptHistory
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
            IList<OutputAcceptModel> listAccepts = null;
            OutputAcceptModel accept = null;
            MCodeCom mCodeCom = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            listAccepts = new List<OutputAcceptModel>();
            mCodeCom = new MCodeCom();

            // Get value
            string slipStatusName = null;
            foreach (var obj in resultObject.ListAccepts)
            {
                accept = new OutputAcceptModel();

                accept.AcceptSlipNo = DataHelper.ToString(obj.AcceptSlipNo);
                accept.AcceptDate = DataHelper.ToString(Formats.DATE, obj.AcceptDate);
                accept.TotalAmount = DataHelper.ToString(Formats.CURRENCY, obj.TotalAmount);
                slipStatusName = mCodeCom.GetCodeName(Logics.GROUP_SLIP_STATUS, obj.SlipStatus);
                accept.SlipStatus = DataHelper.ToString(obj.SlipStatus);
                accept.SlipStatusName = DataHelper.ToString(slipStatusName);

                listAccepts.Add(accept);
            }

            // Set value
            responseModel.ListAccepts = listAccepts;

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

            // Check infomation
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
                throw new ExecuteException("E_MSG_00001", "Truy cập");
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
            ClientAcceptHistoryDao clientAcceptHistoryDao = null;

            // Variable initialize
            getResult = new InitDataModel();
            clientAcceptHistoryDao = new ClientAcceptHistoryDao();

            // Get data
            var listAccepts = clientAcceptHistoryDao.GetListAccepts(PageHelper.UserName);

            // Set value
            getResult.ListAccepts = listAccepts;

            // Return value
            return getResult;
        }
        #endregion
    }
}