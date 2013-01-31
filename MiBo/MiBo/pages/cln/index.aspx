<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="MiBo.pages.cln.index" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <!-- flexslider -->
    <link href="/pages/resources/styles/flexslider.css" rel="stylesheet" type="text/css" />
    <script src="/pages/resources/scripts/jquery.flexslider-min.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            $('.flexslider').flexslider({
                animation: "slide"
            });
        });  
    </script>
    <!-- jtslider -->
    <link href="/pages/resources/styles/jtslider.css" rel="stylesheet" type="text/css" />
    <script src="/pages/resources/scripts/jquery.jtslider.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            $('#slider-new-item').bxSlider({
                prevSelector: '.prev-new-item',
                nextSelector: '.next-new-item',
                mode: 'horizontal',
                speed: 500,
                controls: true,
                auto: false,
                pause: 3000,
                autoDelay: 0,
                autoHover: false,
                pager: false,
                pagerType: 'full',
                pagerLocation: 'bottom',
                pagerShortSeparator: '/',
                displaySlideQty: 5,
                moveSlideQty: 1
            });

            $('#slider-offer-item').bxSlider({
                prevSelector: '.prev-offer-item',
                nextSelector: '.next-offer-item',
                mode: 'horizontal',
                speed: 500,
                controls: true,
                auto: false,
                pause: 3000,
                autoDelay: 0,
                autoHover: false,
                pager: false,
                pagerType: 'full',
                pagerLocation: 'bottom',
                pagerShortSeparator: '/',
                displaySlideQty: 5,
                moveSlideQty: 1
            });

            $('#slider-hot-item').bxSlider({
                prevSelector: '.prev-hot-item',
                nextSelector: '.next-hot-item',
                mode: 'horizontal',
                speed: 500,
                controls: true,
                auto: false,
                pause: 3000,
                autoDelay: 0,
                autoHover: false,
                pager: false,
                pagerType: 'full',
                pagerLocation: 'bottom',
                pagerShortSeparator: '/',
                displaySlideQty: 5,
                moveSlideQty: 1
            });
        });
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <section class="slider">
        <div class="flexslider">
            <asp:Repeater ID="rptBanner" runat="server">
                <HeaderTemplate>
                    <ul class="slides">
                </HeaderTemplate>
                <ItemTemplate>
                    <li><a href='#<%# Eval("BannerCd") %>'>
                        <img alt="<%# Eval("BannerName") %>" title="<%# Eval("BannerName") %>" src='/pages/media/images/banners/<%# Eval("Image") %>' /></a>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </section>
    <section class="jt-slider">
        <div class="prev-new-item jt-prev">
        </div>
        <div class="bx-wrapper">
            <div class="bx-window">
                <asp:Repeater ID="rptNewItem" runat="server">
                    <HeaderTemplate>
                        <ul id="slider-new-item">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <div class="block-item">
                                <div class="item-name">
                                    <h3><a href='/pages/cln/item-details.aspx?pid=<%# Eval("ItemCd") %>&pnm=<%# Eval("ItemName") %>'><%# Eval("ItemName") %></a></h3>
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
                                <div class="item-price"><%# Eval("Price") %></div>
                            </div>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="next-new-item jt-next">
        </div>
    </section>
    <section class="jt-slider">
        <div class="prev-offer-item jt-prev">
        </div>
        <div class="bx-wrapper">
            <div class="bx-window">
                <asp:Repeater ID="rptOfferItem" runat="server">
                    <HeaderTemplate>
                        <ul id="slider-offer-item">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <div class="block-item">
                                <div class="item-name">
                                    <h3><a href='/pages/cln/item-details.aspx?pid=<%# Eval("ItemCd") %>&pnm=<%# Eval("ItemName") %>'><%# Eval("ItemName") %></a></h3>
                                </div>
                                <div class="item-image">
                                    <div class="new-offer">
                                        <div class="new-offer">
                                        <%# Equals("02", Eval("ItemDiv")) ? "<img src='/pages/resources/images/new.png' alt='new'>" : ""%>
                                        <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<img src='/pages/resources/images/sale.png' alt='sale'>" : ""%>
                                        <%# Equals("", Eval("ItemDiv")) && Equals("02", Eval("OfferDiv")) ? "<img src='/pages/resources/images/offer.png' alt='offer'>" : ""%>
                                    </div>
                                    </div>
                                    <span><a href='/pages/cln/item-details.aspx?pid=<%# Eval("ItemCd") %>&pnm=<%# Eval("ItemName") %>'>
                                        <img alt="<%# Eval("ItemName") %>" title="<%# Eval("ItemName") %>" src='/pages/media/images/items/<%# Eval("ItemCd") %>/small/<%# Eval("ItemImage") %>'></a>
                                    </span>
                                </div>
                                <div class="item-price"><%# Eval("Price") %></div>
                            </div>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="next-offer-item jt-next">
        </div>
    </section>
    <section class="jt-slider">
        <div class="prev-hot-item jt-prev">
        </div>
        <div class="bx-wrapper">
            <div class="bx-window">
                <asp:Repeater ID="rptHotItem" runat="server">
                    <HeaderTemplate>
                        <ul id="slider-hot-item">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <div class="block-item">
                                <div class="item-name">
                                    <h3><a href='/pages/cln/item-details.aspx?pid=<%# Eval("ItemCd") %>&pnm=<%# Eval("ItemName") %>'><%# Eval("ItemName") %></a></h3>
                                </div>
                                <div class="item-image">
                                    <div class="new-offer">
                                        <div class="new-offer">
                                        <%# Equals("02", Eval("ItemDiv")) ? "<img src='/pages/resources/images/new.png' alt='new'>" : ""%>
                                        <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<img src='/pages/resources/images/sale.png' alt='sale'>" : ""%>
                                        <%# Equals("", Eval("ItemDiv")) && Equals("02", Eval("OfferDiv")) ? "<img src='/pages/resources/images/offer.png' alt='offer'>" : ""%>
                                    </div>
                                    </div>
                                    <span><a href='/pages/cln/item-details.aspx?pid=<%# Eval("ItemCd") %>&pnm=<%# Eval("ItemName") %>'>
                                        <img alt="<%# Eval("ItemName") %>" title="<%# Eval("ItemName") %>" src='/pages/media/images/items/<%# Eval("ItemCd") %>/small/<%# Eval("ItemImage") %>'></a>
                                    </span>
                                </div>
                                <div class="item-price"><%# Eval("Price") %></div>
                            </div>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="next-hot-item jt-next">
        </div>
    </section>
</asp:Content>
