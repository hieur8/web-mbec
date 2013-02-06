<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="item-details.aspx.cs" Inherits="MiBo.pages.cln.item_details" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <script src="/pages/resources/scripts/jquery-spin.js" type="text/javascript"></script>
    <script type="text/javascript">
        $.spin.imageBasePath = '/pages/resources/images/';
        $(document).ready(function () {
            $('.spin').spin({
                min: 1,
                max: 9999
            });
        });
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <asp:HiddenField ID="hidItemCd" runat="server" />
    <asp:HiddenField ID="hidItemDiv" runat="server"/>
    <asp:HiddenField ID="hidOfferDiv" runat="server"/>
    <asp:Literal ID="litItemName" runat="server"></asp:Literal>
    <asp:Image ID="imgItemImage" runat="server" />
    <asp:Repeater ID="rptItemImage" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <img src='<%# string.Format("/pages/media/images/items/{0}/small/{1}", hidItemCd.Value, Container.DataItem)%>' alt='<%# Container.DataItem %>' />
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul></FooterTemplate>
    </asp:Repeater>
    <div class="item-price"><asp:Literal ID="litPrice" runat="server"></asp:Literal></div>
    <% if (Equals("", hidItemDiv.Value) && Equals("01", hidOfferDiv.Value)) { %>
    <div class="offer-price"><asp:Literal ID="litPriceOld" runat="server"></asp:Literal></div>
    <% } %>
    <asp:Literal ID="litNotes" runat="server"></asp:Literal>
    <div id="cartAdd">
        <asp:TextBox Text="1" MaxLength="6" Width="80px" CssClass="qty spin" ID="txtItemQtty"
            runat="server"></asp:TextBox>
        <span class="buttonRow">
            <asp:LinkButton OnCommand="lnkBuy_Command" ID="lnkBuy" runat="server">Mua</asp:LinkButton>
        </span>
    </div>
    <asp:Repeater ID="rptOfferItems" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <img src='<%# string.Format("/pages/media/images/items/{0}/small/{1}", Eval("ItemCd"), Eval("ItemImage"))%>' alt='<%# Eval("ItemName") %>' />
                <%# Eval("ItemName") %>
                <%# Eval("Quantity")%>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul></FooterTemplate>
    </asp:Repeater>
</asp:Content>
