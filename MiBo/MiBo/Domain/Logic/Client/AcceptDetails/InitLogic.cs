using System.Collections.Generic;
using System.Linq;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Exceptions;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Client.AcceptDetails;
using MiBo.Domain.Web.Client.AcceptDetails;
using Resources;

namespace MiBo.Domain.Logic.Client.AcceptDetails
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
            OutputDetailsModel details = null;
            IList<OutputAcceptDetailsModel> listAcceptDetails = null;
            OutputAcceptDetailsModel acceptDetails = null;
            MCodeCom mCodeCom = null;

            // Variable initialize
            responseModel = new InitResponseModel();
            details = new OutputDetailsModel();
            listAcceptDetails = new List<OutputAcceptDetailsModel>();
            mCodeCom = new MCodeCom();

            // Get value
            var accept = resultObject.Accept;
            details.AcceptSlipNo = DataHelper.ToString(accept.AcceptSlipNo);
            var slipStatusName = mCodeCom.GetCodeName(Logics.GROUP_SLIP_STATUS, accept.SlipStatus);
            details.SlipStatus = DataHelper.ToString(accept.SlipStatus);
            details.SlipStatusName = DataHelper.ToString(slipStatusName);
            details.AcceptDate = DataHelper.ToString(Formats.FULL_DATE, accept.AcceptDate);
            details.DeliveryName = DataHelper.ToString(accept.DeliveryName);
            details.DeliveryAddress = DataHelper.ToString(accept.DeliveryAddress);
            details.ClientName = DataHelper.ToString(accept.ClientName);
            details.ClientAddress = DataHelper.ToString(accept.ClientAddress);
            var paymentMethodsName = mCodeCom.GetCodeName(Logics.GROUP_PAYMENT_METHODS, accept.PaymentMethods);
            details.PaymentMethods = DataHelper.ToString(accept.PaymentMethods);
            details.PaymentMethodsName = DataHelper.ToString(paymentMethodsName);
            var totalAmount = accept.AcceptDetails.Sum(o => o.DetailAmt);
            details.TotalAmount = DataHelper.ToString(Formats.CURRENCY, totalAmount);
            foreach (var obj in accept.AcceptDetails)
            {
                acceptDetails = new OutputAcceptDetailsModel();
                acceptDetails.ItemCd = DataHelper.ToString(obj.ItemCd);
                acceptDetails.ItemName = DataHelper.ToString(obj.ItemName);
                acceptDetails.Price = DataHelper.ToString(Formats.CURRENCY, obj.DetailPrice);
                acceptDetails.Quantty = DataHelper.ToString(Formats.NUMBER, obj.DetailQtty);
                acceptDetails.Amount = DataHelper.ToString(Formats.CURRENCY, obj.DetailAmt);

                listAcceptDetails.Add(acceptDetails);
            }
            details.ListAcceptDetails = listAcceptDetails;

            // Set value
            responseModel.Details = new List<OutputDetailsModel>() { details };

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
            // Local variable declaration
            ClientAcceptDetailsDao clientAcceptDetailsDao = null;

            // Variable initialize
            clientAcceptDetailsDao = new ClientAcceptDetailsDao();

            // Check valid
            if (DataCheckHelper.IsNull(inputObject.AcceptSlipNo) && DataCheckHelper.IsNull(inputObject.ViewId))
                throw new ExecuteException("E_MSG_00004", "Mã hóa đơn");

            if (!clientAcceptDetailsDao.IsExistAccept(inputObject))
                throw new DataNotExistException(string.Format("Hóa đơn ({0})", inputObject.AcceptSlipNo + inputObject.ViewId));
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
            ClientAcceptDetailsDao clientAcceptDetailsDao = null;

            // Variable initialize
            getResult = new InitDataModel();
            clientAcceptDetailsDao = new ClientAcceptDetailsDao();

            // Get data
            var accept = clientAcceptDetailsDao.GetAccept(inputObject);

            // Set value
            getResult.Accept = accept;

            // Return value
            return getResult;
        }
        #endregion
    }
}