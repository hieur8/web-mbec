<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="profile-edit.aspx.cs" Inherits="MiBo.pages.cln.profile_edit" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#chkHasChagngePassword').change(function () {
                if (this.checked) {
                    $('#changePassDiv').css('display', 'block');
                } else {
                    $('#changePassDiv').css('display', 'none');
                };
            }).change();
        });
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="main-container col2-left-layout">
        <div class="main">
            <div class="col-main">
                <asp:FormView ID="fvwProfile" runat="server" RenderOuterTable="false">
                    <ItemTemplate>
                        <div class="my-account">
                            <div class="page-title">
                                <h1>
                                    Chỉnh sửa thông tin cá nhân</h1>
                            </div>
                            <div class="fieldset">
                                <h2 class="legend">
                                    Thông tin cá nhân</h2>
                                <ul class="form-list">
                                    <li class="fields">
                                        <div class="customer-name">
                                            <div class="field name-firstname">
                                                <label for="firstname" class="required">
                                                    <em>*</em>Họ và tên</label>
                                                <div class="input-box">
                                                    <asp:TextBox Text='<%# Eval("FullName") %>' ID="txtFullName" class="input-text required"
                                                        minlength="5" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                    <li>
                                        <label for="email_address" class="required">
                                            <em>*</em>Địa chỉ email</label>
                                        <div class="input-box">
                                            <input type="text" value='<%# Session["userName"] %>' class="input-text" readonly='true' />
                                        </div>
                                    </li>
                                    <li class="control">
                                        <div class="input-box">
                                            <asp:CheckBox ID="chkHasNewsletter" class="checkbox" Checked='<%# Bind("HasNewsletter") %>'
                                                runat="server" />
                                            <label for="is_subscribed">
                                                Đăng ký nhận tin tức</label>
                                        </div>
                                        <br />
                                        <div class="input-box">
                                            <asp:CheckBox ID="chkHasChagngePassword" ClientIDMode="Static" class="checkbox" Checked='<%# Bind("HasChangePassword") %>' runat="server" />
                                            <label for="is_subscribed">
                                                Thay đổi mật khẩu</label>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                            <div id="changePassDiv" class="fieldset" style="display: none">
                                <h2 class="legend">
                                    Thay đổi mật khẩu</h2>
                                <ul class="form-list">
                                    <li class="fields">
                                        <div class="field">
                                            <label for="password" class="required">
                                                <em>*</em>Mật khẩu cũ</label>
                                            <div class="input-box">
                                                <asp:TextBox ID="txtPassword" TextMode="Password" minlength="6" class="input-text required"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="field">
                                            <label for="password" class="required">
                                                <em>*</em>Mật khẩu mới</label>
                                            <div class="input-box">
                                                <asp:TextBox ID="txtNewPassword" TextMode="Password" minlength="6" class="input-text required"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="field">
                                            <label for="confirmation" class="required">
                                                <em>*</em>Nhập lại mật khẩu mới</label>
                                            <div class="input-box">
                                                <asp:TextBox ID="txtNewPasswordConfirm" TextMode="Password" class="input-text" runat="server"></asp:TextBox>
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
                            <li><a href="/pages/cln/profile.aspx">Trang tài khoản cá nhân</a></li>
                            <li class="current"><strong>Chỉnh sủa thông tin cá nhân</strong></li>
                            <li><a href="/pages/cln/order-history.aspx">Lịch sử đơn hàng</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
