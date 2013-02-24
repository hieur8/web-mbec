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
<div class="main-container col1-layout">
        <div class="main">
            <div class="col-main">
                <div class="std">
                    <div class="maiin-content">
                        <div class="header-banner">
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
                        </div>
                        <!-- ket thuc silde -->
                        <div class="tab-display">
                            <ul class="tabs">
                                <li class="active" style=""><a href="#tab1">SP mới</a></li>
                                <li class=""><a href="#tab2">SP khuyến mãi</a></li>
                                <li class=""><a href="#tab3">SP xem nhiều</a></li>
                            </ul>
                            <div class="tab_container">
                                <div id="tab1" class="tab_content" style="display: block;">
                                    <asp:Repeater ID="rptNewItem" runat="server">
                                        <HeaderTemplate>
                                            <ul class="products-grid">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li class="item first">
                                                <a href='/pages/cln/item-details.aspx?pid=<%# Eval("ItemCd") %>' title="<%# Eval("ItemName") %>" class="product-image">
                                                    <img src='/pages/media/images/items/<%# Eval("ItemCd") %>/small/<%# Eval("ItemImage") %>' alt='<%# Eval("ItemName") %>'>
                                                </a>
                                                <div class="align-prodname-price-review">
                                                    <h3 class="product-name">
                                                        <a href="/pages/cln/item-details.aspx?pid=<%# Eval("ItemCd") %>" title='<%# Eval("ItemName") %>'><%# Eval("ItemName") %></a>
                                                    </h3>
                                                    <div class="price-box">
                                                        <span class="regular-price" id="product-price-181-new">
                                                            <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<span class='pricesub'>" + Eval("PriceOld") + "</span>" : ""%>
                                                            <br />
                                                            <span class="price">
                                                                <%# Eval("Price") %>
                                                            </span>
                                                         </span>
                                                    </div>
                                                </div>
                                                <div class="actions">
                                                    <asp:LinkButton CssClass="button btn-cart" OnCommand="lnkBuy_Command" CommandArgument='<%# Eval("ItemCd") %>' ID="lnkBuy" runat="server">Mua hàng</asp:LinkButton>
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
                                            <li class="item first">
                                                <a href='/pages/cln/item-details.aspx?pid=<%# Eval("ItemCd") %>' title="<%# Eval("ItemName") %>" class="product-image">
                                                    <img src='/pages/media/images/items/<%# Eval("ItemCd") %>/small/<%# Eval("ItemImage") %>' alt='<%# Eval("ItemName") %>'>
                                                </a>
                                                <div class="align-prodname-price-review">
                                                    <h3 class="product-name">
                                                        <a href="/pages/cln/item-details.aspx?pid=<%# Eval("ItemCd") %>" title='<%# Eval("ItemName") %>'><%# Eval("ItemName") %></a>
                                                    </h3>
                                                    <div class="price-box">
                                                        <span class="regular-price" id="product-price-181-new">
                                                            <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<span class='pricesub'>" + Eval("PriceOld") + "</span>" : ""%>
                                                            <br />
                                                            <span class="price">
                                                                <%# Eval("Price") %>
                                                            </span>
                                                         </span>
                                                    </div>
                                                </div>
                                                <div class="actions">
                                                    <asp:LinkButton CssClass="button btn-cart" OnCommand="lnkBuy_Command" CommandArgument='<%# Eval("ItemCd") %>' ID="lnkBuy" runat="server">Mua hàng</asp:LinkButton>
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
                                            <li class="item first">
                                                <a href='/pages/cln/item-details.aspx?pid=<%# Eval("ItemCd") %>' title="<%# Eval("ItemName") %>" class="product-image">
                                                    <img src='/pages/media/images/items/<%# Eval("ItemCd") %>/small/<%# Eval("ItemImage") %>' alt='<%# Eval("ItemName") %>'>
                                                </a>
                                                <div class="align-prodname-price-review">
                                                    <h3 class="product-name">
                                                        <a href="/pages/cln/item-details.aspx?pid=<%# Eval("ItemCd") %>" title='<%# Eval("ItemName") %>'><%# Eval("ItemName") %></a>
                                                    </h3>
                                                    <div class="price-box">
                                                        <span class="regular-price" id="product-price-181-new">
                                                            <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<span class='pricesub'>" + Eval("PriceOld") + "</span>" : ""%>
                                                            <br />
                                                            <span class="price">
                                                                <%# Eval("Price") %>
                                                            </span>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="actions">
                                                    <asp:LinkButton CssClass="button btn-cart" OnCommand="lnkBuy_Command" CommandArgument='<%# Eval("ItemCd") %>' ID="lnkBuy" runat="server">Mua hàng</asp:LinkButton>
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
                    <div class="col-right-sidebar">
                        <div class="perfume1">
                            <div class="top-text-cs">
                                Hỗ trợ trực tuyến</div>
                            <div class="align-img">
                                <img src="/pages/resources/images/green-dream_17.gif"
                                    alt=""></div>
                            <div class="phno">
                                0976.12.10.90</div>
                            <p style="text-align: center;">
                                <a href="skype:darkemperordt?call">
                                    <img alt="My status" height="44" src="http://mystatus.skype.com/bigclassic/darkemperordt" style="border: none;" width="182" />
                                </a>
                            </p>
                            <br />
                            <p style="text-align: center;">
                                <img src='http://opi.yahoo.com/online?u=hieur8&m=g&t=14'/>
                            </p>
                        </div>
                        <div class="perfume">
                            <div class="block block-subscribe">
                                <div class="block-title">
                                    <strong><span class="first-line">Nhận tin</span><br>
                                        <span class="second-line">MIBO</span><br>
                                    </strong>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="block-content">
                                    <div class="input-box">
                                        <input type="text" name="email" id="newsletter" title="Nhận tin tức của chúng tôi"
                                            value="Nhập địa chỉ email" class="input-text required-entry validate-email" onfocus="if (this.value == 'Nhập địa chỉ email') {this.value = '';}"
                                            onblur="if (this.value == '') {this.value = 'Nhập địa chỉ email';}">
                                    </div>
                                    <div class="actions">
                                        <button type="submit" title="Subscribe" class="button">
                                            <span><span>Go</span></span></button>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="botm-text">
                                <span class="first-line-botm">Đăng ký nhận<br>
                                <span class="botmtt">tin tức sản phẩm</span></span><br>
                                <span class="second-line-botom">Mỗi tuần</span>
                            </div>
                        </div>
                        <div class="connect-us">
                            <p>
                                <a class="social" href="http://www.twitter.com">
                                    <img src="/pages/resources/images/green-dream_19.gif" alt="">
                                </a>
                                <a class="social" href="http://www.facebook.com">
                                    <img src="/pages/resources/images/green-dream_23.gif" alt="">
                                </a>
                            </p>
                        </div>
                    </div>
                    <!-- ket thuc hinh ben phai -->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
