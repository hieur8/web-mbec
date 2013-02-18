﻿<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="shopping-cart.aspx.cs" Inherits="MiBo.pages.cln.shopping_cart" %>

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
    <style type="text/css">
        ul#grdCartItem
        {
            width: 720px;
            border: 1px solid #CCC;
        }
        ul#grdCartItem li
        {
            width: 112px;
            height: 20px;
            border: 1px solid #CCC;
        }
    </style>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content">
        <asp:Repeater ID="rptCartItem" runat="server">
            <HeaderTemplate>
                <ul id="grdCartItem" class="grid">
                    <li class="hcol">Mã</li>
                    <li class="hcol">Tên</li>
                    <li class="hcol">SL</li>
                    <li class="hcol">Giá</li>
                    <li class="hcol">Tiền</li>
                    <li class="hcol">&nbsp;</li>
            </HeaderTemplate>
            <ItemTemplate>
                <li class="vcol aleft">
                    <asp:HiddenField ID="hidItemCd" runat="server" Value='<%# Eval("ItemCd") %>' />
                    <%# Eval("ItemCd") %></li>
                <li class="vcol aleft">
                    <%# Eval("ItemName") %></li>
                <li class="vcol aright">
                    <asp:TextBox Text='<%# Eval("Quantity") %>' MaxLength="6" Width="80px" CssClass="qty spin"
                        ID="txtItemQtty" runat="server"></asp:TextBox></li>
                <li class="vcol aright">
                    <%# Eval("Price") %></li>
                <li class="vcol aright">
                    <%# Eval("Amount") %></li>
                <li class="vcol acenter">
                    <asp:LinkButton OnCommand="lnkDelete_Command" CommandArgument='<%# Eval("ItemCd") %>'
                        ID="lnkDelete" runat="server">Xóa</asp:LinkButton></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <br class="clearBoth" />
        <div id="cartSubTotal">
            <asp:Literal ID="litSubTotal" runat="server" meta:resourcekey="litSubTotal">Tổng cộng</asp:Literal>
            <asp:Label CssClass="price" ID="lblSubTotal" runat="server" Text="0"></asp:Label></div>
        <br class="clearBoth" />
        <!--bof shopping cart buttons-->
        <div class="clear">
        </div>
        <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" runat="server" Text="Cập nhật"/>
    </div>
</asp:Content>
