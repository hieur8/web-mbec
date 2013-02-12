using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Controller;

namespace MiBo.pages.common
{
    public partial class administer : BaseMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkSignOut_Command(object sender, CommandEventArgs e)
        {
            Session["UserId"] = null;
            Session["UserName"] = null;
            Session["LocaleId"] = null;
            //Response.Redirect(Pages.ADMIN_USERS_LOGIN);
        }
    }
}