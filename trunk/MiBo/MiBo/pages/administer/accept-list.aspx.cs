using System;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.AcceptList;
using MiBo.Domain.Web.Admin.AcceptList;

namespace MiBo.pages.administer
{
    public partial class accept_list : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
            rptAccepts.DataSource = response.ListAccepts;
            rptAccepts.DataBind();
            txtAcceptDataStart.Text = response.AcceptDateStart;
            txtAcceptDataEnd.Text = response.AcceptDateEnd;
            ddlSlipStatus.Items.AddRange(response.ListSlipStatus);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var logic = new FilterOperateLogic();
            var response = Invoke(logic, FilterRequestModel);
            if (HasError) return;
            rptAccepts.DataSource = response.ListAccepts;
            rptAccepts.DataBind();
        }

        protected void btnAction_Command(object sender, CommandEventArgs e)
        {
            Session["AcceptSlipNo"] = e.CommandArgument;
            Redirect(Pages.ADMIN_ACCEPT_ENTRY);
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
                request.AcceptDateStart = txtAcceptDataStart.Text;
                request.AcceptDateEnd = txtAcceptDataEnd.Text;
                request.DeliveryDateStart = txtDeliveryDataStart.Text;
                request.DeliveryDateEnd = txtDeliveryDataEnd.Text;
                request.SlipNoStart = txtSlipNoStart.Text;
                request.SlipNoEnd = txtSlipNoEnd.Text;
                request.SlipStatus = ddlSlipStatus.SelectedValue;
                request.ClientCd = txtClientCd.Text;
                request.ClientName = txtClientName.Text;
                request.ItemCd = txtItemCd.Text;
                request.ItemName = txtItemName.Text;
                return request;
            }
        }
    }
}