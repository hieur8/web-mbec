<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="order-details.aspx.cs" Inherits="MiBo.pages.cln.order_details" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="main-container col2-left-layout">
        <div class="main">
            <div class="col-main">
                <asp:FormView ID="fvwAccept" runat="server" RenderOuterTable="false">
                    <ItemTemplate>
                        <div class="my-account">
                            <div class="page-title title-buttons">
                                <h1>
                                    Đơn hàng #<%# Eval("AcceptSlipNo")%>
                                    - <b>Trạng thái</b></h1>
                                <a href="#" class="link-reorder">
                                    <%# Eval("SlipStatusName") %></a>
                            </div>
                            <p class="order-date">
                                Ngày đặt hàng:
                                <%# Eval("AcceptDate")%></p>
                            <div class="col2-set order-info-box">
                                <div class="col-1">
                                    <div class="box">
                                        <div class="box-title">
                                            <h2>
                                                Địa chỉ giao hàng</h2>
                                        </div>
                                        <div class="box-content">
                                            <address>
                                                <%# Eval("DeliveryName")%><br>
                                                <%# Eval("DeliveryAddress")%><br>
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
                                                <%# Eval("DeliveryName")%><br>
                                                <%# Eval("DeliveryAddress")%><br>
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
                                                <%# Eval("PaymentMethodsName")%></p>
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
                                    <tbody class="odd">
                                        <asp:Repeater ID="rptAcceptDetails" runat="server" DataSource='<%# Eval("ListAcceptDetails") %>'>
                                            <ItemTemplate>
                                                <tr class="border first" id="order-item-row-49">
                                                    <td>
                                                        <h3 class="product-name">
                                                            <%# Eval("ItemName") %></h3>
                                                    </td>
                                                    <td class="a-right">
                                                        <span class="price-excl-tax"><span class="cart-price"><span class="price">
                                                            <%# Eval("Price") %></span> </span></span>
                                                        <br>
                                                    </td>
                                                    <td class="a-right">
                                                        <span class="nobr"><strong>
                                                            <%# Eval("Quantty") %></strong><br>
                                                        </span>
                                                    </td>
                                                    <td class="a-right last">
                                                        <span class="price-excl-tax"><span class="cart-price"><span class="price">
                                                            <%# Eval("Amount") %></span> </span></span>
                                                        <br>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                    <tfoot>
                                        <tr class="grand_total last">
                                            <td colspan="4" class="a-right">
                                                <strong>Tông tiền</strong>
                                            </td>
                                            <td class="last a-right">
                                                <strong><span class="price"><%# Eval("TotalAmount")%></span></strong>
                                            </td>
                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                            <div class="buttons-set">
                                <p class="back-link">
                                    <a href="/order-history.aspx"><small>« </small>Quay lại trang lịch sử đơn hàng</a></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:FormView>
            </div>
            <div class="col-left sidebar">
                <div class="block block-account">
                    <div class="block-title">
                        <strong><span>Tài khoản</span></strong>
                    </div>
                    <div class="block-content">
                        <ul>
                            <li><a href="/profile.aspx">Trang tài khoản cá nhân</a></li>
                            <li><a href="/profile-edit.aspx">Chỉnh sủa thông tin cá nhân</a></li>
                            <li class="current"><strong>Lịch sử đơn hàng</strong></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
