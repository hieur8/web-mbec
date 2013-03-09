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
                height: 300,
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
                            <div style="text-align:center" class="top-text-cs">
                                <b>Hỗ trợ trực tuyến</b></div>
                            <div style="text-align:center" class="phno">
                                <img src="/pages/resources/images/phone_icon.png" />
                                0976.129.209
                                <br />
                                <a href="ymsgr:sendim?hieur8" border="0"><img width="60px" height="60px" src="http://opi.yahoo.com/online?u=hieur8&t=7"></a>
                                <a href="skype:yourSkypeName?097612190">
    <img width="60px" height="60px" src="/pages/resources/images/skype-user.png"
         alt="Skype Me™!" style="border: none;" />
</a>
                            </div>
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
                                    <span class="botmtt">tin tức sản phẩm</span></span>
                        </div>
                        <!-- ket thuc hinh ben phai -->
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
                                            <img border="0" src='/pages/media/images/items/<%# Eval("ItemCd") %>/small/<%# Eval("ItemImage") %>'
                                                alt='<%# Eval("ItemName") %>'>
                                        </a>&nbsp;<div class="align-prodname-price-review">
                                            <h3 class="product-name">
                                                <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>" title='<%# Eval("ItemName") %>'>
                                                    <%# Eval("ItemName") %></a>
                                            </h3>
                                            <div class="price-box">
                                                <p style="margin: 0">
                                                    Thương hiệu : Apple</p>
                                                <span class="regular-price" id="product-price-181-new"><span style="text-align: right"
                                                    class="price">
                                                    <%# Eval("Price") %>
                                                </span>
                                                    <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<span  style='text-align:right' class='pricesub'>" + Eval("PriceOld") + "</span>" : ""%>
                                                </span>
                                            </div>
                                        </div>
                                            <div class="actions">
                                                <asp:LinkButton CssClass="button btn-cart" OnCommand="lnkBuy_Command" CommandArgument='<%# Eval("ItemCd") %>'
                                                    ID="lnkBuy" runat="server">Mua hàng</asp:LinkButton>
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
                                            <img src='/pages/media/images/items/<%# Eval("ItemCd") %>/small/<%# Eval("ItemImage") %>'
                                                alt='<%# Eval("ItemName") %>'>
                                        </a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div class="align-prodname-price-review">
                                            <h3 class="product-name">
                                                <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>" title='<%# Eval("ItemName") %>'>
                                                    <%# Eval("ItemName") %></a>
                                            </h3>
                                            <div class="price-box">
                                                <span class="regular-price" id="product-price-181-new">
                                                    <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<span class='pricesub'>" + Eval("PriceOld") + "</span>" : ""%>
                                                    <br />
                                                    <span class="price">
                                                        <%# Eval("Price") %>
                                                    </span></span>
                                            </div>
                                        </div>
                                            <div class="actions">
                                                <asp:LinkButton CssClass="button btn-cart" OnCommand="lnkBuy_Command" CommandArgument='<%# Eval("ItemCd") %>'
                                                    ID="lnkBuy" runat="server">Mua hàng</asp:LinkButton>
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
                                            <img src='/pages/media/images/items/<%# Eval("ItemCd") %>/small/<%# Eval("ItemImage") %>'
                                                alt='<%# Eval("ItemName") %>'>
                                        </a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<div class="align-prodname-price-review">
                                            <h3 class="product-name">
                                                <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>" title='<%# Eval("ItemName") %>'>
                                                    <%# Eval("ItemName") %></a>
                                            </h3>
                                            <div class="price-box">
                                                <span class="regular-price" id="product-price-181-new">
                                                    <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<span class='pricesub'>" + Eval("PriceOld") + "</span>" : ""%>
                                                    <br />
                                                    <span class="price">
                                                        <%# Eval("Price") %>
                                                    </span></span>
                                            </div>
                                        </div>
                                            <div class="actions">
                                                <asp:LinkButton CssClass="button btn-cart" OnCommand="lnkBuy_Command" CommandArgument='<%# Eval("ItemCd") %>'
                                                    ID="lnkBuy" runat="server">Mua hàng</asp:LinkButton>
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
