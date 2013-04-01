<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="login.aspx.cs" Inherits="MiBo.pages.cln.login" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#frmMain").validate();
        });
    </script>
    <div class="main-container col1-layout">
        <div class="main">
            <div class="col-main">
                <div class="account-login">
                    <div class="page-title">
                        <h1>
                            Đăng nhập hoặc đăng ký thành viên mới</h1>
                    </div>
                    <div class="col2-set">
                        <div class="col-1 new-users">
                            <div class="content">
                                <h2>
                                    Đăng ký</h2>
                                <div class="clear">
                                </div>
                                <p>
                                    Hãy là thành viên của mibo.vn bạn sẽ nhận được những ưu đãi sau :
                                    <ul style="list-style-type:circle; padding: 5px 20px;">
                                        <li>Tặng thẻ giảm giá tương đương 10% giá trị đơn hàng (không áp dụng đối với sản phẩm khuyến mãi).</li>
                                        <li>Chiết khấu thưởng 1% khi tổng giá trị các đơn hàng đạt trên 5 triệu.</li>
                                        <li>Tặng phiếu mua hàng 200.000đ khi tổng giá trị các đơn hàng đạt trên 20 triệu.</li>
                                        <li>Khách hàng không phải thành viên của mibo.vn vẫn được ưu đãi tại mục 2 và 3</li>
                                    </ul>
                                    Hãy đăng ký ngay, chỉ 30 giây!</p>
                            </div>
                        </div>
                        <div class="col-2 registered-users">
                            <div class="content">
                                <h2>
                                    Đăng nhập</h2>
                                <div class="clear">
                                </div>
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
                                    <%
                                        if (Session["info"] != null)
                                        {
                                    %>
                                    <ul class="messages">
                                        <li class="success-msg">
                                            <ul>
                                                <li>
                                                    <%=Session["info"].ToString()%></li></ul>
                                        </li>
                                    </ul>
                                    <% 
                                Session["info"] = null;
                            } %>
                                </p>
                                <ul class="form-list">
                                    <li>
                                        <label for="email" class="required">
                                            <em>*</em>Email Address</label>
                                        <div class="input-box">
                                            <asp:TextBox ID="username" class="input-text required email" runat="server"></asp:TextBox>
                                        </div>
                                    </li>
                                    <li>
                                        <label for="pass" class="required">
                                            <em>*</em>Mật khẩu</label>
                                        <div class="input-box">
                                            <asp:TextBox ID="pass" minlength='6' TextMode="Password" class="input-text required"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </li>
                                </ul>
                                <p class="required">* Bắt buộc</p>
                            </div>
                        </div>
                    </div>
                    <div class="col2-set">
                        <div class="col-1 new-users">
                            <div class="buttons-set">
                                <a href="register.aspx" class="btn btn-orange" style="width: 120px"><span>Đăng ký ngay!</span></a>
                            </div>
                        </div>
                        <div class="col-2 registered-users">
                            <div class="buttons-set">
                                <a href="#" class="f-left">bạn đã quên mật khẩu?</a>
                                <asp:LinkButton ID="btnLogin" class="btn btn-blue" Width="120" runat="server" OnClick="btnLogin_Click"><span>Đăng nhập</span></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
