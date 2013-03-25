<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="confirmcheckout.aspx.cs" Inherits="MiBo.pages.cln.confirmcheckout" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="main-container">
        <div class="main">
            <div class="col-main">
                <div class="page-title">
                    <h1>
                        Thanh toán</h1>
                </div>
                <ol class="opc" id="checkoutSteps">
                    <li id="opc-login" class="section allow active">
                        <div class="step-title">
                            <span class="number">1</span>
                            <h2>
                                Phương thức thanh toán</h2>
                            <a href="#">Edit</a>
                        </div>
                        <div id="checkout-step-login" class="step a-item" style="">
                            <div class="col2-set">
                                <div class="col-1">
                                    <h3>Thanh toán nhanh hoặc đăng ký</h3>
                                    <p>
                                       <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></p>
                                    <p>
                                       <span id="main_Label1" style="color:Red;font-weight:bold;"></span></p>
                                     <ul class="form-list">
                                        <li class="control">
                                            <asp:RadioButton GroupName="rbMethod" class="radio" Text="Thanh toán không cần đăng ký" ID="method1"
                                                    runat="server" />
                                        </li>
                                        <li class="control">
                                                <asp:RadioButton GroupName="rbMethod" class="radio" Text="Đăng ký thành viên" ID="method2"
                                                    runat="server" />
                                        </li>
                                        <li class="control">
                                                <asp:RadioButton GroupName="rbMethod" class="radio" Text="Đăng nhập" ID="method3"
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
                                
                            </div>
                            <div class="col2-set">
                                <div class="col-1">
                                    <div class="buttons-set">
                                        <p class="required">
                                            &nbsp;</p>
                                       <asp:Button ID="Button2" runat="server" Text="Xác nhận" onclick="Button2_Click" 
                                            />
                                    </div>
                                </div>
                                
                            </div>
                           
                        </div>
                    </li>
                </ol>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
