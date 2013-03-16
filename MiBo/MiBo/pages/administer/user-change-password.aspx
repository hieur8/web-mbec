<%@ Page Title="Thay đổi mật khẩu" Language="C#" MasterPageFile="~/pages/common/administer.Master" AutoEventWireup="true" CodeBehind="user-change-password.aspx.cs" Inherits="MiBo.pages.administer.user_change_password" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Thay đổi mật khẩu</h3>
        <div class="clear">
        </div>
    </div>
    <div class="content-box-content">
        <fieldset>
            <p>
                <label>
                    Mật khẩu</label>
                <asp:TextBox TextMode="Password" ID="txtPassword" runat="server" CssClass="text-input small-input"></asp:TextBox>
            </p>
            <p>
                <label>
                    Mật khẩu mới</label>
                <asp:TextBox TextMode="Password" ID="txtNewPassword" runat="server" CssClass="text-input small-input"></asp:TextBox>
            </p>
            <p>
                <label>
                    Mật khẩu xác nhận</label>
                <asp:TextBox TextMode="Password" ID="txtNewPasswordConfirm" runat="server" CssClass="text-input small-input"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnSave" runat="server" Text="Lưu" CssClass="button" OnCommand="btnSave_Command" />
            </p>
        </fieldset>
    </div>
</asp:Content>
