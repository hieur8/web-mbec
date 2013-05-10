using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.OfferItemList;
using MiBo.Domain.Web.Admin.OfferItemList;

namespace MiBo.pages.administer
{
    public partial class offer_item_list : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) { Redirect(Pages.ADMIN_INDEX); return; }
            rptOfferItems.DataSource = response.ListOfferItems;
            rptOfferItems.DataBind();
            hidOfferCd.Value = response.OfferCd;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var logic = new UpdateOperateLogic();
            var response = Invoke(logic, UpdateRequestModel);
            if (HasError) return;
            Refresh();
        }

        protected void btnList_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(Pages.ADMIN_OFFER_LIST);
        }

        protected void btnAdd_Command(object sender, CommandEventArgs e)
        {
            Session["OfferCd"] = hidOfferCd.Value;
            Response.Redirect(Pages.ADMIN_OFFER_ITEM_ENTRY);
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var requestModel = new InitRequestModel();
                requestModel.OfferCd = Convert.ToString(Session["OfferCd"]);
                return requestModel;
            }
        }

        private UpdateRequestModel UpdateRequestModel
        {
            get
            {
                OutputOfferItemModel offerItem = null;
                var requestModel = new UpdateRequestModel();
                var listOfferItems = new List<OutputOfferItemModel>();
                foreach (RepeaterItem row in rptOfferItems.Items)
                {
                    if (!((CheckBox)row.FindControl("chkEdit")).Checked) continue;
                    offerItem = new OutputOfferItemModel();
                    offerItem.OfferCd = ((HiddenField)row.FindControl("hidOfferCd")).Value;
                    offerItem.DetailNo = ((HiddenField)row.FindControl("hidDetailNo")).Value;
                    offerItem.OfferItemCd = ((TextBox)row.FindControl("txtOfferItemCd")).Text;
                    offerItem.OfferItemQtty = ((TextBox)row.FindControl("txtOfferItemQtty")).Text;
                    offerItem.DeleteFlag = ((DropDownList)row.FindControl("ddlDeleteFlag")).SelectedValue;
                    listOfferItems.Add(offerItem);
                }
                requestModel.ListOfferItems = listOfferItems;
                return requestModel;
            }
        }
    }
}