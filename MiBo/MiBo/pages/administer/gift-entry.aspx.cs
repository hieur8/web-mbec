using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.GiftEntry;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Web.Admin.GiftEntry;
using MiBo.Domain.Common.Helper;

namespace MiBo.pages.administer
{
    public partial class gift_entry : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) { Redirect(Pages.ADMIN_INDEX); return; }
            fvwGiftDatails.DataSource = response.Details;
            fvwGiftDatails.DataBind();
        }

        protected void btnSave_Command(object sender, CommandEventArgs e)
        {
            var logic = new SaveOperateLogic();
            var response = Invoke(logic, SaveRequestModel);
            if (HasError) return;
            Response.Redirect(Pages.ADMIN_GIFT_LIST);
        }

        protected void btnList_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(Pages.ADMIN_GIFT_LIST);
        }

        protected void btnGen_Command(object sender, CommandEventArgs e)
        {
            ((TextBox)fvwGiftDatails.FindControl("txtGiftCd")).Text = DataHelper.RandomString(10, true);
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                return request;
            }
        }

        private SaveRequestModel SaveRequestModel
        {
            get
            {
                var request = new SaveRequestModel();
                request.GiftCd = ((TextBox)fvwGiftDatails.FindControl("txtGiftCd")).Text;
                request.Price = ((TextBox)fvwGiftDatails.FindControl("txtPrice")).Text;
                request.StartDate = ((TextBox)fvwGiftDatails.FindControl("txtStartDate")).Text;
                request.EndDate = ((TextBox)fvwGiftDatails.FindControl("txtEndDate")).Text;
                request.Notes = ((TextBox)fvwGiftDatails.FindControl("txtNotes")).Text;

                return request;
            }
        }
    }
}