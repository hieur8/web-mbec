<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user-login.aspx.cs" Inherits="MiBo.pages.administer.user_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <!--                       CSS                       -->
    <!-- Reset Stylesheet -->
    <link rel="stylesheet" href="/pages/resources/styles/reset.css" type="text/css" media="screen" />
    <!-- Main Stylesheet -->
    <link rel="stylesheet" href="/pages/resources/styles/admin.css" type="text/css" media="screen" />
    <!-- Invalid Stylesheet. This makes stuff look pretty. Remove it if you want the CSS completely valid -->
    <link rel="stylesheet" href="/pages/resources/styles/invalid.css" type="text/css" media="screen" />
    <!-- Colour Schemes
		Default colour scheme is green. Uncomment prefered stylesheet to use it.
		<link rel="stylesheet" href="/pages/resources/styles/blue.css" type="text/css" media="screen" />
		<link rel="stylesheet" href="/pages/resources/styles/red.css" type="text/css" media="screen" />  
		-->
    <!-- Internet Explorer Fixes Stylesheet -->
    <!--[if lte IE 7]>
			<link rel="stylesheet" href="/pages/resources/styles/ie.css" type="text/css" media="screen" />
		<![endif]-->
    <!--                       Javascripts                       -->
    <!-- jQuery -->
    <script type="text/javascript" src="/pages/resources/scripts/jquery-1.7.1.min.js"></script>
    <!-- jQuery Configuration -->
    <script type="text/javascript" src="/pages/resources/scripts/simpla.jquery.configuration.js"></script>
    <!-- Facebox jQuery Plugin -->
    <script type="text/javascript" src="/pages/resources/scripts/facebox.js"></script>
    <!-- jQuery WYSIWYG Plugin -->
    <script type="text/javascript" src="/pages/resources/scripts/jquery.wysiwyg.js"></script>
    <!-- Internet Explorer .png-fix -->
    <!--[if IE 6]>
			<script type="text/javascript" src="/pages/resources/scripts/DD_belatedPNG_0.0.7a.js"></script>
			<script type="text/javascript">
				DD_belatedPNG.fix('.png_bg, img, li');
			</script>
		<![endif]-->

    <title>MiBo Admin | Đăng nhập</title>
</head>
<body id="login">
    <div id="login-wrapper" class="png_bg">
        <div id="login-top">
            <h1>
                MiBo Admin</h1>
            <!-- Logo (221px width) -->
            <img id="logo" src="/pages/resources/images/Logo.gif" alt="MiBo Admin logo" />
        </div>
        <!-- End #logn-top -->
        <div id="login-content">
            <form id="frmLogin" runat="server">
            <% if (Session["error"] != null)
               { %>
            <div class="notification error png_bg">
                <div>
                    <%= Session["error"]%>
                </div>
            </div>
            <% }
               else
               { %>
            <div class="notification information png_bg">
                <div>
                    Vui lòng đăng nhập để truy cập vào hệ thống
                </div>
            </div>
            <% } %>
            <p>
                <label>
                    Tên đăng nhập</label>
                <asp:TextBox CssClass="text-input" ID="txtUserName" runat="server"></asp:TextBox>
            </p>
            <div class="clear">
            </div>
            <p>
                <label>
                    Mật khẩu</label>
                <asp:TextBox TextMode="Password" CssClass="text-input" ID="txtPassword" runat="server"></asp:TextBox>
            </p>
            <div class="clear">
            </div>
            <p>
                <asp:Button CssClass="button" ID="btnLogin" runat="server" Text="Đăng nhập" OnClick="btnLogin_Click" />
            </p>
            </form>
        </div>
        <!-- End #login-content -->
    </div>
    <!-- End #login-wrapper -->
</body>
</html>
<% Session["error"] = null; %>
