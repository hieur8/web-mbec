<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload-image.aspx.cs" Inherits="MiBo.pages.administer.upload_image" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formUpload" runat="server">
    <div>
        <asp:HiddenField ID="hidFileId" runat="server" />
        <asp:HiddenField ID="hidFileGroup" runat="server" />
        <asp:FileUpload ID="fulPath" runat="server" />
        <asp:TextBox ID="txtSortKey" runat="server"></asp:TextBox>
        <asp:LinkButton ID="lnkUpload" runat="server" OnClick="lnkUpload_Click">Tải lên</asp:LinkButton>
        <asp:Repeater ID="rptFiles" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <asp:HiddenField ID="hidFileId" runat="server" Value='<%# Eval("FileId") %>' />
                    <asp:HiddenField ID="hidFileNo" runat="server" Value='<%# Eval("FileNo") %>' />
                    <%# Eval("FileName")%>
                </li>
                <li>
                    <img alt="" src="\pages\media\images\<%# Eval("FileGroup") %>\small\<%# Eval("FileName")%>" />
                </li>
                <li>
                    <asp:TextBox ID="txtSortKey" runat="server" Text='<%# Eval("SortKey")%>'></asp:TextBox>
                </li>
                <li>
                    <asp:LinkButton CommandArgument='<%# Eval("FileId")+";"+Eval("FileNo") %>' ID="lnkDelete"
                        runat="server" OnCommand="lnkDelete_Command">Xóa</asp:LinkButton>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
        <asp:LinkButton ID="lnkUpdateAll" runat="server" OnClick="lnkUpdateAll_Click">Cập nhật tất cả</asp:LinkButton>
        <asp:LinkButton ID="lnkDeleteAll" runat="server" OnClick="lnkDeleteAll_Click">Xóa tất cả</asp:LinkButton>
    </div>
    </form>
</body>
</html>
