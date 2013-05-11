using System;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.AcceptDetails;
using MiBo.Domain.Web.Client.AcceptDetails;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Common.Helper;
using MiBo.Domain.Dao;
using MiBo.Domain.Common.Dao;

namespace MiBo.pages.cln
{
    public partial class order_details : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
            fvwAccept.DataSource = response.Details;
            fvwAccept.DataBind();
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                request.AcceptSlipNo = Request["order"];
                request.ViewId = Request["view"];
                return request;
            }
        }
        protected void CheckOut_Command(object sender, CommandEventArgs e)
        {
            ClientCheckoutDao checkout = new ClientCheckoutDao();
            Accept acc = checkout.getAcceptById(e.CommandArgument.ToString().Trim());
            if (acc != null)
            {
                string total = acc.TotalAmt.ToString() + "00";
                string genId = DataHelper.GetUniqueKey();
                Session["AcceptSlipNo"] = acc.AcceptSlipNo;
                checkout.updateGenId(acc.AcceptSlipNo, genId);
                Session["isPrePay"] = true;
                makePay(genId, total);
            }
        }
        public void makePay(string genId,string totalAtm)
        {
            string ipaddress;
            ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
            {
                ipaddress = Request.ServerVariables["REMOTE_ADDR"];
            }
            string SECURE_SECRET = "A3EFDFABA8653DF2342E8DAC29B51AF0";
            // Khoi tao lop thu vien va gan gia tri cac tham so gui sang cong thanh toan
            VPCRequest conn = new VPCRequest("http://mtf.onepay.vn/onecomm-pay/vpc.op");
            conn.SetSecureSecret(SECURE_SECRET);
            // Add the Digital Order Fields for the functionality you wish to use
            // Core Transaction Fields
            conn.AddDigitalOrderField("Title", "Mibo.vn - Cong thanh toan OnePay");
            conn.AddDigitalOrderField("vpc_Locale", "vn");//Chon ngon ngu hien thi tren cong thanh toan (vn/en)
            conn.AddDigitalOrderField("vpc_Version", "2");
            conn.AddDigitalOrderField("vpc_Command", "pay");
            conn.AddDigitalOrderField("vpc_Merchant", "ONEPAY");
            conn.AddDigitalOrderField("vpc_AccessCode", "D67342C2");
            conn.AddDigitalOrderField("vpc_MerchTxnRef", genId);
            conn.AddDigitalOrderField("vpc_OrderInfo", "Tin Hoc Nguyen Phong - Mibo.vn");
            conn.AddDigitalOrderField("vpc_Amount", totalAtm);
            conn.AddDigitalOrderField("vpc_Currency", "VND");
            conn.AddDigitalOrderField("vpc_ReturnURL", "http://localhost:2593/pages/cln/pay-process.aspx");
            // Dia chi IP cua khach hang
            conn.AddDigitalOrderField("vpc_TicketNo", ipaddress);
            // Chuyen huong trinh duyet sang cong thanh toan
            String url = conn.Create3PartyQueryString();
            Page.Response.Redirect(url);
        }
    }
}