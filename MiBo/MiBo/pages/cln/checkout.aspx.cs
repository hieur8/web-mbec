using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Dao;
using MiBo.Domain.Logic.Client.Checkout;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Web.Client.Checkout;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Web.Client.Register;
using MiBo.Domain.Logic.Client.Register;

namespace MiBo.pages.cln
{
    public partial class checkout : BasePage
    {
        public User result = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            else
            {
                UserComDao userCom = new UserComDao();
                if (Session["Cart"] == null || Session["payMethod"] == null)
                {
                    Response.Redirect(Pages.CLIENT_INDEX);
                }
                if (Session["payMethod"].ToString().Equals("1"))
                {
                    if (Session["userCd"] == null)
                    {
                        Response.Redirect(Pages.CLIENT_LOGIN);
                    }
                    Guid userCd = new Guid(Session["userCd"].ToString());

                    result = userCom.GetSingle(userCd, false);
                    if (result == null)
                    {
                        Response.Redirect(Pages.CLIENT_LOGIN);
                    }
                    else
                    {
                        clientName.Text = result.FullName;
                        clientAddress.Text = result.Address;
                        clientTell.Text = result.Phone1;
                        txtClientCd.Value = result.Email;
                    }


                }
            }
           
        
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["payMethod"].ToString().Equals("0"))
            {
                var logicRegister = new SaveOperateLogic();
                var responseRegister = Invoke(logicRegister, SaveRequestModel);
                if (HasError) return;
            }
            var logic = new CheckoutOperateLogic();
            var response = Invoke(logic, CheckoutRequestModel);
            if (HasError)
            {
                Session["msgInfo"] = "Có lỗi trong quá trình thanh toán, vui lòng thử lại !";
            }

            Response.Redirect(Pages.CLIENT_OVERVIEW);
        }
        private CheckoutRequestModel CheckoutRequestModel
        {
            get
            {
                var request = new CheckoutRequestModel();
                DateTime dateNow = DateTime.Now;
                Accept accept = new Accept();
                if (Session["payMethod"].ToString().Equals("1"))
                {

                    accept.ClientCd = txtClientCd.Value.ToString();
                }
                else
                {
                    accept.ClientCd = email.Text.Trim().ToString();
                }
                accept.AcceptDate = DateTime.Now;
                accept.ClientName = clientName.Text.Trim();
                accept.ClientAddress = clientAddress.Text.Trim();
                accept.ClientTel = clientTell.Text.Trim();
                accept.DeliveryName = deliveryName.Text.Trim();
                if (!deliveryDate.Text.Equals(""))
                {
                    accept.WishDeliveryDate = DateTime.Parse(deliveryDate.Text.Trim());
                }
                accept.DeliveryName = deliveryName.Text;
                accept.DeliveryAddress = deliveryAddress.Text;
                accept.DeliveryTel = deliveryTell.Text;
                accept.Notes = note.Text.ToString();
                accept.CreateUser = accept.ClientCd;
                accept.CreateDate = dateNow;
                accept.UpdateUser = accept.ClientCd;
                accept.UpdateDate = dateNow;
                accept.DeleteFlag = false;
                if (pay1.Checked)
                {
                    accept.PaymentMethods = "01";
                    accept.SlipStatus = "01";
                }
                else if (pay2.Checked)
                {
                    accept.SlipStatus = "02";
                }
                else if (pay3.Checked)
                {
                    accept.SlipStatus = "03";
                }
                else
                {
                    accept.SlipStatus = "04";
                }
                accept.Notes = note.Text;
                request.Accept = accept;
                request.Cart = Session["Cart"];
                if (Session["GiftCd"] != null)
                {
                    accept.UseGiftCd = Session["GiftCd"].ToString();
                }
                return request;
               
            }
        }

        private SaveRequestModel SaveRequestModel
        {
            get
            {
                var request = new SaveRequestModel();
                request.Email = email.Text.Trim().ToString();
                request.Password = pass.Text.ToString();
                request.Fullname = clientName.Text.Trim();
                request.Address = clientAddress.Text.Trim();
                request.Phone1 = clientTell.Text.Trim();
                return request;
            }
        }
    }
}