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
                                    Hãy là thành viên của Mibo.vn. bạn sẽ được những ưu đãi cực kỳ lớn như giảm 5% cho
                                    mỗi hóa đơn và còn nhiều khuyến mãi khác. Hãy đăng ký ngay , chỉ 30 giây !</p>
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
                            } %>                    </p>
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
                                            <asp:TextBox ID="pass" minlength='6' TextMode="Password" class="input-text required" runat="server"></asp:TextBox>
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
                                <a href="register.aspx" ><h3>Đăng ký ngay !</h3></a>
                                </div>
                        </div>
                        <div class="col-2 registered-users">
                            <div class="buttons-set">
                                <a href="#" class="f-left">bạn đã quên mật khẩu?</a>
                                <asp:Button ID="btnLogin" class="design2" runat="server" Text="Đăng nhập" OnClick="btnLogin_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
