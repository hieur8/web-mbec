using System;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Client.Register;
using MiBo.Domain.Web.Client.Register;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Common.Dao;
using System.Collections;
using System.Collections.Generic;
using MiBo.Domain.Common.Model;

namespace MiBo.pages.cln
{
    public partial class register : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            MCodeCom codeCom = new MCodeCom();
            IList<ComboItem> citylst = MCodeCom.ToComboItems(codeCom.GetListCity(), "294").ListItems;
            DropDownList1.DataSource = citylst;
            DropDownList1.DataBind();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            ccJoin.ValidateCaptcha(TextBox1.Text);
            if (!ccJoin.UserValidated)
            {
                Label1.Text = "Mã bảo vệ chưa chính xác";
                return;
            }
            var logic = new SaveOperateLogic();
            var response = Invoke(logic, SaveRequestModel);
            if (HasError) return;
            Response.Redirect(Pages.CLIENT_ACTIVE);
        }

        private SaveRequestModel SaveRequestModel
        {
            get
            {
                var request = new SaveRequestModel();
                request.Email = email.Text.Trim().ToString();
                request.Password = pass.Text.ToString();
                request.Fullname = fullName.Text.Trim() + " " + fullName2.Text.Trim();
                request.Address = address.Text.Trim();
                request.Phone1 = phone1.Text.Trim();
                request.Phone2 = phone2.Text.Trim();
                request.CityCd = DropDownList1.SelectedValue;
                return request;
            }
        }
    }
}