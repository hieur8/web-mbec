using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Web.Client.Register;
using MiBo.Domain.Web.Client.Checkout;
using MiBo.Domain.Common.Helper;
using Resources;
using MiBo.Domain.Logic.Client.Register;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.Checkout;
using System.Text;

namespace MiBo.pages.cln
{
    public partial class confirm_checkout : BasePage
    {
        public decimal total = 0;
        public string genId = DataHelper.GetUniqueKey();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            if (Session["Cart"] == null || Session["payMethod"] == null)
            {
                Response.Redirect(Pages.CLIENT_INDEX);
            }
            if (Session["CheckoutRequestModel"] == null || Session["hasCheckout"] == null)
            {
                Response.Redirect(Pages.CLIENT_CHECKOUT);
            }
            if (Session["payMethod"].ToString().Equals("0") && Session["SaveRequestModel"] == null)
            {
                Response.Redirect(Pages.CLIENT_CHECKOUT);
            }
            else
            {
                Session["hasCheckout"] = null;
            }
            
            //load data
            MCodeCom codeCom = new MCodeCom();
            IList<ComboItem> citylst = MCodeCom.ToComboItems(codeCom.GetListCity(), "294").ListItems;
            DropDownList1.DataSource = citylst;
            DropDownList1.DataBind();
            DropDownList1.SelectedValue = "294";
            DropDownList2.DataSource = citylst;
            DropDownList2.DataBind();
            DropDownList2.SelectedValue = "294";

            if (Session["payMethod"].ToString().Equals("0"))
            {
                SaveRequestModel accCreate = (SaveRequestModel)Session["SaveRequestModel"];
                email.Text = accCreate.Email;
            }
            CheckoutRequestModel checkout = (CheckoutRequestModel)Session["CheckoutRequestModel"];
            Accept accept = checkout.Accept;
            clientName.Text = accept.ClientName;
            clientAddress.Text = accept.ClientAddress;
            clientTell.Text = accept.ClientTel;
            DropDownList1.SelectedValue = accept.ClientCityCd;
            deliveryName.Text = accept.DeliveryName;
            deliveryAddress.Text = accept.DeliveryAddress;
            deliveryTell.Text = accept.DeliveryTel;
            DropDownList2.SelectedValue = accept.DeliveryCityCd;
            note.Text = accept.Notes;
            if (accept.PaymentMethods == "01")
            {
                lblPay.Text = "Thanh toán tiền mặt khi nhận hàng";
            }
            else if (accept.PaymentMethods == "02")
            {
                lblPay.Text = "Thanh toán trực truyến bằng thẻ ATM - Internet Banking";
            }
            IList<CartItem> cart = (IList<CartItem>)Session["Cart"];
            CartCom cartCom = new CartCom(cart);
            decimal amount = cartCom.TotalAmount;
            decimal ship = 0;
            if (Session["GiftPrice"] != null && Session["GiftCd"] != null)
            {
                amount = amount - (decimal)Session["GiftPrice"];

            }
            total = amount;
            if (accept.DeliveryCityCd == "294")
            {
                if (amount < 200000)
                {
                    ship = 20000;
                    total = total + ship;
                }
            }
            else
            {
                if (amount < 1000000)
                {
                    ship = 30000;
                    total = total + ship;
                }
            }
            Label1.Text = DataHelper.ToString(Formats.CURRENCY, amount);
            if (ship != 0)
            {
                Label2.Text = DataHelper.ToString(Formats.CURRENCY, ship);
            }
            Label3.Text = DataHelper.ToString(Formats.CURRENCY, total);
            Session["TotalAmt"] = total;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            ccJoin.ValidateCaptcha(TextBox1.Text);
            if (!ccJoin.UserValidated)
            {
                Label4.Text = "Mã bảo vệ chưa chính xác";
                return;
            }
            if (Session["payMethod"].ToString().Equals("0"))
            {
                var logic = new SaveOperateLogic();
                var response = Invoke(logic, SaveRequestModel);
                if (HasError) return;
            }
            var checkout = new CheckoutOperateLogic();
            var result = Invoke(checkout, CheckoutRequestModel);
            if (HasError) return;
            Session["Cart"] = null;
            Session["payMethod"] = null;
            Session["GiftCd"] = null;
            Session["GiftPrice"] = null;
            Session["AcceptSlipNo"] = null;
            Session["isFirstPay"] = true;
            Session["AcceptSlipNo"] = result.AcceptSlipNo;
            if (CheckoutRequestModel.Accept.PaymentMethods == "02")
            {
                makePay(CheckoutRequestModel.Accept);
            }
            Response.Redirect(Pages.CLIENT_OVERVIEW);
        }

        private SaveRequestModel SaveRequestModel
        {
            get
            {
                var request = new SaveRequestModel();
                request = (SaveRequestModel)Session["SaveRequestModel"];
                return request;
            }
        }
        private CheckoutRequestModel CheckoutRequestModel
        {
            get
            {
                var request = new CheckoutRequestModel();
                request = (CheckoutRequestModel)Session["CheckoutRequestModel"];
                request.Accept.TotalAmt = (Decimal) Session["TotalAmt"];
                request.Accept.GenId = genId;
                return request;
            }
        }

        public void makePay(Accept acc)
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
            conn.AddDigitalOrderField("vpc_Amount", acc.TotalAmt.ToString()+"00");
            conn.AddDigitalOrderField("vpc_Currency", "VND");
            conn.AddDigitalOrderField("vpc_ReturnURL", "http://mibo.vn/pay-process.aspx");
            // Dia chi IP cua khach hang
            conn.AddDigitalOrderField("vpc_TicketNo", ipaddress);
            // Chuyen huong trinh duyet sang cong thanh toan
            String url = conn.Create3PartyQueryString();
            Page.Response.Redirect(url);
        }
    }
}