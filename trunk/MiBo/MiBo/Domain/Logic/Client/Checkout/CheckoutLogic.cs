using System.Collections.Generic;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Dao;
using MiBo.Domain.Model.Client.Checkout;
using MiBo.Domain.Web.Client.Checkout;
using Resources;

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
            checkoutDao.makeCheckout(inputObject.Accept, inputObject.Cart);
            responseModel.StatusFlag = true;

            // Send mail
            //SendEmail(inputObject.Accept.ClientCd, inputObject.Accept.AcceptSlipNo);

            // Execute convert ouput.
            responseModel = Convert(resultObject);

            return responseModel;
        }

        /// <summary>
        /// Execute send email.
        /// </summary>
        /// <param name="param">String</param>
        /// <returns>EmailModel</returns>
        private void SendEmail(string clientEmail, string acceptSlipNo)
        {
            // Local variable declaration
            MParameterCom mParameterCom = null;

            // Variable initialize
            mParameterCom = new MParameterCom();

            // Get data
            var emailModel = GetEmailModel(acceptSlipNo);
            var fileTemplate = FileHelper.ToString("/pages/media/email/accept-new.html");

            var email = mParameterCom.GetString(Logics.PR_EMAIL_SUPPORT, false);
            var emailPass = mParameterCom.GetString(Logics.PR_EMAIL_SUPPORT_PASS, false);
            var hostMail = mParameterCom.GetString(Logics.PR_MAIL_SERVER, false);
            var subject = string.Format("Xác nhận Đơn hàng #{0}", acceptSlipNo);
            var body = DataHelper.FormatString(fileTemplate, emailModel);

            MailHelper.SendMail(clientEmail, email, subject, body, hostMail);
            MailHelper.SendMail(email, clientEmail, subject, body, hostMail, emailPass);
        }

        /// <summary>
        /// Execute get email model.
        /// </summary>
        /// <param name="param">String</param>
        /// <returns>EmailModel</returns>
        private OutputEmailModel GetEmailModel(string param)
        {
            // Local variable declaration
            OutputEmailModel emailModel = null;
            ClientCheckoutDao clientCheckoutDao = null;
            MParameterCom mParameterCom = null;
            MCodeCom mCodeCom = null;
            IList<OutputAcceptDetailsModel> listAcceptDetails = null;

            // Variable initialize
            emailModel = new OutputEmailModel();
            clientCheckoutDao = new ClientCheckoutDao();
            mParameterCom = new MParameterCom();
            mCodeCom = new MCodeCom();
            listAcceptDetails = new List<OutputAcceptDetailsModel>();

            // Get data
            var accept = clientCheckoutDao.GetAccept(param);
            var strHotline = mParameterCom.GetString(Logics.PR_HOTLINE, false);
            var strEmail = mParameterCom.GetString(Logics.PR_EMAIL_SUPPORT, false);
            var paymentMethodsContent = mCodeCom.GetCodeContent(Logics.GROUP_PAYMENT_METHODS, accept.PaymentMethods);
            OutputAcceptDetailsModel acceptDetails = null;
            foreach (var obj in accept.AcceptDetails)
            {
                acceptDetails = new OutputAcceptDetailsModel();
                acceptDetails.ItemName = DataHelper.ToString(obj.ItemName);
                acceptDetails.DetailPrice = DataHelper.ToString(Formats.CURRENCY, obj.DetailPrice);
                acceptDetails.DetailQtty = DataHelper.ToString(Formats.NUMBER, obj.DetailQtty);
                acceptDetails.DetailAmt = DataHelper.ToString(Formats.CURRENCY, obj.DetailAmt);
                listAcceptDetails.Add(acceptDetails);
            }

            // Set data
            emailModel.AcceptSlipNo = DataHelper.ToString(accept.AcceptSlipNo);
            emailModel.ViewId = DataHelper.ToString(accept.ViewId);
            emailModel.AcceptDate = DataHelper.ToString(Formats.RFC_DATE, accept.AcceptDate);
            emailModel.ClientName = DataHelper.ToString(accept.ClientName);
            emailModel.ClientAddress = DataHelper.ToString(accept.ClientAddress);
            emailModel.ClientTel = DataHelper.ToString(accept.ClientTel);
            emailModel.DeliveryName = DataHelper.ToString(accept.DeliveryName);
            emailModel.DeliveryAddress = DataHelper.ToString(accept.DeliveryAddress);
            emailModel.DeliveryTel = DataHelper.ToString(accept.DeliveryTel);
            emailModel.PaymentMethodsContent = DataHelper.ToString(paymentMethodsContent);
            emailModel.Notes = DataHelper.ToString(accept.Notes);
            emailModel.Hotline = DataHelper.ToString(strHotline);
            emailModel.EmailSupport = DataHelper.ToString(strEmail);
            emailModel.AcceptDetails = listAcceptDetails;
            emailModel.TotalAmount = DataHelper.ToString(Formats.CURRENCY, accept.TotalAmount);

            // Return value;
            return emailModel;
        }
        #endregion
    }
}