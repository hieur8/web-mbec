<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/customer.Master" AutoEventWireup="true"
    CodeBehind="confirmcheckout.aspx.cs" Inherits="MiBo.pages.cln.confirmcheckout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server" >
    <div class="main-container col2-right-layout">
        <div class="main">
            <div class="col-main">
                <div class="page-title">
                    <h1>Thanh toán</h1>
                </div>
                <ol class="opc" id="checkoutSteps">
                    <li id="opc-login" class="section allow active">
                        <div class="step-title">
                            <span class="number">0</span>
                            <h2>Phương thức mua hàng</h2>
                            <a href="#">Edit</a>
                        </div>
                        <div id="checkout-step-login" class="step a-item" style="">
                            <div class="col2-set">
                                <div class="col-1">
                                    <h3>Thanh toán nhanh hoặc đăng ký</h3>
                                    <p>
                                       <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></p>
                                    <ul class="form-list">
                                        <li class="control">
                                            <asp:RadioButton GroupName="rbMethod" class="radio" Text="Thanh toán không cần đăng ký" ID="method1"
                                                    runat="server" />
                                        </li>
                                        <li class="control">
                                                <asp:RadioButton GroupName="rbMethod" class="radio" Text="Đăng ký thành viên" ID="method2"
                                                    runat="server" />
                                        </li>
                                    </ul>
                                    <h4>
                                        Là thành viên Mibo thật nhanh chóng !</h4>
                                    <p>
                                        Bạn chỉ mất 30 giây :</p>
                                    <ul class="ul">
                                        <li>Đăng ký tài khoản thường</li>
                                        <li>Đăng ký bằng tài khoản Facebook hoặc google của bạn </li>
                                    </ul>
                                </div>
                                <div class="col-2">
                                    <h3>
                                        Đăng nhập</h3>
                                    <form id="login-form" action="http://www.magento-themes.jextn.com/demo/mageno_blue_toys_theme_demo/index.php/customer/account/loginPost/"
                                    method="post">
                                    <fieldset>
                                        <h4>
                                            Bạn đã là thành viên của Mibo</h4>
                                <asp:Label ID="lbMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                </p>
                                        <ul class="form-list">
                                            <li>
                                                <label for="login-email" class="required">
                                                    <em>*</em>Email</label>
                                                <div class="input-box">
                                                    <asp:TextBox class="input-text" ID="username" runat="server"></asp:TextBox>
                                                </div>
                                            </li>
                                            <li>
                                                <label for="login-password" class="required">
                                                    <em>*</em>Mật khẩu</label>
                                                <div class="input-box">
                                                   <asp:TextBox class="input-text" TextMode="Password" ID="pass" runat="server"></asp:TextBox>
                                                </div>
                                            </li>
                                        </ul>
                                    </fieldset>
                                    </form>
                                </div>
                            </div>
                            <div class="col2-set">
                                <div class="col-1">
                                    <div class="buttons-set">
                                        <p class="required">
                                            &nbsp;</p>
                                        <asp:Button ID="Button2" runat="server" Text="Xác nhận" 
                                            onclick="Button2_Click1" />
                                    </div>
                                </div>
                                <div class="col-2">
                                    <div class="buttons-set">
                                        <p class="required">
                                            * Bắt buộc nhập</p>
                                        <a href="#"
                                            class="f-left">Bạn quên mật khẩu ?</a>
                                        <asp:Button ID="Button1" runat="server" Text="Đăng nhập" 
                                            onclick="Button1_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>
                </ol>
            </div>
            <div class="col-right sidebar">
                <div id="checkout-progress-wrapper">
                   <div id="Div1">
                    <div class="block block-progress">
                        <div class="block-title">
                            <strong><span>Quá trình mua hàng</span></strong>
                        </div>
                        <div class="block-content">
                            <dl>
                                <dt>Thông tin đơn hàng</dt>
                                <dt>Thông tin giao hàng</dt>
                                <dt>Phương thức thanh toán</dt>
                                <dt>Xác nhận đơn hàng</dt>
                            </dl>
                        </div>
                    </div>
                </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
