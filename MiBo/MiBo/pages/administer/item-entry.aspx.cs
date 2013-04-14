using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.ItemEntry;
using MiBo.Domain.Web.Admin.ItemEntry;

namespace MiBo.pages.administer
{
    public partial class item_entry : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) { Redirect(Pages.ADMIN_INDEX); return; }
            fvwItemDatails.DataSource = response.Details;
            fvwItemDatails.DataBind();
        }

        protected void btnSave_Command(object sender, CommandEventArgs e)
        {
            var logic = new SaveOperateLogic();
            var response = Invoke(logic, SaveRequestModel);
            if (HasError) return;
            Session["Status"] = null;
            Response.Redirect(Pages.ADMIN_ITEM_LIST);
        }

        protected void btnList_Command(object sender, CommandEventArgs e)
        {
            Session["Status"] = null;
            Response.Redirect(Pages.ADMIN_ITEM_LIST);
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                if (Session["Status"] == null)
                    Session["Status"] = Logics.CODE_STATUS_ADD;
                request.Status = Convert.ToString(Session["Status"]);
                request.ItemCd = Convert.ToString(Session["ItemCd"]);
                Session["Status"] = null;
                Session["ItemCd"] = null;
                return request;
            }
        }

        private SaveRequestModel SaveRequestModel
        {
            get
            {
                var request = new SaveRequestModel();
                request.Status = ((HiddenField)fvwItemDatails.FindControl("hidStatus")).Value;
                request.FileId = ((HiddenField)fvwItemDatails.FindControl("hidFileId")).Value;
                request.ItemSearchName = ((HiddenField)fvwItemDatails.FindControl("hidItemSearchName")).Value;
                request.ItemCd = ((TextBox)fvwItemDatails.FindControl("txtItemCd")).Text;
                request.ItemName = ((TextBox)fvwItemDatails.FindControl("txtItemName")).Text;
                request.CategoryCd = ((DropDownList)fvwItemDatails.FindControl("ddlCategory")).SelectedValue;
                request.AgeCd = ((DropDownList)fvwItemDatails.FindControl("ddlAge")).SelectedValue;
                request.GenderCd = ((DropDownList)fvwItemDatails.FindControl("ddlGender")).SelectedValue;
                request.BrandCd = ((DropDownList)fvwItemDatails.FindControl("ddlBrand")).SelectedValue;
                request.CountryCd = ((DropDownList)fvwItemDatails.FindControl("ddlCountry")).SelectedValue;
                request.UnitCd = ((DropDownList)fvwItemDatails.FindControl("ddlUnit")).SelectedValue;
                request.ItemDiv = ((DropDownList)fvwItemDatails.FindControl("ddlItemDiv")).SelectedValue;
                request.SortKey = ((TextBox)fvwItemDatails.FindControl("txtSortKey")).Text;
                request.LinkVideo = ((TextBox)fvwItemDatails.FindControl("txtLinkVideo")).Text;
                request.Material = ((TextBox)fvwItemDatails.FindControl("txtMaterial")).Text;
                request.SummaryNotes = ((TextBox)fvwItemDatails.FindControl("txtSummaryNotes")).Text;
                request.Notes = ((TextBox)fvwItemDatails.FindControl("txtContents")).Text;
                request.DeleteFlag = ((DropDownList)fvwItemDatails.FindControl("ddlDeleteFlag")).SelectedValue;
                request.SalesPrice = ((TextBox)fvwItemDatails.FindControl("txtSalesPrice")).Text;
                request.BuyingPrice = ((TextBox)fvwItemDatails.FindControl("txtBuyingPrice")).Text;

                return request;
            }
        }
    }
}