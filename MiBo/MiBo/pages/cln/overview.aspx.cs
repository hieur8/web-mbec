using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;

namespace MiBo.pages.cln
{
    public partial class overview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Cart"] == null || Session["payMethod"] == null)
            {
                Response.Redirect(Pages.CLIENT_INDEX);
            }
            else
            {
                Session["Cart"] = null;
                Session["payMethod"] = null;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(Pages.CLIENT_INDEX);
        }
    }
}