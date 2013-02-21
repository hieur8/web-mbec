<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/customer.Master" AutoEventWireup="true"
    CodeBehind="login.aspx.cs" Inherits="MiBo.pages.cln.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="main-container col1-layout">
    <div class="main">
        <div class="col-main">
            <div class="account-login">
                <div class="page-title">
                    <h1>
                        Đăng nhập hoặc đăng ký thành viên mới</h1>
                </div>
                <form id="form1" runat="server">
                <div class="col2-set">
                    <div class="col-1 new-users">   
                        <div class="content">
                            <h2>Đăng ký</h2>
                            <div class="clear">
                            </div>
                            <p>
                                Hãy là thành viên của Mibo.vn. bạn sẽ được những ưu đãi cực kỳ lớn như giảm 5% cho mỗi hóa đơn và còn nhiều khuyến mãi khác. Hãy đăng ký ngay , chỉ 30 giây !</p>
                        </div>
                    </div>
                    <div class="col-2 registered-users">
                        <div class="content">
                            <h2>
                                Đăng nhập</h2>
                            <div class="clear">
                            </div>
                            <p>
                                <asp:Label ID="lbMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                </p>
                            <ul class="form-list">
                                <li>
                                    <label for="email" class="required">
                                        <em>*</em>Email Address</label>
                                    <div class="input-box">
                                        <asp:TextBox ID="username" class="input-text" runat="server"></asp:TextBox>
                                    </div>
                                </li>
                                <li>
                                    <label for="pass" class="required">
                                        <em>*</em>Mật khẩu</label>
                                    <div class="input-box">
                                    <asp:TextBox ID="pass" TextMode="Password" class="input-text" runat="server"></asp:TextBox>
                                    </div>
                                </li>
                            </ul>
                            <p class="required">
                                * Bắt buộc</p>
                        </div>
                    </div>
                </div>
                <div class="col2-set">
                    <div class="col-1 new-users">
                        <div class="buttons-set">
                            <button type="button" title="Create an Account" class="button" onclick="window.location='http://www.magento-themes.jextn.com/demo/mageno_blue_toys_theme_demo/index.php/customer/account/create/';">
                                <span><span>Tạo tài khoản mới</span></span></button>
                        </div>
                    </div>
                    <div class="col-2 registered-users">
                        <div class="buttons-set">
                            <a href="#" class="f-left">bạn đã quên mật khẩu?</a>
                            <asp:Button ID="btnLogin" class="button" runat="server" Text="Login" 
                                onclick="btnLogin_Click" />
                        </div>
                    </div>
                </div>
                </form>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
