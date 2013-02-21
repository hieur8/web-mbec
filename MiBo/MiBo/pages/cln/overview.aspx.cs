using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiBo.pages.cln
{
    public partial class overview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Cart"] == null || Session["payMethod"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                Session["Cart"] = null;
                Session["payMethod"] = null;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}