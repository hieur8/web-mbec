<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="details.aspx.cs" Inherits="MiBo.pages.cln.details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="main-container col2-right-layout">
        <div class="main">
            <div class="col-main">
                <div class="breadcrumbs">
                    <ul>
                        <li class="home"><a href="" title="Go to Home Page">Home</a> <span>/ </span></li>
                        <li class="category37"><strong>{Category name}</strong> </li>
                    </ul>
                </div>
                <div class="category-products">
                    <div class="grid-view">
                        <ul class="products-grid last odd" style="border-bottom: 3px solid #44BED3;">
                            <li class="item first"><a href="/item-details.aspx?pid=01" title="Item 01" class="product-image">
                                <img width="170" height="170" border="0" src="/pages/media/images/items/01/normal/01.jpg"
                                    alt="Item 01">
                            </a>&nbsp;<div class="align-prodname-price-review">
                                <h3 class="product-name">
                                    <a href="/item-details.aspx?pid=01" title="Item 01">Item 01</a>
                                </h3>
                                <div class="price-box">
                                    <p style="margin: 0">
                                        Thương hiệu : Lego</p>
                                    <span class="regular-price" id="product-price-181-new"><span style="text-align: right"
                                        class="price">108.000 ₫ </span><span style="text-align: right" class="pricesub">120.000
                                            ₫</span> </span>
                                </div>
                            </div>
                            </li>
                        </ul>
                    </div>
                    <div class="toolbar-bottom">
                    </div>
                </div>
                <div class="toolbar">
                    <div class="pager">
                        <p class="view-mode">
                            <label>
                            </label>
                            <strong title="Grid" class="grid">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</strong>&nbsp;
                            <a href="giftshop.html?mode=list" title="List" class="list">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a>&nbsp;
                        </p>
                        <p class="amount">
                            Sản phẩm 1 đến 9 của tất cả 10
                        </p>
                        <div class="pages">
                            <strong>Trang:</strong>
                            <ol>
                                <li class="current">1</li>
                                <li><a href="giftshop.html?p=2">2</a></li>
                            </ol>
                        </div>
                        <div class="sort-by">
                            <label>
                                Sort By</label>
                            <select onchange="setLocation(this.value)">
                                <option value="#" selected="selected">Position </option>
                                <option value="#">Name </option>
                                <option value="#">Price </option>
                            </select>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-right sidebar">
                <div class="perfume1">
                    <div class="tbl-right-box box-176 padd-bg-hotline ui-corner-tbl-top">
                        <span class="ui-hotline-2"></span>
                        <p class="padd-hotline-2">
                            <span style="font-size: 12px">hotline (24/7)</span>
                        </p>
                        <h4 class="num-hot">
                            0976.585.888</h4>
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
                                        Giảm 10% cho các thành viên mibo.vn</p>
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
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
