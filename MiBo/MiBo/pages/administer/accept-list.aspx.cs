using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using MiBo.Domain.Common.Constants;
using MiBo.Domain.Common.Controller;
using MiBo.Domain.Logic.Admin.AcceptList;
using MiBo.Domain.Web.Admin.AcceptList;
using System.Net;
using System.Text;
using System.IO;
using MiBo.Domain.Dao;
using MiBo.Domain.Common.Dao;

namespace MiBo.pages.administer
{
    public partial class accept_list : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var logic = new InitOperateLogic();
            var response = Invoke(logic, InitRequestModel);
            if (HasError) { Redirect(Pages.ADMIN_INDEX); return; }
            rptAccepts.DataSource = response.ListAccepts;
            rptAccepts.DataBind();
            txtAcceptDataStart.Text = response.AcceptDateStart;
            txtAcceptDataEnd.Text = response.AcceptDateEnd;
            ddlSlipStatus.DataSource = response.ListSlipStatus;
            ddlSlipStatus.DataBind();
            ddlSlipStatus.SelectedValue = response.SlipStatus;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var logic = new FilterOperateLogic();
            var response = Invoke(logic, FilterRequestModel);
            if (HasError) return;
            rptAccepts.DataSource = response.ListAccepts;
            rptAccepts.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var logic = new UpdateOperateLogic();
            var response = Invoke(logic, UpdateRequestModel);
            if (HasError) return;
            Refresh();
        }

        protected void btnAction_Command(object sender, CommandEventArgs e)
        {
            Session["AcceptSlipNo"] = e.CommandArgument;
            Redirect(Pages.ADMIN_ACCEPT_ENTRY);
        }

        protected void btnCheckOut_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument == null) return;
            ClientCheckoutDao clientCheckoutDao = new ClientCheckoutDao();
            Accept accept = clientCheckoutDao.getAcceptById(e.CommandArgument.ToString().Trim());
            if (accept == null) return;
            string postData = "";
            string seperator = "";
            string resQS = "";
            int paras = 7;
            string vpcURL = "http://mtf.onepay.vn/onecomm-pay/Vpcdps.op";


            string[,] MyArray =
			{
			{"vpc_AccessCode","GWJBCBJX"},
			{"vpc_Command","queryDR"	},           
			{"vpc_MerchTxnRef",accept.GenId},			
            {"vpc_Merchant","NGUYENPHONG"},						
            {"vpc_Password","op123456"},
			{"vpc_User","op01"},
			{"vpc_Version","1"}							
			};
            for (int i = 0; i < paras; i++)
            {
                postData = postData + seperator + Server.UrlEncode(MyArray[i, 0]) + "=" + Server.UrlEncode(MyArray[i, 1]);
                seperator = "&";
            }

            resQS = doPost(vpcURL, postData);
            Session["isCheckPay"] = true;
            Session["AcceptSlipNo"] = accept.AcceptSlipNo;
            Response.Redirect("checkpay.aspx?" + Server.UrlDecode(resQS));
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

        private UpdateRequestModel UpdateRequestModel
        {
            get
            {
                OutputAcceptModel accept = null;
                var requestModel = new UpdateRequestModel();
                var listAccepts = new List<OutputAcceptModel>();

                foreach (RepeaterItem row in rptAccepts.Items)
                {
                    if (!((CheckBox)row.FindControl("chkEdit")).Checked) continue;
                    accept = new OutputAcceptModel();
                    accept.AcceptSlipNo = ((HiddenField)row.FindControl("hidAcceptSlipNo")).Value;
                    accept.SlipStatus = ((DropDownList)row.FindControl("ddlSlipStatus")).SelectedValue;
                    listAccepts.Add(accept);
                }

                requestModel.ListAccepts = listAccepts;
                return requestModel;
            }
        }
        public static string doPost(string vpc_Host, string postData)
        {
            string page = "Response:";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(vpc_Host);

            //  WebRequest request = WebRequest.Create(vpc_Host);
            request.Method = "POST";

            // Create POST data and convert it to a byte array.
            //string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.         
            request.UserAgent = "HTTP Client";
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            //    WebResponse response = request.GetResponse();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            //   Response.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            page = page + responseFromServer;
            // Display the content.
            //  Response.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
            return page;
        }
    }
}