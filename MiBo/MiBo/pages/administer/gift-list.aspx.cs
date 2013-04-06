using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.GiftList;
using MiBo.Domain.Web.Admin.GiftList;

namespace MiBo.pages.administer
{
    public partial class gift_list : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
            rptGifts.DataSource = response.ListGifts;
            rptGifts.DataBind();
            ddlGiftStatus.DataSource = response.ListGiftStatus;
            ddlGiftStatus.DataBind();
            ddlGiftStatus.SelectedValue = response.GiftStatus;
            ddlDeleteFlag.DataSource = response.ListDeleteFlag;
            ddlDeleteFlag.DataBind();
            ddlDeleteFlag.SelectedValue = response.DeleteFlag;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var logic = new FilterOperateLogic();
            var response = Invoke(logic, FilterRequestModel);
            if (HasError) return;
            rptGifts.DataSource = response.ListGifts;
            rptGifts.DataBind();
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
                request.GiftCd = txtGiftCd.Text;
                request.GiftStatus = ddlGiftStatus.SelectedValue;
                request.DeleteFlag = ddlDeleteFlag.SelectedValue;
                return request;
            }
        }

        private UpdateRequestModel UpdateRequestModel
        {
            get
            {
                OutputGiftModel gift = null;
                var requestModel = new UpdateRequestModel();
                var listGifts = new List<OutputGiftModel>();

                foreach (RepeaterItem row in rptGifts.Items)
                {
                    if (!((CheckBox)row.FindControl("chkEdit")).Checked) continue;
                    gift = new OutputGiftModel();
                    gift.GiftCd = ((HiddenField)row.FindControl("hidGiftCd")).Value;
                    gift.GiftStatus = ((DropDownList)row.FindControl("ddlGiftStatus")).SelectedValue;
                    listGifts.Add(gift);
                }

                requestModel.ListGifts = listGifts;
                return requestModel;
            }
        }
    }
}