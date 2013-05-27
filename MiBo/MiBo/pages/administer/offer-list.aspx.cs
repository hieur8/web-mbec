using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.OfferList;
using MiBo.Domain.Web.Admin.OfferList;

namespace MiBo.pages.administer
{
    public partial class offer_list : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) { Redirect(Pages.ADMIN_INDEX); return; }
            rptOffers.DataSource = response.ListOffers;
            rptOffers.DataBind();
            ddlOfferDiv.DataSource = response.ListOfferDiv;
            ddlOfferDiv.DataBind();
            ddlDeleteFlag.DataSource = response.ListDeleteFlag;
            ddlDeleteFlag.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var logic = new FilterOperateLogic();
            var response = Invoke(logic, FilterRequestModel);
            if (HasError) return;
            rptOffers.DataSource = response.ListOffers;
            rptOffers.DataBind();
        }

        protected void btnAction_Command(object sender, CommandEventArgs e)
        {
            Session["OfferCd"] = e.CommandArgument;
            if (e.CommandName == "list")
                Redirect(Pages.ADMIN_OFFER_ITEM_LIST);
            else Redirect(Pages.ADMIN_OFFER_ITEM_ENTRY);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var logic = new UpdateOperateLogic();
            var response = Invoke(logic, UpdateRequestModel);
            if (HasError) return;
            Refresh();
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var requestModel = new InitRequestModel();
                return requestModel;
            }
        }
        private FilterRequestModel FilterRequestModel
        {
            get
            {
                var request = new FilterRequestModel();
                request.ItemCd = txtItemCd.Text;
                request.OfferDiv = ddlOfferDiv.SelectedValue;
                request.DeleteFlag = ddlDeleteFlag.SelectedValue;
                return request;
            }
        }
        private UpdateRequestModel UpdateRequestModel
        {
            get
            {
                OutputOfferModel offer = null;
                var requestModel = new UpdateRequestModel();
                var listOffers = new List<OutputOfferModel>();
                foreach (RepeaterItem row in rptOffers.Items)
                {
                    if (!((CheckBox)row.FindControl("chkEdit")).Checked) continue;
                    offer = new OutputOfferModel();
                    offer.OfferCd = ((HiddenField)row.FindControl("hidOfferCd")).Value;
                    offer.OfferGroupCd = ((TextBox)row.FindControl("txtOfferGroupCd")).Text;
                    offer.ItemCd = ((TextBox)row.FindControl("txtItemCd")).Text;
                    offer.StartDate = ((TextBox)row.FindControl("txtStartDate")).Text;
                    offer.EndDate = ((TextBox)row.FindControl("txtEndDate")).Text;
                    offer.Percent = ((TextBox)row.FindControl("txtPercent")).Text;
                    offer.Notes = ((TextBox)row.FindControl("txtNotes")).Text;
                    offer.DeleteFlag = ((DropDownList)row.FindControl("ddlDeleteFlag")).SelectedValue;
                    listOffers.Add(offer);
                }
                requestModel.ListOffers = listOffers;
                return requestModel;
            }
        }
    }
}