using System;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Common.Helper;

namespace MiBo.pages.common
{
    public partial class administer : BaseMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!PageHelper.HasAuthByAdmin)
                Response.Redirect(GetUrlWithReturnUrl(Pages.ADMIN_USER_LOGIN));
        }

        protected void lnkSignOut_Command(object sender, CommandEventArgs e)
        {
            Session["userCd"] = null;
            Session["userName"] = null;
            Session["localeId"] = null;
            Response.Redirect(Pages.ADMIN_USER_LOGIN);
        }
    }
}