using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.OfferItemEntry;
using MiBo.Domain.Web.Admin.OfferItemEntry;

namespace MiBo.pages.administer
{
    public partial class offer_item_entry : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) { Redirect(Pages.ADMIN_INDEX); return; }
            fvwOfferItemDatails.DataSource = response.Details;
            fvwOfferItemDatails.DataBind();
        }

        protected void btnSave_Command(object sender, CommandEventArgs e)
        {
            var logic = new SaveOperateLogic();
            var response = Invoke(logic, SaveRequestModel);
            if (HasError) return;
            Session["OfferCd"] = response.OfferCd;
            Response.Redirect(Pages.ADMIN_OFFER_ITEM_LIST);
        }

        protected void btnList_Command(object sender, CommandEventArgs e)
        {
            Session["OfferCd"] = ((HiddenField)fvwOfferItemDatails.FindControl("hidOfferCd")).Value;
            Response.Redirect(Pages.ADMIN_OFFER_ITEM_LIST);
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                request.OfferCd = Convert.ToString(Session["OfferCd"]);
                return request;
            }
        }

        private SaveRequestModel SaveRequestModel
        {
            get
            {
                var request = new SaveRequestModel();
                request.OfferCd = ((HiddenField)fvwOfferItemDatails.FindControl("hidOfferCd")).Value;
                request.OfferItemCd = ((TextBox)fvwOfferItemDatails.FindControl("txtOfferItemCd")).Text;
                request.OfferItemQtty = ((TextBox)fvwOfferItemDatails.FindControl("txtOfferItemQtty")).Text;
                request.DeleteFlag = ((DropDownList)fvwOfferItemDatails.FindControl("ddlDeleteFlag")).SelectedValue;
                return request;
            }
        }
    }
}