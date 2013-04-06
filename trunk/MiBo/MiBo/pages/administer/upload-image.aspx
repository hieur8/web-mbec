<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload-image.aspx.cs" Inherits="MiBo.pages.administer.upload_image" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Button ajaxshake -->
    <link href="/pages/resources/styles/ajaxshake.btn.css" rel="stylesheet" type="text/css" />
    <style>
        ul
        {
            list-style: none;
            position: relative;
            padding-top: 5px;
            border: 0;
        }
        ul, li
        {
            margin: 0;
            padding: 0;
            border: 0;
            outline: 0;
            font-size: 12px;
            font-weight: normal;
            vertical-align: top;
            background: transparent;
        }
    </style>
</head>
<body>
    <form id="formUpload" runat="server">
    <div>
        <asp:HiddenField ID="hidFileId" runat="server" />
        <asp:HiddenField ID="hidFileGroup" runat="server" />
        <asp:FileUpload ID="fulPath" runat="server" />
        <asp:TextBox ID="txtSortKey" runat="server"></asp:TextBox>
        <asp:LinkButton ID="lnkUpload" runat="server" CssClass="btn btn-blue" OnClick="lnkUpload_Click"><span>Tải lên</span></asp:LinkButton>
        <asp:Repeater ID="rptFiles" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <asp:HiddenField ID="hidFileId" runat="server" Value='<%# Eval("FileId") %>' />
                    <asp:HiddenField ID="hidFileNo" runat="server" Value='<%# Eval("FileNo") %>' />
                    <asp:TextBox Width="40px" ID="txtSortKey" runat="server" Text='<%# Eval("SortKey")%>'></asp:TextBox>
                    <asp:LinkButton CommandArgument='<%# Eval("FileId")+";"+Eval("FileNo") %>' ID="lnkDelete"
                        runat="server" OnCommand="lnkDelete_Command"><img src="../resources/images/close.gif" border="0" /></asp:LinkButton><br />
                    <img alt="" src="\pages\media\images\<%# Eval("FileGroup") %>\small\<%# Eval("FileName")%>" />
                    
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <asp:LinkButton CssClass="btn btn-khaki" ID="lnkUpdateAll" runat="server" OnClick="lnkUpdateAll_Click"><span>Cập nhật tất cả</span></asp:LinkButton>
        <asp:LinkButton CssClass="btn btn-red" ID="lnkDeleteAll" runat="server" OnClick="lnkDeleteAll_Click"><span>Xóa tất cả</span></asp:LinkButton>
    </div>
    </form>
</body>
</html>
