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

namespace MiBo.pages.cln
{
    public partial class confirm_checkout : BasePage
    {
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
            DropDownList1.SelectedValue = accept.CreateUser;
            deliveryName.Text = accept.DeliveryName;
            deliveryAddress.Text = accept.DeliveryAddress;
            deliveryTell.Text = accept.DeliveryTel;
            DropDownList2.SelectedValue = accept.UpdateUser;
            note.Text = accept.Notes;

            IList<CartItem> cart = (IList<CartItem>)Session["Cart"];
            CartCom cartCom = new CartCom(cart);
            decimal amount = cartCom.TotalAmount;
            decimal ship = 0;
            decimal total = amount;
            if (Session["GiftPrice"] != null && Session["GiftCd"] != null)
            {
                amount = amount - (decimal)Session["GiftPrice"];

            }
            if (accept.UpdateUser == "294")
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
                return request;
            }
        }
    }
}