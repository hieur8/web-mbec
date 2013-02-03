<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MiBo.pages.cln.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 84px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
        <tr>
                <td colspan="2"><asp:Label ID="lbMsg" runat="server" Font-Bold="True" 
                        ForeColor="Red"></asp:Label>
                </td>
                </tr>
            <tr>
                <td class="style1">
                    Username :</td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    Password :</td>
                <td>
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click" 
                        Text="Login" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
