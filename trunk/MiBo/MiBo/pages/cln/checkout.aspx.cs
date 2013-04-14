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
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Common.Model;
using MiBo.Domain.Common.Helper;
using Resources;
using MiBo.Domain.Model.Client.Checkout;

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
                //load data
                MCodeCom codeCom = new MCodeCom();
                IList<ComboItem> citylst = MCodeCom.ToComboItems(codeCom.GetListCity(), "294").ListItems;
                DropDownList1.DataSource = citylst;
                DropDownList1.DataBind();
                DropDownList1.SelectedValue = "294";
                DropDownList2.DataSource = citylst;
                DropDownList2.DataBind();
                DropDownList2.SelectedValue = "294";

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
                        DropDownList1.SelectedValue = result.CityCd;

                        RadioButton1.Checked = true;

                        deliveryName.Text = result.FullName;
                        deliveryAddress.Text = result.Address;
                        deliveryTell.Text = result.Phone1;
                        DropDownList2.SelectedValue = result.CityCd;

                    }


                }
                else
                {
                    methodDelivery1.Checked = true;
                }


            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["payMethod"].ToString().Equals("0"))
            {
                setSaveRequestModel();
            }
            setCheckoutRequestModel();

            Session["hasCheckout"] = true;
            Response.Redirect(Pages.CLIENT_CONFIRM_CHECKOUT);
        }
        private void setCheckoutRequestModel()
        {
         
                CheckoutRequestModel request = new CheckoutRequestModel();
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
                accept.DeliveryAddress = deliveryAddress.Text;
                accept.DeliveryTel = deliveryTell.Text;
                accept.Notes = note.Text.ToString();
                accept.CreateDate = dateNow;
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
                accept.CreateUser = DropDownList1.SelectedValue;
                accept.UpdateUser = DropDownList2.SelectedValue;
                
                request.Accept = accept;
                request.Cart = Session["Cart"];
            
                if (Session["GiftCd"] != null)
                {
                    accept.UseGiftCd = Session["GiftCd"].ToString();
                }
                Session["CheckoutRequestModel"] = request;      
        }

        private void setSaveRequestModel()
        {
                SaveRequestModel request = new SaveRequestModel();
                request.Email = email.Text.Trim().ToString();
                request.Password = pass.Text.ToString();
                request.Fullname = clientName.Text.Trim();
                request.Address = clientAddress.Text.Trim();
                request.Phone1 = clientTell.Text.Trim();
                request.CityCd = DropDownList1.SelectedValue;
                Session["SaveRequestModel"] = request;
        }


    }
}