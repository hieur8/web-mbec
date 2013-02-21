<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/customer.Master" AutoEventWireup="true" CodeBehind="overview.aspx.cs" Inherits="MiBo.pages.cln.overview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
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
    </form>
</asp:Content>
