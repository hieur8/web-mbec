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
        function showSuccessToast() {
            $().toastmessage('showSuccessToast', "Sản phẩm đã thêm vào giỏ hàng !");
        }
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
    <div id="fb-root">
    </div>
    <div class="main-container col2-right-layout">
        <div class="main">
            <div class="col-main">
                <asp:FormView ID="fvwItemDetails" runat="server" RenderOuterTable="false">
                    <ItemTemplate>
                        <div class="breadcrumbs">
                            <ul>
                                <li class="home"><a href="/index.aspx" title="Trở về trang chủ">Trang chủ</a> <span>
                                    / </span></li>
                                <li class="category37"><a href='/items.aspx?category=<%# Eval("CategoryCd")%>'>
                                    <%# Eval("CategoryName")%></a> <span>/ </span></li>
                                <li class="product"><strong>
                                    <%# Eval("ItemName")%></strong> </li>
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
                                    <table style="padding-bottom:50px" width="100%" border="0">
                                    <tr>
                                    <td>Tên</td>
                                    <td><b>
                                            <%# Eval("ItemName")%></b></td>
                                    </tr>
                                    <tr>
                                    <td>Giá</td>
                                    <td><span class="regular-price" id="product-price-173"><span class="price">
                                            <%# Eval("Price")%></span> </span>
                                        <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<span class='pricesub'>" + Eval("PriceOld") + "</span>" : ""%></td>
                                    </tr>
                                    <tr>
                                    <td>
                                    Thương hiệu
                                    </td>
                                    <td>
                                     <span>
                                            <%# Eval("BrandName")%></span>
                                    </td>
                                    </tr>
                                    <tr>
                                    <td>Xuất xứ</td>
                                    <td><span>
                                            <%# Eval("CountryName")%></span></td>
                                    </tr>
                                    <tr>
                                    <td>Độ tuổi sử dụng</td>
                                    <td><span>
                                            <%# Eval("AgeName")%></span></td>
                                    </tr>
                                    <tr>
                                    <td>Qui cách</td>
                                    <td><span>
                                            <%# Eval("Packing")%></span></td>
                                    </tr>
                                    </table>
                                    <div class="add-to-box">
                                        <div class="add-to-cart" style="display: block">
                                            <asp:TextBox Text="1" MaxLength="6" Width="25px" CssClass="spin" ID="txtItemQtty"
                                                runat="server"></asp:TextBox>
                                            <br />
                                            <div style="float: left;">
                                                <asp:LinkButton CssClass="add-more" OnCommand="lnkBuy_Command" CommandArgument='<%# Eval("ItemCd") %>'
                                                    ID="lnkBuy" runat="server">Cho vào giỏ hàng</asp:LinkButton>
                                                <asp:LinkButton CssClass="buy-now" OnCommand="lnkBuyNow_Command" CommandArgument='<%# Eval("ItemCd") %>'
                                                    ID="lnkBuyNow" runat="server">Thêm vào giỏ hàng</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div style="padding-left: 15px; z-index: 3" class="product-img-box">
                                    <div id="gallery" style="z-index: 3" class="ad-gallery">
                                        <div class="ad-image-wrapper" style="z-index: 3">
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
                                                        <li><a href='/pages/media/images/items/<%# Eval("ItemCd")%>/larger/<%# Eval("ItemImage")%>'>
                                                            <img src='/pages/media/images/items/<%# Eval("ItemCd")%>/small/<%# Eval("ItemImage")%>'
                                                                width="60px" height="60px" class="image0" alt="" />
                                                        </a></li>
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
                                <br />
                                    <h1>Mô tả sản phẩm</h1><br />
                                   <%# Eval("Notes")%>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="box-collateral box-up-sell">
                                <h2>
                                    Like và bình luận với Facebook</h2>
                                <div class="fb-like" data-href='http://mibo.vn/item-details.aspx?pid=<%# Eval("ItemCd")%>'
                                    data-send="false" data-width="450" data-show-faces="false" data-font="arial">
                                </div>
                                <div class="fb-comments" data-href='http://mibo.vn/item-details.aspx?pid=<%# Eval("ItemCd")%>'
                                    data-width="470" data-num-posts="10">
                                </div>
                            </div>
                        </div>
                    
            </div>
            <div class="col-right sidebar">
            <div class="block block-compare">
                    <div class="block-title">
                        <strong><span>Sản phẩm khuyến mãi</span></strong>
                    </div>
                    <div class="block-content">
                        <br />
                        <asp:Repeater ID="rptOfferItems" DataSource='<%# Eval("ListOfferItems")%>' runat="server">
                            <HeaderTemplate>
                                <ol>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li style="height: 70px;padding:2px">
                                    <div class="product-images" style="float: left">
                                        <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>">
                                            <img src="/pages/media/images/items/<%# Eval("ItemCd") %>/small/<%# Eval("ItemImage") %>"
                                                alt="<%# Eval("ItemName")%>" width="60" height="60"></a>
                                    </div>
                                    <div style="float: left; width: 140px">
                                        <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>">
                                            <%# Eval("ItemName")%></a>
                                            <br />
                                            Số lượng : <%# Eval("Quantity")%>

                                    </div>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ol>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="block block-compare">
                    <div class="block-title">
                        <strong><span>Sản phẩm liên quan</span></strong>
                    </div>
                    <div class="block-content">
                        <br />
                        <asp:Repeater ID="rptRelation" DataSource='<%# Eval("ListRelation")%>' runat="server">
                            <HeaderTemplate>
                                <ol>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li style="height: 70px;padding:2px">
                                    <div class="product-images" style="float: left">
                                        <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>">
                                            <img src="/pages/media/images/items/<%# Eval("ItemCd") %>/small/<%# Eval("ItemImage") %>"
                                                alt="<%# Eval("ItemName")%>" width="60" height="60"></a>
                                    </div>
                                    <div style="float: left; width: 140px">
                                        <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>">
                                            <%# Eval("ItemName")%></a><br /> <span class="regular-price" id="product-price-181-new"><span
                                                class="regular-price" id="Span2"><span style="text-align: right; color: #BF0000"
                                                    class="price">
                                                    <%# Eval("Price") %>
                                                </span>
                                                <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<span  style='text-align:right' class='pricesub'>" + Eval("PriceOld") + "</span>" : ""%>
                                            </span>
                                    </div>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ol>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>

            </div>
            
        </div>
    </div>
    </ItemTemplate>
                </asp:FormView>
    <%
        if (Session["haveBuy"] != null)
        {
    %>
    <script>
        showSuccessToast();
    </script>
    <% 
            Session["haveBuy"] = null;
        } %>
</asp:Content>
