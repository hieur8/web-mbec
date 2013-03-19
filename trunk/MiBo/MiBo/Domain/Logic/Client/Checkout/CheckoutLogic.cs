using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiBo.Domain.Web.Client.Checkout;
using MiBo.Domain.Model.Client.Checkout;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Dao;
using MiBo.Domain.Common.Dao;

namespace MiBo.Domain.Logic.Client.Checkout
{
    public class CheckoutLogic
    {
        #region Invoke Method
        /// <summary>
        /// Checkout process.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        public CheckoutResponseModel Invoke(CheckoutRequestModel request)
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
        private InitDataModel Convert(CheckoutRequestModel request)
        {
            // Local variable declaration
            InitDataModel inputObject = null;

            // Variable initialize
            inputObject = new InitDataModel();

            // Convert data input
            DataHelper.ConvertInput(request, inputObject);
            inputObject.Accept = request.Accept;
            inputObject.Cart = DataHelper.ConvertInputCart(request.Cart);
            return inputObject;
        }

        /// <summary>
        /// Execute convert ouput.
        /// </summary>
        /// <param name="resultObject">DataModel</param>
        /// <returns>ResponseModel</returns>
        private CheckoutResponseModel Convert(InitDataModel resultObject)
        {
            // Local variable declaration
            CheckoutResponseModel responseModel = null;

            // Variable initialize
            responseModel = new CheckoutResponseModel();

            responseModel.StatusFlag = resultObject.StatusFlag;
            
            return responseModel;
        }

        /// <summary>
        /// Execute processing.
        /// </summary>
        /// <param name="request">RequestModel</param>
        /// <returns>ResponseModel</returns>
        private CheckoutResponseModel Execute(CheckoutRequestModel request)
        {
            // Local variable declaration
            CheckoutResponseModel responseModel = null;
            InitDataModel inputObject = null;
            InitDataModel resultObject = new InitDataModel();
            // Variable initialize
            responseModel = new CheckoutResponseModel();

            // Execute convert input.
            inputObject = Convert(request);

            ClientCheckoutDao checkoutDao = new ClientCheckoutDao();
            try
            {
                checkoutDao.makeCheckout(inputObject.Accept, inputObject.Cart);
                responseModel.StatusFlag = true;
            }   
            catch (Exception)
            {
                responseModel.StatusFlag = false;
            }

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
        }

        #endregion
    }
}