<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="items.aspx.cs" Inherits="MiBo.pages.cln.items" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div>
        <asp:Repeater ID="rptItem" runat="server">
            <HeaderTemplate>
                <ul id="slider-new-item">
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <div class="block-item">
                        <div class="item-name">
                            <h3>
                                <a href='/pages/cln/item-details.aspx?pid=<%# Eval("ItemCd") %>&pnm=<%# Eval("ItemName") %>'>
                                    <%# Eval("ItemName") %></a></h3>
                        </div>
                        <div class="item-image">
                            <div class="new-offer">
                                <%# Equals("02", Eval("ItemDiv")) ? "<img src='/pages/resources/images/new.png' alt='new'>" : ""%>
                                <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<img src='/pages/resources/images/sale.png' alt='sale'>" : ""%>
                                <%# Equals("", Eval("ItemDiv")) && Equals("02", Eval("OfferDiv")) ? "<img src='/pages/resources/images/offer.png' alt='offer'>" : ""%>
                            </div>
                            <span><a href='/pages/cln/item-details.aspx?pid=<%# Eval("ItemCd") %>&pnm=<%# Eval("ItemName") %>'>
                                <img alt="<%# Eval("ItemName") %>" title="<%# Eval("ItemName") %>" src='/pages/media/images/items/<%# Eval("ItemCd") %>/small/<%# Eval("ItemImage") %>'></a>
                            </span>
                        </div>
                        <div class="item-price">
                            <%# Eval("Price") %></div>
                        <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<div class='offer-price'>" + Eval("PriceOld") + "</div>" : ""%>
                        <span class="buttonRow">
                            <asp:LinkButton OnCommand="lnkBuy_Command" CommandArgument='<%# Eval("ItemCd") %>'
                                ID="lnkBuy" runat="server">Mua</asp:LinkButton>
                        </span>
                    </div>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
