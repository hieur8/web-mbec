<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="order-history.aspx.cs" Inherits="MiBo.pages.cln.order_history" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
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
                            <strong>(<asp:Literal ID="litAcceptCount" runat="server"></asp:Literal>) Đơn hàng</strong>
                        </p>
                    </div>
                    <asp:Repeater ID="rptAccept" runat="server">
                        <HeaderTemplate>
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
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="first last odd">
                                <td>
                                    <%# Eval("AcceptSlipNo")%>
                                </td>
                                <td>
                                    <span class="nobr">
                                        <%# Eval("AcceptDate")%></span>
                                </td>
                                <td>
                                    <%# Eval("DeliveryName")%>
                                </td>
                                <td>
                                    <span class="price">
                                        <%# Eval("TotalAmount")%></span>
                                </td>
                                <td>
                                    <em>
                                        <%# Eval("SlipStatusName")%></em>
                                </td>
                                <td class="a-center last">
                                    <span class="nobr"><a href='/order-details.aspx?order=<%# Eval("AcceptSlipNo")%>'>Chi
                                        tiết</a></span>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody> </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
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
