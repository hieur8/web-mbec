using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.OfferEntry;
using MiBo.Domain.Web.Admin.OfferEntry;

namespace MiBo.pages.administer
{
    public partial class offer_entry : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) { Redirect(Pages.ADMIN_INDEX); return; }
            fvwGroupDatails.DataSource = response.Details;
            fvwGroupDatails.DataBind();
        }

        protected void btnSave_Command(object sender, CommandEventArgs e)
        {
            var logic = new SaveOperateLogic();
            var response = Invoke(logic, SaveRequestModel);
            if (HasError) return;
            Response.Redirect(Pages.ADMIN_OFFER_LIST);
        }

        protected void btnList_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(Pages.ADMIN_OFFER_LIST);
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
                request.OfferCd = ((TextBox)fvwGroupDatails.FindControl("txtOfferCd")).Text;
                request.ItemCd = ((TextBox)fvwGroupDatails.FindControl("txtItemCd")).Text;
                request.StartDate = ((TextBox)fvwGroupDatails.FindControl("txtStartDate")).Text;
                request.EndDate = ((TextBox)fvwGroupDatails.FindControl("txtEndDate")).Text;
                request.Percent = ((TextBox)fvwGroupDatails.FindControl("txtPercent")).Text;
                request.Notes = ((TextBox)fvwGroupDatails.FindControl("txtNotes")).Text;
                request.OfferDiv = ((DropDownList)fvwGroupDatails.FindControl("ddlOfferDiv")).SelectedValue;
                return request;
            }
        }
    }
}