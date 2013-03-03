<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true" CodeBehind="overview.aspx.cs" Inherits="MiBo.pages.cln.overview" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
<%
    if (Session["msgInfo"] != null)
    {
        
     %>
     <center>
     <h1>Đặt hàng thành công</h1>
         <p>
             <asp:Button ID="Button1" runat="server" Text="Quay lại trang chủ" 
                 onclick="Button1_Click" />
         </p>
     <%
    }
    else
    {
          %>

          <h1><%=Session["msgInfo"].ToString()%></h1>
          <% } %>
     </center>
</asp:Content>
