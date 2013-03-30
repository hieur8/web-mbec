<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="MiBo.pages.cln.index" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <!-- flexslider -->
    <link href="/pages/resources/styles/jquery.slider.css" rel="stylesheet" type="text/css" />
    <script src="/pages/resources/scripts/jquery.slider.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            $(".slider").slideshow({
                width: 765,
                height: 383,
                control: false,
                navigation: false
            });
        }); 
    </script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            //When page loads...
            jQuery(".tab_content").hide(); //Hide all content
            jQuery("ul.tabs li:first").addClass("active").show(); //Activate first tab
            jQuery(".tab_content:first").show(); //Show first tab content

            //On Click Event
            jQuery("ul.tabs li").click(function () {
                jQuery("ul.tabs li").removeClass("active"); //Remove any "active" class
                jQuery(this).addClass("active"); //Add "active" class to selected tab
                jQuery(".tab_content").hide(); //Hide all tab content

                var activeTab = jQuery(this).find("a").attr("href"); //Find the href attribute value to identify the active tab + content
                jQuery(activeTab).fadeIn(); //Fade in the active ID content
                return false;
            });

        });
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div id="fb-root">
    </div>
    <div class="main-container">
        <div class="main">
            <div class="std">
                <div class="main-content">
                    <div class="header-banner">
                        <div style="float: left; margin-right: 10px; border: 1px solid #ddd">
                            <asp:Repeater ID="rptBanner" runat="server">
                                <HeaderTemplate>
                                    <div style="float: left;" class="slider">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div>
                                        <img alt="<%# Eval("BannerName") %>" title="<%# Eval("BannerName") %>" src='/pages/media/images/banners/<%# Eval("Image") %>' /></div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="perfume1">
                            <div class="tbl-right-box box-176 padd-bg-hotline ui-corner-tbl-top">
                                <span class="ui-hotline-2"></span>
                                <p class="padd-hotline-2">
                                    <span style="font-size: 12px">hotline (24/7)</span>
                                </p>
                                <h4 class="num-hot">
                                    <asp:Literal ID="litHotline" runat="server"></asp:Literal></h4>
                                <p>
                                </p>
                            </div>
                            <div id="right-cp" class="bg-cp">
                                <div class="padd-in-7 tbl-cp" style="padding-top: 0;">
                                    <div class="c1" style="height: 1px; background: #dbdde0">
                                    </div>
                                    <div class="wrapper" style="margin-top: 9px;">
                                        <a><span class="duty-40x40 duty-1a"></span>
                                            <p class="font-medium">
                                                Giảm
                                                <asp:Literal ID="litDiscountMember" runat="server"></asp:Literal>
                                                cho các thành viên mibo.vn</p>
                                        </a>
                                    </div>
                                    <div class="wrapper">
                                        <a><span class="duty-40x40 duty-2a"></span>
                                            <p class="font-medium">
                                                100% các sản phẩm chính hãng giá tốt</p>
                                        </a>
                                    </div>
                                    <div class="wrapper">
                                        <a><span class="duty-40x40 duty-3a"></span>
                                            <p class="font-medium">
                                                7 ngày đổi trả hàng miễn phí</p>
                                        </a>
                                    </div>
                                    <div class="wrapper">
                                        <a><span class="duty-40x40 duty-4a"></span>
                                            <p class="font-medium">
                                                Giao hàng miễn phí với các đơn hàng trị giá từ 200.000 đ</p>
                                        </a>
                                    </div>
                                    <hr />
                                    <div class="wrapper">
                                        <a id="lnkChatYahoo" runat="server" title="Click vào đây để Chat trực tiếp" style="text-decoration: none; padding: 0 6px">
                                            <img id="icoChatYahoo" runat="server" style="cursor: pointer; width: 88px" border="0"></a>
                                        <a id="lnkChatSkype" runat="server" title="Click vào đây để Chat trực tiếp" style="text-decoration: none;  padding: 0 6px">
                                            <img id="icoChatSkype" runat="server" style="cursor: pointer; width: 72px" border="0"></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- ket thuc silde -->
                        <div class="clearer">
                            <ul class="idTabs idTabsShort">
                                <li><a href="#idTab1" class="selected">Sản phẩm mới</a></li>
                                <li><a href="#idTab2">Sản phẩm khuyến mãi</a></li>
                                <li><a href="#idTab3">Sản phẩm xem nhiều</a></li>
                            </ul>
                            <div id="more_info_sheets" class="bgcolor bordercolor">
                                <div id="idTab1" style="padding: 4px;">
                                    <div>
                                        <asp:Repeater ID="rptNewItem" runat="server">
                                            <HeaderTemplate>
                                                <ul class="products-grid">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <li class="item first"><a href='/item-details.aspx?pid=<%# Eval("ItemCd") %>' title="<%# Eval("ItemName") %>"
                                                    class="product-image">
                                                    <img width="170" height="170" border="0" src='/pages/media/images/items/normal/<%# Eval("ItemImage") %>'
                                                        alt='<%# Eval("ItemName") %>'>
                                                </a>&nbsp;<div class="align-prodname-price-review">
                                                    <h3 class="product-name">
                                                        <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>" title='<%# Eval("ItemName") %>'>
                                                            <%# Eval("ItemName") %></a>
                                                    </h3>
                                                    <div class="price-box">
                                                        <p style="margin: 0">
                                                            Thương hiệu :
                                                            <%# Eval("BrandName") %></p>
                                                        <span class="regular-price" id="product-price-181-new"><span style="text-align: right"
                                                            class="price">
                                                            <%# Eval("Price") %>
                                                        </span>
                                                            <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<span  style='text-align:right' class='pricesub'>" + Eval("PriceOld") + "</span>" : ""%>
                                                        </span>
                                                    </div>
                                                </div>
                                                </li>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </ul>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                                <div id="idTab2" style="padding: 4px;">
                                    <div>
                                        <asp:Repeater ID="rptOfferItem" runat="server">
                                            <HeaderTemplate>
                                                <ul class="products-grid">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <li class="item first"><a href='/item-details.aspx?pid=<%# Eval("ItemCd") %>' title="<%# Eval("ItemName") %>"
                                                    class="product-image">
                                                    <img width="170" height="170" border="0" src='/pages/media/images/items/normal/<%# Eval("ItemImage") %>'
                                                        alt='<%# Eval("ItemName") %>'>
                                                </a>&nbsp;<div class="align-prodname-price-review">
                                                    <h3 class="product-name">
                                                        <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>" title='<%# Eval("ItemName") %>'>
                                                            <%# Eval("ItemName") %></a>
                                                    </h3>
                                                    <div class="price-box">
                                                        <p style="margin: 0">
                                                            Thương hiệu :
                                                            <%# Eval("BrandName") %></p>
                                                        <span class="regular-price" id="product-price-181-new"><span style="text-align: right"
                                                            class="price">
                                                            <%# Eval("Price") %>
                                                        </span>
                                                            <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<span  style='text-align:right' class='pricesub'>" + Eval("PriceOld") + "</span>" : ""%>
                                                        </span>
                                                    </div>
                                                </div>
                                                </li>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </ul>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                                <div id="idTab3" style="padding: 4px;">
                                    <div>
                                        <asp:Repeater ID="rptHotItem" runat="server">
                                            <HeaderTemplate>
                                                <ul class="products-grid">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <li class="item first"><a href='/item-details.aspx?pid=<%# Eval("ItemCd") %>' title="<%# Eval("ItemName") %>"
                                                    class="product-image">
                                                    <img width="170" height="170" border="0" src='/pages/media/images/items/normal/<%# Eval("ItemImage") %>'
                                                        alt='<%# Eval("ItemName") %>'>
                                                </a>&nbsp;<div class="align-prodname-price-review">
                                                    <h3 class="product-name">
                                                        <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>" title='<%# Eval("ItemName") %>'>
                                                            <%# Eval("ItemName") %></a>
                                                    </h3>
                                                    <div class="price-box">
                                                        <p style="margin: 0">
                                                            Thương hiệu :
                                                            <%# Eval("BrandName") %></p>
                                                        <span class="regular-price" id="product-price-181-new"><span style="text-align: right"
                                                            class="price">
                                                            <%# Eval("Price") %>
                                                        </span>
                                                            <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<span  style='text-align:right' class='pricesub'>" + Eval("PriceOld") + "</span>" : ""%>
                                                        </span>
                                                    </div>
                                                </div>
                                                </li>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </ul>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- ket thuc show sp -->
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            $('div').remove('.jquery-slider-timer-bar');
        </script>
</asp:Content>
