<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="register.aspx.cs" Inherits="MiBo.pages.cln.register" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#frmMain").validate();
            $('#<%=passConfirm.ClientID%>').attr('equalTo', '#<%=pass.ClientID%>');
        });
    </script>
    <div class="main">
        <div class="col-main">
            <div class="account-create">
                <div class="page-title">
                    <h1>
                        Tạo tài khoản mới</h1>
                </div>
                <div class="fieldset">
                    <input type="hidden" name="success_url" value="">
                    <input type="hidden" name="error_url" value="">
                    <h2 class="legend">
                        Thông tin tài khoản</h2>
                    <p>
                        <%
                            if (Session["error"] != null)
                            {
                        %>
                        <ul class="messages">
                            <li class="error-msg">
                                <ul>
                                    <li>
                                        <%=Session["error"].ToString()%></li></ul>
                            </li>
                        </ul>
                        <% 
                                Session["error"] = null;
                            } %>
                    </p>
                    <ul class="form-list">
                        <li class="fields">
                            <div class="customer-name">
                                <div class="field name-firstname">
                                    <label for="firstname" class="required">
                                        <em>*</em>Họ</label>
                                    <div class="input-box">
                                        <asp:TextBox ID="fullName" class="input-text required" minlength="2" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="field name-lastname">
                                    <label for="lastname" class="required">
                                        <em>*</em>Tên</label>
                                    <div class="input-box">
                                    <asp:TextBox ID="fullName2" class="input-text required" minlength="2" runat="server"></asp:TextBox>
  
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li>
                            <label for="email_address" class="required">
                                <em>*</em>Địa chỉ email</label>
                            <div class="input-box">
                                <asp:TextBox ID="email" class="input-text required email" runat="server"></asp:TextBox>
                            </div>
                        </li>
                        <li class="fields">
                            <div class="field">
                                <label for="password" class="required">
                                    <em>*</em>Mật khẩu</label>
                                <div class="input-box">
                                    <asp:TextBox ID="pass" TextMode="Password" minlength="6" class="input-text required"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="field">
                                <label for="confirmation" class="required">
                                    <em>*</em>Nhập lại mật khẩu</label>
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
                    <p class="back-link">
                        <a href="#" class="back-link"><small>« </small>Quay lại</a></p>
                    <asp:Button ID="btnRegister" class="button" runat="server" Text="Đăng ký" OnClick="btnRegister_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
