<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="item-details.aspx.cs" Inherits="MiBo.pages.cln.item_details" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <!-- Spin -->
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
    <!-- Galleries -->
    <link rel="stylesheet" type="text/css" href="/pages/resources/styles/jquery.ad-gallery.css">
    <script type="text/javascript" src="/pages/resources/scripts/jquery.ad-gallery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            var galleries = $('.ad-gallery').adGallery();
        });
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="main-container col2-right-layout">
        <div class="main">
            <div class="col-main">
                <asp:FormView ID="fvwItemDetails" runat="server" RenderOuterTable="false">
                    <ItemTemplate>
                        <div class="breadcrumbs">
                            <ul>
                                <li class="home"><a href="/index.aspx" title="Trở về trang chủ">Trang chủ</a> <span>/ </span> </li>
                                <li class="category37"><a href='/items.aspx?category=<%# Eval("CategoryCd")%>'><%# Eval("CategoryName")%></a> <span>/ </span></li>
                                <li class="product"><strong><%# Eval("ItemName")%></strong> </li>
                            </ul>
                        </div>
                        <ul class="messages">
                            <% if (Session["info"] != null)
                                { %>
                            <li class="success-msg">
                                <ul>
                                    <li>
                                        <%= Session["info"]%></li></ul>
                            </li>
                            <% } %>
                            <% if (Session["error"] != null)
                                { %>
                            <li class="error-msg">
                                <ul>
                                    <li>
                                        <%= Session["error"] %></li></ul>
                            </li>
                            <% } %>
                            <% if (Session["warn"] != null)
                                { %>
                            <li class="notice-msg">
                                <ul>
                                    <li>
                                        <%= Session["warn"]%></li></ul>
                            </li>
                            <% } %>
                        </ul>
                        <div id="messages_product_view">
                        </div>
                        <div class="product-view">
                            <div class="product-essential">
                                <div class="no-display">
                                    <asp:HiddenField ID="hidItemCd" Value='<%# Eval("ItemCd")%>' runat="server" />
                                </div>
                                <div class="product-shop">
                                    <div class="product-name">
                                        <h1><%# Eval("ItemName")%></h1>
                                    </div>
                                    <div class="price-box">
                                        <span class="regular-price" id="product-price-173">
                                            <span class="price"><%# Eval("Price")%></span>
                                        </span>
                                        <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<span class='pricesub'>" + Eval("PriceOld") + "</span>" : ""%>
                                    </div>
                                    <p class="availability in-stock">
                                        Tình trạng: <span>Còn hàng</span></p>
                                    <p class="availability in-stock">
                                        Thương hiệu: <span><%# Eval("BrandName")%></span></p>
                                    <p class="availability in-stock">
                                        Xuất xứ: <span><%# Eval("CountryName")%></span></p>
                                    <div class="add-to-box">
                                        <div class="add-to-cart" style="display: block">
                                            <asp:TextBox Text="1" MaxLength="6" Width="80px" CssClass="qty spin" ID="txtItemQtty" runat="server"></asp:TextBox>
                                            <span class="buttonRow">
                                                <asp:LinkButton CssClass="button btn-cart" OnCommand="lnkBuy_Command" CommandArgument='<%# Eval("ItemCd") %>' ID="lnkBuy" runat="server">Cho vào giỏ hàng</asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="short-description">
                                        <h2>Mô tả sản phẩm</h2>
                                        <div class="std">
                                            <%# Eval("Notes")%>
                                        </div>
                                    </div>
                                </div>
                                <div style="padding-left: 15px" class="product-img-box">
                                    <div id="gallery" class="ad-gallery">
                                        <div class="ad-image-wrapper">
                                        </div>
                                        <div class="ad-controls">
                                        </div>
                                        <div class="ad-nav">
                                            <div class="ad-thumbs">
                                                <asp:Repeater ID="rptItemImage" runat="server" DataSource='<%# Eval("ListImages")%>'>
                                                    <HeaderTemplate>
                                                        <ul class="ad-thumb-list">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <li>
                                                            <a href='/pages/media/images/items/<%# Eval("ItemCd")%>/larger/<%# Eval("ItemImage")%>'>
                                                                <img src='/pages/media/images/items/<%# Eval("ItemCd")%>/small/<%# Eval("ItemImage")%>' class="image0" alt=""/>
                                                            </a>
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
                                <div class="clearer">
                                </div>
                                <div class="crosssell">
                                    <h2>
                                        Danh sách sản phẩm khuyến mãi</h2>
                                    <asp:Repeater ID="rptOfferItems" runat="server" DataSource='<%# Eval("ListOfferItems")%>'>
                                        <HeaderTemplate>
                                            <ul id="crosssell-products-list">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li class="item odd">
                                                <a class="product-image" href='/item-details.aspx?pid=<%# Eval("ItemCd") %>' title='<%# Eval("ItemName")%>'>
                                                    <img src='/pages/media/images/items/<%# Eval("ItemCd") %>/small/<%# Eval("ItemImage") %>' alt='<%# Eval("ItemName")%>'>
                                                </a>
                                                <div class="product-details">
                                                    <h3 class="product-name">
                                                        <a href='/item-details.aspx?pid=<%# Eval("ItemCd") %>'>
                                                            <%# Eval("ItemName")%>(<%# Eval("Quantity")%>)
                                                        </a>
                                                    </h3>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ul>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="box-collateral box-up-sell">
                                <h2>Like và bình luận với Facebook</h2>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:FormView>
            </div>
            <div class="col-right sidebar">
                <div class="block block-cart">
                    <div class="block-title">
                        <strong><span>Giỏ hàng</span></strong>
                    </div>
                    <div class="block-content">
                        <p class="empty">Bạn chưa mua sản phẩm nào.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
