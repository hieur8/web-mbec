using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Dao;

namespace MiBo.pages.administer
{
    public partial class checkpay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isCheckPay"] != null && Session["AcceptSlipNo"] != null)
            {
                Session["isCheckPay"] = null;
                if (Request["vpc_TxnResponseCode"] != null)
                {
                    if (Request["vpc_TxnResponseCode"].ToString().Equals("0"))
                    {
                        ClientCheckoutDao clientCheckoutDao = new ClientCheckoutDao();
                        clientCheckoutDao.updateStatus(Session["AcceptSlipNo"].ToString(), "02");
                        Label1.Text = "Đơn hàng này đã thanh toán, trạng thái đơn hàng đã được cập nhật";
                    }
                    else
                    {
                        Label1.Text = "Đơn hàng này vẫn chưa thanh toán !";
                    }
                }
                Session["AcceptSlipNo"] = null;
            }
        }
    }
}