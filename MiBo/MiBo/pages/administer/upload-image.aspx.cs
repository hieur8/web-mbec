using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Common.Utils;
using MiBo.Domain.Logic.Admin.UploadImage;
using MiBo.Domain.Web.Admin.UploadImage;
using System.IO;

namespace MiBo.pages.administer
{
    public partial class upload_image : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) return;
            hidFileId.Value = response.FileId;
            hidFileGroup.Value = response.FileGroup;
            rptFiles.DataSource = response.ListFiles;
            rptFiles.DataBind();
        }

        protected void lnkUpload_Click(object sender, EventArgs e)
        {
            var logic = new UploadOperateLogic();
            var response = Invoke(logic, UploadRequestModel);
            if (HasError) return;
            Refresh();
        }

        protected void lnkUpdateAll_Click(object sender, EventArgs e)
        {
            var logic = new UpdateOperateLogic();
            var response = Invoke(logic, UpdateAllRequestModel);
            if (HasError) return;
            Refresh();
        }

        protected void lnkDelete_Command(object sender, CommandEventArgs e)
        {
            var args = Convert.ToString(e.CommandArgument).Split(';');
            Session["FileId"] = args[0];
            Session["FileNo"] = args[1];
            var logic = new DeleteOperateLogic();
            var response = Invoke(logic, DeleteRequestModel);
            if (HasError) return;
            Refresh();
        }

        protected void lnkDeleteAll_Click(object sender, EventArgs e)
        {
            var logic = new DeleteOperateLogic();
            var response = Invoke(logic, DeleteAllRequestModel);
            if (HasError) return;
            Refresh();
        }

        private InitRequestModel InitRequestModel
        {
            get
            {
                var requestModel = new InitRequestModel();
                requestModel.FileId = Request["fid"];
                requestModel.FileGroup = Request["fg"];
                return requestModel;
            }
        }

        private UploadRequestModel UploadRequestModel
        {
            get
            {
                var requestModel = new UploadRequestModel();
                requestModel.FileId = hidFileId.Value;
                requestModel.FileGroup = hidFileGroup.Value;
                requestModel.SortKey = txtSortKey.Text;
                requestModel.InputStream = fulPath.HasFile ? fulPath.PostedFile.InputStream : Stream.Null;
                return requestModel;
            }
        }

        private UpdateRequestModel UpdateAllRequestModel
        {
            get
            {
                OutputImageModel param = null;
                var requestModel = new UpdateRequestModel();
                var listFiles = new List<OutputImageModel>();
                foreach (RepeaterItem row in rptFiles.Items)
                {
                    param = new OutputImageModel();
                    param.FileId = ((HiddenField)row.FindControl("hidFileId")).Value;
                    param.FileNo = ((HiddenField)row.FindControl("hidFileNo")).Value;
                    param.SortKey = ((TextBox)row.FindControl("txtSortKey")).Text;
                    listFiles.Add(param);
                }
                requestModel.ListFiles = listFiles;
                return requestModel;
            }
        }

        private DeleteRequestModel DeleteRequestModel
        {
            get
            {
                var requestModel = new DeleteRequestModel();
                var listFiles = new List<OutputImageModel>();
                var param = new OutputImageModel();
                param.FileId = Convert.ToString(Session["FileId"]);
                param.FileNo = Convert.ToString(Session["FileNo"]);
                listFiles.Add(param);
                requestModel.ListFiles = listFiles;
                Session["FileId"] = null;
                Session["FileNo"] = null;
                return requestModel;
            }
        }

        private DeleteRequestModel DeleteAllRequestModel
        {
            get
            {
                OutputImageModel param = null;
                var requestModel = new DeleteRequestModel();
                var listFiles = new List<OutputImageModel>();
                foreach (RepeaterItem row in rptFiles.Items)
                {
                    param = new OutputImageModel();
                    param.FileId = ((HiddenField)row.FindControl("hidFileId")).Value;
                    param.FileNo = ((HiddenField)row.FindControl("hidFileNo")).Value;
                    listFiles.Add(param);
                }
                requestModel.ListFiles = listFiles;
                return requestModel;
            }
        }
    }
}