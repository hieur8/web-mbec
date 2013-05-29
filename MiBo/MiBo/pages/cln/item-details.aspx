    <%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="item-details.aspx.cs" Inherits="MiBo.pages.cln.item_details" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <!-- Spin -->
    <script src="/pages/resources/scripts/jquery.jqzoom-core-pack.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="/pages/resources/styles/jquery.jqzoom.css">
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
    <script type="text/javascript">
        $(document).ready(function () {
            $('.jqzoom').jqzoom({
                zoomType: 'standard',
                lens: true,
                preloadImages: false,
                alwaysOn: false
            });

        });
    </script>
    <style>
        ul#thumblist
        {
            display: block;
        }
        ul#thumblist li
        {
            float: left;
            margin-right: 2px;
            list-style: none;
        }
        ul#thumblist li a
        {
            display: block;
            border: 1px solid #CCC;
        }
        ul#thumblist li a.zoomThumbActive
        {
            border: 1px solid #00aff0;
        }
        
        .jqzoom
        {
            text-decoration: none;
            float: left;
        }
    </style>
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
                                    <h3>
                                        <%# Eval("ItemName")%></h3>
                                    <hr size="1" />
                                    <table width="100%" border="0" class="table_details">
                                        <tr>
                                            <td width="120">
                                                Giá
                                            </td>
                                            <td>
                                                <span class="regular-price" id="product-price-173"><span class="price">
                                                    <%# Eval("Price")%></span>
                                                    <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<span class='pricesub'>" + Eval("PriceOld") + "</span>" : ""%>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Mã sản phẩm
                                            </td>
                                            <td>
                                                <span>
                                                    <%# Eval("ItemCd")%></span>
                                            </td>
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
                                            <td>
                                                Xuất xứ
                                            </td>
                                            <td>
                                                <span>
                                                    <%# Eval("CountryName")%></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Độ tuổi sử dụng
                                            </td>
                                            <td>
                                                <span>
                                                    <%# Eval("AgeName")%></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Chất liệu
                                            </td>
                                            <td>
                                                <span>
                                                    <%# Eval("Material")%></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Số lượng
                                            </td>
                                            <td>
                                                <asp:TextBox Text="1" MaxLength="6" Width="40px" CssClass="spin" ID="txtItemQtty"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="add-to-box">
                                        <div class="add-to-cart" style="display: block">
                                            <div style="float: left;">
                                                <asp:LinkButton CssClass="add-more" OnCommand="lnkBuy_Command" CommandArgument='<%# Eval("ItemCd") %>'
                                                    ID="lnkBuy" runat="server">Cho vào giỏ hàng</asp:LinkButton>
                                                <asp:LinkButton CssClass="buy-now" OnCommand="lnkBuyNow_Command" CommandArgument='<%# Eval("ItemCd") %>'
                                                    ID="lnkBuyNow" runat="server">Thêm vào giỏ hàng</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                    <div>
                                        <ul class="f-left supportInfo">
                                            <li class="bullet">Giao hàng trong vòng 2 ngày làm việc (trừ chủ nhật)</li>
                                            <li class="bullet">Hổ trợ khách hàng: <b>
                                                <%# Eval("Hotline")%></b></li>
                                        </ul>
                                    </div>
                                </div>
                                <div style="padding-left: 15px; z-index: 3" class="product-img-box">
                                
                                    <div class="clearfix">
                                        <a href="./pages/media/images/items/zoom/<%=firstImage%>"
                                            class="jqzoom" rel='gal1' title="Mibo.vn">
                                            <img src="./pages/media/images/items/larger/<%=firstImage%>"
                                                title="triumph" style="z-index:2333;border: 4px solid #666;width:400px;height:400px;border:1px solid #ddd;margin-bottom:5px;">
                                        </a></div>
                                        <br /> <br />
                                        <div class="clearfix">
                                        <asp:Repeater ID="rptItemImage" runat="server" DataSource='<%# Eval("ListImages")%>'>
                                                    <HeaderTemplate>
                                                        <ul id="thumblist" class="clearfix">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                    <li><a href='javascript:void(0);' rel="{gallery: 'gal1', smallimage: './pages/media/images/items/larger/<%# Eval("ItemImage")%>',largeimage: './pages/media/images/items/zoom/<%# Eval("ItemImage")%>'}">
                                                    <img src="./pages/media/images/items/small/<%# Eval("ItemImage")%>" width="60px" height="60px"></a></li>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </ul>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                        </div>
                                    
                                </div>
                                <div class="clearer">
                                    <ul class="idTabs idTabsShort">
                                        <li><a href="#idTab1" class="selected">Mô tả sản phẩm</a></li>
                                        <li><a href="#idTab2">Thông tin Thương hiệu</a></li>
                                        <%# Equals("", Eval("LinkVideo")) ? "" : "<li><a href='#idTab3'>Youtube</a></li>"%>
                                    </ul>
                                    <div id="more_info_sheets" class="bgcolor bordercolor">
                                        <div id="idTab1" style="padding: 20px;">
                                            <div>
                                                <%# Eval("Notes")%>
                                            </div>
                                        </div>
                                        <div id="idTab2" style="padding: 20px;">
                                            <div>
                                                <%# Eval("BrandInfo")%>
                                            </div>
                                        </div>
                                        <%# Equals("", Eval("LinkVideo")) ? "" : 
                                            "<div id='idTab3' style='padding: 20px;'><div><center><iframe width='425' height='349' src='" + Eval("LinkVideo") + "'  frameborder='0' allowfullscreen='true'></iframe></center></div></div>"
                                        %>
                                    </div>
                                </div>
                                <div class="box-collateral box-up-sell">
                                    <h2>
                                        Like và bình luận với Facebook</h2>
                                    <div class="fb-like" data-href='http://mibo.vn/item-details.aspx?pid=<%# Eval("ItemCd")%>'
                                        data-send="false" data-width="760" data-show-faces="false" data-font="arial">
                                    </div>
                                    <br />
                                    <div class="fb-comments" data-href='http://mibo.vn/item-details.aspx?pid=<%# Eval("ItemCd")%>'
                                        data-width="760" data-num-posts="10">
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>
                        <div class="col-right sidebar">
                        <% 
                            if (hasOffer == true)
                            {
                         %>
                            <div class="block block-compare">
                                <div class="block-title">
                                    <strong><span>Quà tặng kèm</span></strong>
                                </div>
                                <div class="block-content">
                                    <br />
                                    <asp:Repeater ID="rptOfferItems" DataSource='<%# Eval("ListOfferItems")%>' runat="server">
                                        <HeaderTemplate>
                                            <ol>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li style="height: 70px; padding: 2px">
                                                <div class="product-images" style="float: left">
                                                    <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>">
                                                        <img src="/pages/media/images/items/small/<%# Eval("ItemImage") %>" alt="<%# Eval("ItemName")%>"
                                                            width="60" height="60" style="padding: 0 5px 0 5px"></a>
                                                </div>
                                                <div style="float: left; width: 140px">
                                                    <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>">
                                                        <%# Eval("ItemName")%></a>
                                                    <br />
                                                    Số lượng :
                                                    <%# Eval("Quantity")%>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ol>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <% } %>
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
                                            <li style="height: 70px; padding: 2px">
                                                <div class="product-images" style="float: left">
                                                    <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>">
                                                        <img src="/pages/media/images/items/small/<%# Eval("ItemImage") %>" alt="<%# Eval("ItemName")%>"
                                                            width="60" height="60" style="padding: 0 5px 0 5px"></a>
                                                </div>
                                                <div style="float: left; width: 140px">
                                                    <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>">
                                                        <%# Eval("ItemName")%></a><br />
                                                    <span class="regular-price" id="product-price-181-new"><span class="regular-price"
                                                        id="Span2"><span style="text-align: right; color: #BF0000" class="price">
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
                        </div> </div>
                    </ItemTemplate>
                </asp:FormView>
                <%
                    if (Session["haveBuy"] != null)
                    {
                %>
                <script type="text/javascript">
                    showSuccessToast();
                </script>
                <% 
                        Session["haveBuy"] = null;
                    } %>
</asp:Content>
