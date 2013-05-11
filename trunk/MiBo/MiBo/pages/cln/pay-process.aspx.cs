using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Web.Client.Checkout;
using MiBo.Domain.Logic.Client.Checkout;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Dao;
using MiBo.Domain.Common.Constants;

namespace MiBo.pages.cln
{
    public partial class pay_process : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["isPrePay"] == null)
            {
                if (Session["isFirstPay"] == null)
                {

                    Response.Redirect(Pages.CLIENT_INDEX);
                }
            }
            if (Session["AcceptSlipNo"] == null)
            {
                Response.Redirect(Pages.CLIENT_INDEX);
            }
            if (IsPostBack) return;

            string SECURE_SECRET = "A3EFDFABA8653DF2342E8DAC29B51AF0";
            string hashvalidateResult = "";
            // Khoi tao lop thu vien
            VPCRequest conn = new VPCRequest("http://onepay.vn");
            conn.SetSecureSecret(SECURE_SECRET);
            // Xu ly tham so tra ve va kiem tra chuoi du lieu ma hoa
            hashvalidateResult = conn.Process3PartyResponse(Page.Request.QueryString);

            // Lay gia tri tham so tra ve tu cong thanh toan
            String vpc_TxnResponseCode = conn.GetResultField("vpc_TxnResponseCode", "Unknown");
            string amount = conn.GetResultField("vpc_Amount", "Unknown");
            string localed = conn.GetResultField("vpc_Locale", "Unknown");
            string command = conn.GetResultField("vpc_Command", "Unknown");
            string version = conn.GetResultField("vpc_Version", "Unknown");
            string cardBin = conn.GetResultField("vpc_Card", "Unknown");
            string orderInfo = conn.GetResultField("vpc_OrderInfo", "Unknown");
            string merchantID = conn.GetResultField("vpc_Merchant", "Unknown");
            string authorizeID = conn.GetResultField("vpc_AuthorizeId", "Unknown");
            string merchTxnRef = conn.GetResultField("vpc_MerchTxnRef", "Unknown");
            string transactionNo = conn.GetResultField("vpc_TransactionNo", "Unknown");
            string txnResponseCode = vpc_TxnResponseCode;
            string message = conn.GetResultField("vpc_Message", "Unknown");

            if (hashvalidateResult == "CORRECTED" && txnResponseCode.Trim() == "0")
            {
                ClientCheckoutDao clientCheckoutDao = new ClientCheckoutDao();
                clientCheckoutDao.updateStatus(Session["AcceptSlipNo"].ToString(), "02");
                vpc_Result.Text = "<center><h1>Đặt hàng thành công</h1><br/>Đơn hàng của bạn đã được gởi đến bộ phận bán hàng của Mibo. Bạn cũng có thể theo dõi đơn hàng của bạn <a href='order-history.aspx'>tại đây</a></center>";

            }
            else if (hashvalidateResult == "INVALIDATED" && txnResponseCode.Trim() == "0")
            {
                Response.Redirect(Pages.CLIENT_INDEX);
            }
            else if (hashvalidateResult == "CORRECTED" && txnResponseCode.Trim() == "99")
            {

                Response.Redirect(Pages.CLIENT_INDEX);
            }
            else
            {
                vpc_Result.Text = "<center><h1>Đặt hàng không thành công</h1> ! <br/>Có lỗi trong quá trình thanh toán. vui lòng thử lại <a href='checkout.aspx'>tại đây</a></center>";
            }
        }

    }
}