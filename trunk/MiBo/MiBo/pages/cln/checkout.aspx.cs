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

namespace MiBo.pages.cln
{
    public partial class checkout : BasePage
    {
        public User result = new User();
        protected void Page_Load(object sender, EventArgs e)
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
                }


            }
           
        
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            

            var logic = new CheckoutOperateLogic();
            var response = Invoke(logic, CheckoutRequestModel);
            if (!response.StatusFlag)
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

                    accept.ClientCd = result.Email;
                }
                else
                {
                    accept.ClientCd = "77620f22-b900-4fbb-b0d8-a5d161d3f143";
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
                accept.Notes = note.Text.ToString();
                accept.CreateUser = accept.ClientCd;
                accept.CreateDate = dateNow;
                accept.UpdateUser = accept.ClientCd;
                accept.UpdateDate = dateNow;
                accept.DeleteFlag = false;
                if (pay1.Checked)
                {
                    accept.PaymentMethods = "01";
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
                request.Accept = accept;
                request.Cart = Session["Cart"];

                return request;
               
            }
        }

        
    }
}