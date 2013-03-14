using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Admin.AcceptList;
using MiBo.Domain.Web.Admin.AcceptList;
using Resources;

namespace MiBo.Domain.Logic.Admin.AcceptList
{
    public class FilterLogic
    {
        #region Invoke Method
        /// <summary>
        /// Filter process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public FilterResponseModel Invoke(FilterRequestModel request)
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
        private FilterDataModel Convert(FilterRequestModel request)
        {
            // Local variable declaration
            FilterDataModel inputObject = null;

            // Variable initialize
            inputObject = new FilterDataModel();

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
        private FilterResponseModel Convert(FilterDataModel resultObject)
        {
            // Local variable declaration
            FilterResponseModel responseModel = null;
            IList<OutputAcceptModel> listAccepts = null;
            MCodeCom mCodeCom = null;
            OutputAcceptModel accept = null;

            // Variable initialize
            responseModel = new FilterResponseModel();
            listAccepts = new List<OutputAcceptModel>();
            mCodeCom = new MCodeCom();

            // Get value
            var slipStatusName = string.Empty;
            var paymentMethodsName = string.Empty;
            var deleteFlagName = string.Empty;
            foreach (var obj in resultObject.ListAccepts)
            {
                accept = new OutputAcceptModel();
                accept.AcceptSlipNo = DataHelper.ToString(obj.AcceptSlipNo);
                accept.SlipStatus = DataHelper.ToString(obj.SlipStatus);
                slipStatusName = mCodeCom.GetCodeName(Logics.GROUP_SLIP_STATUS, accept.SlipStatus);
                accept.SlipStatusName = DataHelper.ToString(slipStatusName);
                accept.AcceptDate = DataHelper.ToString(Formats.DATE, obj.AcceptDate);
                accept.DeliveryDate = DataHelper.ToString(Formats.DATE, obj.DeliveryDate);
                accept.ClientCd = DataHelper.ToString(obj.ClientCd);
                accept.ClientName = DataHelper.ToString(obj.ClientName);
                accept.ClientAddress = DataHelper.ToString(obj.ClientAddress);
                accept.ClientTel = DataHelper.ToString(obj.ClientTel);
                accept.DeliveryCd = DataHelper.ToString(obj.DeliveryCd);
                accept.DeliveryName = DataHelper.ToString(obj.DeliveryName);
                accept.DeliveryAddress = DataHelper.ToString(obj.DeliveryAddress);
                accept.DeliveryTel = DataHelper.ToString(obj.DeliveryTel);
                accept.PaymentMethods = DataHelper.ToString(obj.PaymentMethods);
                paymentMethodsName = mCodeCom.GetCodeName(Logics.GROUP_PAYMENT_METHODS, accept.PaymentMethods);
                accept.PaymentMethodsName = DataHelper.ToString(paymentMethodsName);
                accept.ViewId = DataHelper.ToString(obj.ViewId);
                accept.Notes = DataHelper.ToString(obj.Notes);
                accept.UpdateUser = DataHelper.ToString(obj.UpdateUser);
                accept.UpdateDate = DataHelper.ToString(Formats.UPDATE_DATE, obj.UpdateDate);
                accept.DeleteFlag = DataHelper.ToString(obj.DeleteFlag);
                deleteFlagName = mCodeCom.GetCodeName(Logics.GROUP_DELETE_FLAG, accept.DeleteFlag);
                accept.DeleteFlagName = DataHelper.ToString(deleteFlagName);
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
        private FilterResponseModel Execute(FilterRequestModel request)
        {
            // Local variable declaration
            FilterResponseModel responseModel = null;
            FilterDataModel inputObject = null;
            FilterDataModel resultObject = null;

            // Variable initialize
            responseModel = new FilterResponseModel();

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
        private void Check(FilterDataModel inputObject)
        {
            // Local variable declaration
            DataCom dataCom = null;
            MCodeCom mCodeCom = null;

            // Variable initialize
            dataCom = new DataCom();
            mCodeCom = new MCodeCom();
        }

        /// <summary>
        /// Get infomation
        /// </summary>
        /// <param name="inputObject">DataModel</param>
        /// <returns>DataModel</returns>
        private FilterDataModel GetInfo(FilterDataModel inputObject)
        {
            // Local variable declaration
            FilterDataModel getResult = null;
            MCodeCom mCodeCom = null;
            AdminAcceptListDao adminAcceptListDao = null;

            // Variable initialize
            getResult = new FilterDataModel();
            mCodeCom = new MCodeCom();
            adminAcceptListDao = new AdminAcceptListDao();

            // Get data
            var listAccepts = adminAcceptListDao.GetListAccepts(inputObject);

            // Set value
            getResult.ListAccepts = listAccepts;

            // Return value
            return getResult;
        }
        #endregion
    }
}