using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.ItemDetails;
using MiBo.Domain.Web.Client.ItemDetails;
using MiBo.Domain.Common.Helper;

namespace MiBo.pages.cln
{
    public partial class item_details : BasePage
    {
        public InitResponseModel Val { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (response == null) Redirect("index.aspx");

            // Set value
            Val = response;
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var request = new InitRequestModel();
                request.ItemCd = Request["pid"];
                request.ItemName = Request["pnm"];
                return request;
            }
        }
    }
}