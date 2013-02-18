<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/customer.Master" AutoEventWireup="true"
    CodeBehind="cart.aspx.cs" Inherits="MiBo.pages.cln.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container col1-layout">
        <div class="main">
            <div class="col-main">
                <div class="cart">
                    <div class="page-title title-buttons">
                        <h1>
                            Shopping Cart</h1>
                        <ul class="checkout-types">
                            <li>
                                <button type="button" title="Proceed to Checkout" class="button btn-checkout" onclick="window.location='checkout.aspx';">
                                    <span><span>Proceed to Checkout</span></span></button>
                            </li>
                        </ul>
                    </div>
                    <ul class="messages">
                        <li class="success-msg">
                            <ul>
                                <li>Plan toys đã được thêm vào giỏ hàng.</li></ul>
                        </li>
                        <li class="error-msg">
                            <ul>
                                <li>Có lỗi</li></ul>
                        </li>
                        <li class="notice-msg">
                            <ul>
                                <li>Cảnh báo</li></ul>
                        </li>
                    </ul>
                    <fieldset>
                        <table id="shopping-cart-table" class="data-table cart-table">
                            <colgroup>
                                <col>
                                <col>
                                <col width="1">
                                <col width="1">
                                <col width="1">
                                <col width="1">
                                <col width="1">
                            </colgroup>
                            <thead>
                                <tr class="first last">
                                    <th rowspan="1">
                                        <span class="nobr">Tên sản phẩm</span>
                                    </th>
                                    <th rowspan="1">
                                        <span class="nobr">Mô tả</span>
                                    </th>
                                    <th rowspan="1" class="prod-image-cart-table">
                                        Hình ảnh
                                    </th>
                                    <th class="a-center" colspan="1">
                                        <span class="nobr">Giá</span>
                                    </th>
                                    <th rowspan="1" class="a-center">
                                        Số lượng
                                    </th>
                                    <th class="a-center" colspan="1">
                                        Thành tiền
                                    </th>
                                    <th rowspan="1" class="a-center">
                                        Xóa
                                    </th>
                                </tr>
                            </thead>
                            <tfoot>
                                <tr class="first last">
                                    <td colspan="50" class="a-right last">
                                        <button type="button" title="Continue Shopping" class="button btn-continue">
                                            <span><span>Tiếp tục mua hàng</span></span></button>
                                        <button type="submit" title="Update Shopping Cart" class="button btn-update">
                                            <span><span>Cập nhật giỏ hàng</span></span></button>
                                    </td>
                                </tr>
                            </tfoot>
                            <tbody>
                                <tr class="first last odd">
                                    <td>
                                        <h2 class="product-name">
                                            <a href="/mageno_blue_toys_theme_demo/index.php/plan-toys.html">
                                                Plan toys</a>
                                        </h2>
                                    </td>
                                    <td class="prod-short-description">
                                        abc xyz
                                    </td>
                                    <td>
                                        <a href="#"
                                            title="Plan toys">
                                            <img src="../media/images/items/01/small/01.jpg"
                                                width="75" height="75" alt="Plan toys"></a>
                                    </td>
                                    <td class="a-right">
                                        <span class="cart-price"><span class="price">200.000 vnđ</span> </span>
                                    </td>
                                    <td class="a-center">
                                        <input name="cart[526][qty]" value="1" size="4" title="Qty" class="input-text qty"
                                            maxlength="12">
                                    </td>
                                    <td class="a-right">
                                        <span class="cart-price"><span class="price">200.000 vnđ</span> </span>
                                    </td>
                                    <td class="a-center padding-part-removebutton last">
                                        <a href="#" title="Remove item" class="btn-remove2">Remove item</a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                   </fieldset>
                    <div class="cart-collaterals">
                        <div class="col2-set">
                            <div class="col-1">
                                <div class="crosssell">
                                    <h2>
                                        Danh sách sản phẩm khuyến mãi</h2>
                                    <ul id="crosssell-products-list">
                                        <li class="item odd"><a class="product-image" href="#"
                                            title="Bee Toy">
                                            <img src="../media/images/items/01/small/01.jpg"
                                                width="111" height="123" alt="Bee Toy"></a>
                                            <div class="product-details">
                                                <h3 class="product-name">
                                                    <a href="/mageno_blue_toys_theme_demo/index.php/bee-toy.html">
                                                        Bee Toy</a></h3>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="totals">
                                <table id="shopping-cart-totals-table">
                                    <colgroup>
                                        <col>
                                        <col width="1">
                                    </colgroup>
                                    <tfoot>
                                        <tr>
                                            <td style="" class="a-right" colspan="1">
                                                <strong>Tổng tiền</strong>
                                            </td>
                                            <td style="" class="a-right">
                                                <strong><span class="price">$200.00</span></strong>
                                            </td>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
