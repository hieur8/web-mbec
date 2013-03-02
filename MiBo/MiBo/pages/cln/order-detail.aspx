<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="order-detail.aspx.cs" Inherits="MiBo.pages.cln.order_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="main-container col2-left-layout">
        <div class="main">
            <div class="col-main">
                <div class="my-account">
                    <div class="page-title title-buttons">
                        <h1>
                            Đơn hàng #100000024 - <b>Trạng thái</b></h1>
                        <a href="#" class="link-reorder">Hủy đơn hàng</a>
                    </div>
                    <p class="order-date">
                        Ngày đặt hàng: February 25, 2013</p>
                    <div class="col2-set order-info-box">
                        <div class="col-1">
                            <div class="box">
                                <div class="box-title">
                                    <h2>
                                        Địa chỉ giao hàng</h2>
                                </div>
                                <div class="box-content">
                                    <address>
                                        hieu nguyen (tên ng nhận)<br>
                                        123 adhsa(địa chỉ)<br>
                                    </address>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col2-set order-info-box">
                        <div class="col-1">
                            <div class="box">
                                <div class="box-title">
                                    <h2>
                                        Thông tin đặt hàng</h2>
                                </div>
                                <div class="box-content">
                                    <address>
                                        hieu nguyen (ng dat)<br>
                                        123 adhsa (dia chi ng dat)<br>
                                    </address>
                                </div>
                            </div>
                        </div>
                        <div class="col-2">
                            <div class="box box-payment">
                                <div class="box-title">
                                    <h2>
                                        Phương thức thanh toán</h2>
                                </div>
                                <div class="box-content">
                                    <p>
                                        Chuyển khoản</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="order-items">
                        <h2>
                            Danh sách sản phẩm đã mua
                        </h2>
                        <table class="data-table" id="my-orders-table" summary="Items Ordered">
                            <colgroup>
                                <col>
                                <col width="1">
                                <col width="1">
                                <col width="1">
                                <col width="1">
                            </colgroup>
                            <thead>
                                <tr class="first last">
                                    <th>
                                        Tên sản phẩm
                                    </th>
                                    <th class="a-right">
                                        Giá
                                    </th>
                                    <th class="a-center">
                                        Số lượng
                                    </th>
                                    <th class="a-right">
                                        Thành tiền
                                    </th>
                                </tr>
                            </thead>
                            <tfoot>
                                <tr class="grand_total last">
                                    <td colspan="4" class="a-right">
                                        <strong>Tông tiền</strong>
                                    </td>
                                    <td class="last a-right">
                                        <strong><span class="price">$130.00</span></strong>
                                    </td>
                                </tr>
                            </tfoot>
                            <tbody class="odd">
                                <tr class="border first" id="order-item-row-49">
                                    <td>
                                        <h3 class="product-name">
                                            Teddy Bear Brown</h3>
                                    </td>
                                    <td class="a-right">
                                        <span class="price-excl-tax"><span class="cart-price"><span class="price">$45.00</span>
                                        </span></span>
                                        <br>
                                    </td>
                                    <td class="a-right">
                                        <span class="nobr"><strong>1</strong><br>
                                        </span>
                                    </td>
                                    <td class="a-right last">
                                        <span class="price-excl-tax"><span class="cart-price"><span class="price">$45.00</span>
                                        </span></span>
                                        <br>
                                    </td>
                                </tr>
                            </tbody>
                            <tbody class="even">
                                <tr class="border" id="order-item-row-50">
                                    <td>
                                        <h3 class="product-name">
                                            Remote Controlled Car</h3>
                                    </td>
                                    <td class="a-right">
                                        <span class="price-excl-tax"><span class="cart-price"><span class="price">$60.00</span>
                                        </span></span>
                                        <br>
                                    </td>
                                    <td class="a-right">
                                        <span class="nobr">Ordered: <strong>1</strong><br>
                                        </span>
                                    </td>
                                    <td class="a-right last">
                                        <span class="price-excl-tax"><span class="cart-price"><span class="price">$60.00</span>
                                        </span></span>
                                        <br>
                                    </td>
                                    <!--
        <th class="a-right"><span class="price">$60.00</span></th>
            -->
                                </tr>
                            </tbody>
                            <tbody class="odd">
                                <tr class="border last" id="order-item-row-51">
                                    <td>
                                        <h3 class="product-name">
                                            Bouncing Ball</h3>
                                    </td>
                                    <td class="a-right">
                                        <span class="price-excl-tax"><span class="cart-price"><span class="price">$10.00</span>
                                        </span></span>
                                        <br>
                                    </td>
                                    <td class="a-right">
                                        <span class="nobr">Ordered: <strong>1</strong><br>
                                        </span>
                                    </td>
                                    <td class="a-right last">
                                        <span class="price-excl-tax"><span class="cart-price"><span class="price">$10.00</span>
                                        </span></span>
                                        <br>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="buttons-set">
                        <p class="back-link">
                            <a href="#"><small>« </small>Quay lại trang lịch sử đơn hàng</a></p>
                    </div>
                </div>
            </div>
            <div class="col-left sidebar">
                <div class="block block-account">
                    <div class="block-title">
                        <strong><span>Tài khoản</span></strong>
                    </div>
                    <div class="block-content">
                        <ul>
                            <li><a href="/pages/cln/profile.aspx">Trang tài khoản cá nhân</a></li>
                            <li><a href="/pages/cln/profile-edit.aspx">Chỉnh sủa thông tin cá nhân</a></li>
                            <li class="current"><strong>Lịch sử đơn hàng</strong></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
