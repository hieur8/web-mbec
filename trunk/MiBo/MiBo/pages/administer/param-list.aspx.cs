using System;
using System.Linq;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.ParamList;
using MiBo.Domain.Web.Admin.ParamList;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace MiBo.pages.administer
{
    public partial class param_list : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
            rptParams.DataSource = response.ListParams;
            rptParams.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var updateLogic = new UpdateOperateLogic();
            var responseModel = Invoke(updateLogic, UpdateRequestModel);
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

        private UpdateRequestModel UpdateRequestModel
        {
            get
            {
                OutputParamModel param = null;
                var requestModel = new UpdateRequestModel();
                var listParams = new List<OutputParamModel>();
                foreach (RepeaterItem row in rptParams.Items)
                {
                    if (!((CheckBox)row.FindControl("chkEdit")).Checked) continue;
                    param = new OutputParamModel();
                    param.ParamCd = ((HiddenField)row.FindControl("hidParamCd")).Value;
                    param.ParamValue = ((TextBox)row.FindControl("txtParamValue")).Text;
                    listParams.Add(param);
                }
                requestModel.ListParams = listParams;
                return requestModel;
            }
        }
    }
}