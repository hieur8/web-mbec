<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="profile.aspx.cs" Inherits="MiBo.pages.cln.profile" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="main-container col2-left-layout">
        <div class="main">
            <div class="col-main">
                <div class="my-account">
                    <asp:FormView ID="fvwProfile" runat="server" RenderOuterTable="false">
                        <ItemTemplate>
                            <div class="dashboard">
                                <div class="page-title">
                                    <h1>
                                        Tài khoản cá nhân</h1>
                                </div>
                                <div class="welcome-msg">
                                    <p class="hello">
                                        <strong>Xin chào <b>
                                            <%= Session["userName"] %></b> !</strong></p>
                                    <p>
                                        Tại trang này bạn có thể thay đổi thông tin cá nhân hay mật khẩu của mình, bạn cũng
                                        có thể xem lại lịch sử giao dịch của mình.</p>
                                </div>
                                <div class="box-account box-info">
                                    <div class="box-head">
                                        <h2>
                                            Thông tin tài khoản</h2>
                                    </div>
                                    <div class="col2-set">
                                        <div class="col-1">
                                            <div class="box">
                                                <div class="box-title">
                                                    <h3>
                                                        Thông tin liên hệ</h3>
                                                    <a href="/profile-edit.aspx">Chỉnh sửa</a>
                                                </div>
                                                <div class="box-content">
                                                    <p>
                                                        <%# Eval("FullName")%><br>
                                                        <%= Session["userName"] %><br>
                                                        <a href="/profile-edit.aspx?edit=pass">Thay đổi mật khẩu</a>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col2-set">
                                        <div class="box">
                                            <div class="box-content">
                                                <div class="col-1">
                                                    <h4>
                                                        Địa chỉ mặc địch</h4>
                                                    <address>
                                                        <%# Eval("Address")%><br>
                                                        <br>
                                                        (Thông tin này sẽ thay đổi theo đơn hàng mới nhật của bạn) </a>
                                                    </address>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:FormView>
                </div>
            </div>
            <div class="col-left sidebar">
                <div class="block block-account">
                    <div class="block-title">
                        <strong><span>Tài khoản</span></strong>
                    </div>
                    <div class="block-content">
                        <ul>
                            <li class="current"><strong>Trang tài khoản cá nhân</strong></li>
                            <li><a href="/profile-edit.aspx">Chỉnh sủa thông tin cá nhân</a></li>
                            <li><a href="/order-history.aspx">Lịch sử đơn hàng</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
