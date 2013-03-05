using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;

namespace MiBo.pages.cln
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["userCd"] = null;
            Session["userName"] = null;
            Response.Redirect(Pages.CLIENT_INDEX);
        }
    }
}