<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="item-details.aspx.cs" Inherits="MiBo.pages.cln.item_details" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div><%= Val.ItemCd %></div>
    <br />
    <div><%= Val.ItemName %></div>
    <br />
    <div><%= Val.ItemImage %></div>
    <br />
    <div>
    <% foreach (var obj in Val.ListImages) { %>
    <%= obj + ":" %>
    <% } %>
    </div>
    <br />
    <div><%= Val.ItemDiv %></div>
    <br />
    <div><%= Val.OfferDiv %></div>
    <br />
    <div><%= Val.Price %></div>
    <br />
    <div><%= Val.PriceOld %></div>
    <br />
    <div><%= Val.Notes %></div>
</asp:Content>
