<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/customer.Master" AutoEventWireup="true"
    CodeBehind="profile-edit.aspx.cs" Inherits="MiBo.pages.cln.profile_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container col2-left-layout">
        <div class="main">
            <div class="col-main">
                <div class="my-account">
                    <div class="page-title">
                        <h1>
                            Chỉnh sửa thông tin cá nhân</h1>
                    </div>
                    <form id="form1" runat="server">
                    <div class="fieldset">
                        <input name="form_key" type="hidden" value="VILFimoYYY03fGPP">
                        <h2 class="legend">
                            Thông tin cá nhân</h2>
                        <ul class="form-list">
                            <li class="fields">
                                <div class="customer-name">
                                    <div class="field name-firstname">
                                        <label for="firstname" class="required">
                                            <em>*</em>Họ và tên</label>
                                        <div class="input-box">
                                            <asp:TextBox ID="fullName" class="input-text required" minlength="5" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <label for="email_address" class="required">
                                    <em>*</em>Địa chỉ email</label>
                                <div class="input-box">
                                    <asp:TextBox ID="email" class="input-text" runat="server"></asp:TextBox>
                                </div>
                            </li>
                            <li class="control">
                                <div class="input-box">
                                    <asp:CheckBox ID="is_subscribed" class="checkbox" Checked="true" runat="server" />
                                    <label for="is_subscribed">
                                        Đăng ký nhận tin tức</label>
                                </div>
                                <br />
                                <div class="input-box">
                                    <asp:CheckBox ID="CheckBox1" class="checkbox" onclick="$('#passDiv').css('display', 'block')" runat="server" />
                                    <label for="is_subscribed">
                                        Thay đổi mật khẩu</label>
                                </div>
                            </li>
                        </ul>
                    </div>
                    <div class="fieldset" style="">
        <h2 class="legend">Thay đổi mật khẩu</h2>
        <ul class="form-list">
            <li>
                <label for="current_password" class="required">Mật khẩu cũ<em>*</em></label>
                <div class="input-box">
                    <input type="password" title="Current Password" class="input-text required-entry" name="current_password" id="current_password">
                </div>
            </li>
            <li class="fields">
                <div class="field">
                    <label for="password" class="required"><em>*</em>Mật khẩu mới</label>
                    <div class="input-box">
                        <input type="password" title="New Password" class="input-text validate-password required-entry" name="password" id="password">
                    </div>
                </div>
                <div class="field">
                    <label for="confirmation" class="required"><em>*</em>Nhập lại mật khẩu mới</label>
                    <div class="input-box">
                        <input type="password" title="Confirm New Password" class="input-text validate-cpassword required-entry" name="confirmation" id="confirmation">
                    </div>
                </div>
            </li>
        </ul>
    </div>
                    <div class="fieldset" style="display:none">
                    <h2 class="legend">
                        Thay đổi mật khẩu</h2>
                    <ul class="form-list">
                        <li class="fields">
                        <div class="field">
                                <label for="password" class="required">
                                    <em>*</em>Mật khẩu cũ</label>
                                <div class="input-box">
                                    <asp:TextBox ID="TextBox1" TextMode="Password" minlength="6" class="input-text required"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="field">
                                <label for="password" class="required">
                                    <em>*</em>Mật khẩu mới</label>
                                <div class="input-box">
                                    <asp:TextBox ID="pass" TextMode="Password" minlength="6" class="input-text required"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="field">
                                <label for="confirmation" class="required">
                                    <em>*</em>Nhập lại mật khẩu mới</label>
                                <div class="input-box">
                                    <asp:TextBox ID="passConfirm" TextMode="Password" class="input-text" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
                    <div class="buttons-set">
                        <p class="required">
                            * Bắt buộc</p>
                           <asp:Button class="button" ID="Button1" runat="server" Text="Thay đổi" />
                    </div>
                    </form>
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
                            <li class="current"><strong>Chỉnh sủa thông tin cá nhân</strong></li>
                            <li><a href="order-history.aspx">Lịch sử đơn hàng</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
