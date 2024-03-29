﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.GroupEntry;
using MiBo.Domain.Web.Admin.GroupEntry;

namespace MiBo.pages.administer
{
    public partial class group_entry : BasePage
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
            Response.Redirect(Pages.ADMIN_GROUP_LIST);
        }

        protected void btnList_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(Pages.ADMIN_GROUP_LIST);
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
                request.GroupCd = ((TextBox)fvwGroupDatails.FindControl("txtGroupCd")).Text;
                request.GroupName = ((TextBox)fvwGroupDatails.FindControl("txtGroupName")).Text;
                request.SortKey = ((TextBox)fvwGroupDatails.FindControl("txtSortKey")).Text;
                request.DeleteFlag = ((DropDownList)fvwGroupDatails.FindControl("ddlDeleteFlag")).SelectedValue;

                return request;
            }
        }
    }
}