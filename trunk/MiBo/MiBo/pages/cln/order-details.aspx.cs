using System;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.AcceptDetails;
using MiBo.Domain.Web.Client.AcceptDetails;

namespace MiBo.pages.cln
{
    public partial class order_details : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
            fvwAccept.DataSource = response.Details;
            fvwAccept.DataBind();
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                request.AcceptSlipNo = Request["order"];
                request.ViewId = Request["view"];
                return request;
            }
        }
    }
}