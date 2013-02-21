<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/customer.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="MiBo.pages.cln.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
                <div class="col-main">
                	                                        <div class="account-create">
    <div class="page-title">
        <h1>Tạo tài khoản mới</h1>
    </div>
            <form runat="server"  id="form1">
        <div class="fieldset">
            <input type="hidden" name="success_url" value="">
            <input type="hidden" name="error_url" value="">
            <h2 class="legend">Thông tin tài khoản</h2>
            <p>
                                <asp:Label ID="lbMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                </p>
            <ul class="form-list">
                <li class="fields">
                    <div class="customer-name">
    <div class="field name-firstname">
        <label for="firstname" class="required"><em>*</em>Họ và tên</label>
        <div class="input-box">
            <asp:TextBox ID="fullName" class="input-text" runat="server"></asp:TextBox>
        </div>
    </div>
</div>
                </li>
                <li>
                    <label for="email_address" class="required"><em>*</em>Địa chỉ email</label>
                    <div class="input-box">
                        <asp:TextBox ID="email" class="input-text" runat="server"></asp:TextBox>
                    </div>
                </li>
                                <li class="control">
                    <div class="input-box">
                        <input type="checkbox" name="is_subscribed" title="Sign Up for Newsletter" value="1" id="is_subscribed" class="checkbox">
                    </div>
                    <label for="is_subscribed">Đăng ký nhận tin tức</label>
                </li>
                                                                                                    </ul>
        </div>
            <div class="fieldset">
            <h2 class="legend">Thông tin đăng nhập</h2>
            <ul class="form-list">
                <li class="fields">
                    <div class="field">
                        <label for="password" class="required"><em>*</em>Mật khẩu</label>
                        <div class="input-box">
                           <asp:TextBox ID="pass" TextMode="Password" class="input-text" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <label for="confirmation" class="required"><em>*</em>Nhập lại mật khẩu</label>
                        <div class="input-box">
                           <asp:TextBox ID="passConfirm" TextMode="Password" class="input-text" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
        <div class="buttons-set">
            <p class="required">* Bắt buộc</p>
            <p class="back-link"><a href="#" class="back-link"><small>« </small>Quay lại</a></p>
            <asp:Button 
                    ID="btnRegister" runat="server" Text="Đăng ký" 
                onclick="btnRegister_Click" />
                
        </div>
    </form>
</div>
                </div>
            </div>
</asp:Content>
