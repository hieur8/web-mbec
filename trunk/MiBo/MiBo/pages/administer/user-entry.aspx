<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master"
    AutoEventWireup="true" CodeBehind="user-entry.aspx.cs" Inherits="MiBo.pages.administer.user_entry" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <title>Thêm/sửa tài khoản</title>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Thêm/sửa tài khoản</h3>
        <ul class="content-box-tabs">
            <li><a href="#tabInfo" class="default-tab">Tài khoản</a></li>
        </ul>
        <div class="clear">
        </div>
    </div>
    <div class="content-box-content">
        <asp:FormView ID="fvwUserDatails" runat="server" RenderOuterTable="false">
            <ItemTemplate>
                <asp:HiddenField ID="hidStatus" Value='<%# Eval("Status") %>' runat="server" />
                <asp:HiddenField ID="hidUserCd" Value='<%# Eval("UserCd") %>' runat="server" />
                <div class="tab-content default-tab" id="tabInfo">
                    <fieldset>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Tên đăng nhập</span>
                                </td>
                                <td width="220">
                                    <asp:TextBox Width="200" Text='<%# Eval("Email") %>' Enabled='<%# Eval("Status") == "add" %>'
                                        ID="txtEmail" runat="server" CssClass="text-input"></asp:TextBox>
                                </td>
                                <td width="70">
                                    <span class="label">Họ tên</span>
                                </td>
                                <td>
                                    <asp:TextBox Width="315" Text='<%# Eval("FullName") %>' ID="txtFullName" runat="server"
                                        CssClass="text-input"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Tỉnh thành</span>
                                </td>
                                <td width="220">
                                    <asp:DropDownList DataSource='<%# Eval("ListCity") %>' SelectedValue='<%# Bind("CityCd") %>'
                                        DataValueField="Code" DataTextField="Name" ID="ddlCity" runat="server" CssClass="input-search text-input">
                                    </asp:DropDownList>
                                </td>
                                <td width="70">
                                    <span class="label">Nhóm</span>
                                </td>
                                <td width="150">
                                    <asp:DropDownList DataSource='<%# Eval("ListGroup") %>' SelectedValue='<%# Bind("GroupCd") %>'
                                        DataValueField="Code" DataTextField="Name" ID="ddlGroup" runat="server"
                                        CssClass="input-search text-input" Enabled='<%# Eval("Status") == "add" %>'>
                                    </asp:DropDownList>
                                </td>
                                <td width="80">
                                    <span class="label">Dữ liệu</span>
                                </td>
                                <td>
                                    <asp:DropDownList DataSource='<%# Eval("ListDeleteFlag") %>' SelectedValue='<%# Bind("DeleteFlag") %>'
                                        DataValueField="Code" DataTextField="Name" ID="ddlDeleteFlag" runat="server"
                                        CssClass="input-search text-input">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Điện thoại</span>
                                </td>
                                <td width="200">
                                    <asp:TextBox Width="180" Text='<%# Eval("Phone1") %>' ID="txtPhone1" runat="server"
                                        CssClass="text-input"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox Width="180" Text='<%# Eval("Phone2") %>' ID="txtPhone2" runat="server"
                                        CssClass="text-input"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Địa chỉ</span>
                                </td>
                                <td>
                                    <asp:TextBox Width="400" Text='<%# Eval("Address") %>' ID="txtAddress" runat="server"
                                        CssClass="text-input"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <div class="clear">
                        </div>
                        <p>
                            <asp:LinkButton ID="btnSave" runat="server" CssClass="button" OnCommand="btnSave_Command">
                            Lưu</asp:LinkButton>
                            &nbsp;
                            <asp:LinkButton ID="btnList" runat="server" CssClass="button" OnCommand="btnList_Command"
                                CausesValidation="false">Danh sách</asp:LinkButton>
                            &nbsp;
                            Đăng ký tài khoản với mật khẩu '<%# Eval("Password")%>'
                        </p>
                    </fieldset>
                </div>
            </ItemTemplate>
        </asp:FormView>
    </div>
    <script type="text/javascript">
        activeLink("#mnuUsers", "#lnkUserEntry");
    </script>
</asp:Content>
