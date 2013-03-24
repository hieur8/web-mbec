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
                transition: 'bar'
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
                        <div style="float: left; padding-right: 10px">
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
                            
                        </div>
                        
                        <!-- ket thuc silde -->
                        <div class="tab-display">
                            <ul class="tabs">
                                <li class="active" style=""><a href="#tab1">Sản phẩm mới</a></li>
                                <li class=""><a href="#tab2">Sản phẩm khuyến mãi</a></li>
                                <li class=""><a href="#tab3">Sản phẩm xem nhiều</a></li>
                            </ul>
                            <div class="tab_container">
                                <div id="tab1" class="tab_content" style="display: block;">
                                    <asp:Repeater ID="rptNewItem" runat="server">
                                        <HeaderTemplate>
                                            <ul class="products-grid">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li class="item first"><a href='/item-details.aspx?pid=<%# Eval("ItemCd") %>' title="<%# Eval("ItemName") %>"
                                                class="product-image">
                                                <img width="170" height="170" border="0" src='/pages/media/images/items/<%# Eval("ItemCd") %>/small/<%# Eval("ItemImage") %>'
                                                    alt='<%# Eval("ItemName") %>'>
                                            </a>&nbsp;<div class="align-prodname-price-review">
                                                <h3 class="product-name">
                                                    <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>" title='<%# Eval("ItemName") %>'>
                                                        <%# Eval("ItemName") %></a>
                                                </h3>
                                                <div class="price-box">
                                                    <p style="margin: 0">
                                                        Thương hiệu : <%# Eval("BrandName") %></p>
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
                                <div id="tab2" class="tab_content" style="display: none;">
                                    <asp:Repeater ID="rptOfferItem" runat="server">
                                        <HeaderTemplate>
                                            <ul class="products-grid">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li class="item first"><a href='/item-details.aspx?pid=<%# Eval("ItemCd") %>' title="<%# Eval("ItemName") %>"
                                                class="product-image">
                                                <img width="170" height="170" border="0" src='/pages/media/images/items/<%# Eval("ItemCd") %>/small/<%# Eval("ItemImage") %>'
                                                    alt='<%# Eval("ItemName") %>'>
                                            </a>&nbsp;<div class="align-prodname-price-review">
                                                <h3 class="product-name">
                                                    <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>" title='<%# Eval("ItemName") %>'>
                                                        <%# Eval("ItemName") %></a>
                                                </h3>
                                                <div class="price-box">
                                                    <p style="margin: 0">
                                                        Thương hiệu : <%# Eval("BrandName") %></p>
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
                                <div id="tab3" class="tab_content" style="display: none;">
                                    <asp:Repeater ID="rptHotItem" runat="server">
                                        <HeaderTemplate>
                                            <ul class="products-grid">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li class="item first"><a href='/item-details.aspx?pid=<%# Eval("ItemCd") %>' title="<%# Eval("ItemName") %>"
                                                class="product-image">
                                                <img width="170" height="170" border="0" src='/pages/media/images/items/<%# Eval("ItemCd") %>/small/<%# Eval("ItemImage") %>'
                                                    alt='<%# Eval("ItemName") %>'>
                                            </a>&nbsp;<div class="align-prodname-price-review">
                                                <h3 class="product-name">
                                                    <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>" title='<%# Eval("ItemName") %>'>
                                                        <%# Eval("ItemName") %></a>
                                                </h3>
                                                <div class="price-box">
                                                    <p style="margin: 0">
                                                        Thương hiệu : <%# Eval("BrandName") %></p>
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
                        <!-- ket thuc show sp -->
                    </div>
                </div>
            </div>
        </div>
        <script>
            $('div').remove('.jquery-slider-timer-bar');
        </script>
</asp:Content>
