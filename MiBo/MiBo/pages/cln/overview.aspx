<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="overview.aspx.cs" Inherits="MiBo.pages.cln.overview" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
<div class="main-container">
<div class="main">
    <%
        if (Session["msgInfo"] == null)
        {  
    %>
    <center>
     <h1>Đặt hàng thành công</h1>
     <p>Đơn hàng của bạn đã được gởi đến bộ phận bán hàng của Mibo. Bạn cũng có thể theo dõi đơn hàng của bạn <a href="order-history.aspx">tại đây</a></p>
         <p>
             <asp:LinkButton ID="Button1" Width="140" class="btn btn-blue" runat="server" onclick="Button1_Click">
             <span>Quay lại trang chủ</span></asp:LinkButton>
         </p>
     <%
    }
    else
    {
          %>

          <h1><%=Session["msgInfo"].ToString()%></h1>
          <% } %>
     </center>
     </div></div>
</asp:Content>
