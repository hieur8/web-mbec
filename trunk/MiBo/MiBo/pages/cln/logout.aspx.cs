using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MiBo.pages.cln
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["userCd"] = null;
            Session["userName"] = null;
            Response.Redirect("index.aspx");
        }
    }
}