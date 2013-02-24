using System;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.AcceptHistory;
using MiBo.Domain.Web.Client.AcceptHistory;

namespace MiBo.pages.cln
{
    public partial class order_history : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
            litAcceptCount.Text = response.AcceptCount;
            rptAccept.DataSource = response.ListAccepts;
            rptAccept.DataBind();
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                return request;
            }
        }
    }
}