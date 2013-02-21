<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/customer.Master" AutoEventWireup="true"
    CodeBehind="order-history.aspx.cs" Inherits="MiBo.pages.cln.order_history" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container col2-left-layout">
        <div class="main">
            <div class="col-main">
                <div class="my-account">
                    <div class="page-title">
                        <h1>
                            Đơn hàng của bạn</h1>
                    </div>
                    <div class="pager">
                        <p class="amount">
                            <strong>(1) Đơn hàng</strong>
                        </p>
                    </div>
                    <table class="data-table" id="my-orders-table">
                        <colgroup>
                            <col width="1">
                            <col width="1">
                            <col>
                            <col width="1">
                            <col width="1">
                            <col width="1">
                        </colgroup>
                        <thead>
                            <tr class="first last">
                                <th>
                                    No
                                </th>
                                <th>
                                    Ngày
                                </th>
                                <th>
                                    Giao đến
                                </th>
                                <th>
                                    <span class="nobr">Tổng tiền</span>
                                </th>
                                <th>
                                    <span class="nobr">Tình trang</span>
                                </th>
                                <th>
                                    &nbsp;
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr class="first last odd">
                                <td>
                                    100000023
                                </td>
                                <td>
                                    <span class="nobr">2/20/13</span>
                                </td>
                                <td>
                                    hieu nguyen
                                </td>
                                <td>
                                    <span class="price">200.000 vnđ</span>
                                </td>
                                <td>
                                    <em>Hoàn thành</em>
                                </td>
                                <td class="a-center last">
                                    <span class="nobr"><a href="#">Chi tiết</a></span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="col-left sidebar">
                <div class="block block-account">
                    <div class="block-title">
                        <strong><span>Tài khoản</span></strong>
                    </div>
                    <div class="block-content">
                        <ul>
                            <li><a href="accounts.aspx">Trang tài khoản cá nhân</a></li>
                            <li><a href="profile-edit.aspx">Chỉnh sủa thông tin cá nhân</a></li>
                            <li class="current"><strong>Lịch sử đơn hàng</strong></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
