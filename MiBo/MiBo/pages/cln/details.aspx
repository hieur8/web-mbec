<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/customer.Master" AutoEventWireup="true"
    CodeBehind="details.aspx.cs" Inherits="MiBo.pages.cln.details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <asp:HiddenField ID="hidItemCd" runat="server" />
    <asp:HiddenField ID="hidItemDiv" runat="server" />
    <asp:HiddenField ID="hidOfferDiv" runat="server" />
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
    <link rel="stylesheet" type="text/css" href="../resources/styles/jquery.ad-gallery.css">
    <script type="text/javascript" src="../resources/scripts/jquery.ad-gallery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            var galleries = $('.ad-gallery').adGallery();

        });
    </script>
    <div class="main-container col2-right-layout">
        <div class="main">
            <div class="col-main">
                <div class="breadcrumbs">
                    <ul>
                        <li class="home"><a href="#" title="Go to Home Page">Trang chủ</a> <span>/ </span>
                        </li>
                        <li class="category37"><a href="#" title="">Đồ chơi</a> <span>/ </span></li>
                        <li class="product"><strong>Teddy Bear Yellow</strong> </li>
                    </ul>
                </div>
                
                <div id="messages_product_view">
                </div>
                <div class="product-view">
                    <div class="product-essential">
                        <form action="http://www.magento-themes.jextn.com/demo/mageno_blue_toys_theme_demo/index.php/checkout/cart/add/uenc/aHR0cDovL3d3dy5tYWdlbnRvLXRoZW1lcy5qZXh0bi5jb20vZGVtby9tYWdlbm9fYmx1ZV90b3lzX3RoZW1lX2RlbW8vaW5kZXgucGhwL2dpZnRzaG9wL3RlZGR5LWJlYXIteWVsbG93Lmh0bWw_X19fU0lEPVU,/product/173/"
                        method="post" id="product_addtocart_form">
                        <div class="no-display">
                            <input type="hidden" name="product" value="173">
                            <input type="hidden" name="related_product" id="related-products-field" value="">
                        </div>
                        <div class="product-shop">
                            <div class="product-name">
                                <h1>
                                    <asp:Label ID="litItemName" runat="server"></asp:Label></span></h1>
                            </div>
                            <div class="price-box">
                                <span class="regular-price" id="product-price-173"><span class="price">
                                    <asp:Label ID="litPrice" runat="server"></asp:Label></span> </span>
                            </div>
                            <p class="availability in-stock">
                                Tình trạng: <span>Còn hàng</span></p>
                            <p class="availability in-stock">
                                Thương hiệu: <span>Phwk</span></p>
                            <p class="availability in-stock">
                                Xuất xứ: <span>Trung quốc</span></p>
                            <div class="add-to-box">
                                <div class="add-to-cart" style="display: block">
                                    <table border="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox Text="1" MaxLength="6" Width="80px" CssClass="qty spin" ID="txtItemQtty"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span class="buttonRow">
                                                    <asp:LinkButton OnCommand="lnkBuy_Command" ID="lnkBuy" runat="server">Cho vào giỏ hàng</asp:LinkButton>
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="short-description">
                                <h2>
                                    Mô tả sản phẩm</h2>
                                <div class="std">
                                    <asp:Literal ID="litNotes" runat="server"></asp:Literal>
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
                                        <asp:Repeater ID="rptItemImage" runat="server">
                                            <HeaderTemplate>
                                                <ul class="ad-thumb-list">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <li><a href='<%# string.Format("/pages/media/images/items/{0}/larger/{1}", hidItemCd.Value, Container.DataItem)%>'>
                                                    <img src='<%# string.Format("/pages/media/images/items/{0}/small/{1}", hidItemCd.Value, Container.DataItem)%>'
                                                        class="image0">
                                                </a></li>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </ul></FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearer">
                        </div>
                        </form>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="box-collateral box-up-sell">
                        <h2>
                            Like và bình luận với Facebook</h2>
                    </div>
                </div>
            </div>
            <div class="col-right sidebar">
                <div class="block block-cart">
                    <div class="block-title">
                        <strong><span>Giỏ hàng</span></strong>
                    </div>
                    <div class="block-content">
                        <p class="empty">
                            Bạn chưa mua sản phẩm nào.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
