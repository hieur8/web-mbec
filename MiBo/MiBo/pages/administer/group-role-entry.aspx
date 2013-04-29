<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master" AutoEventWireup="true" CodeBehind="group-role-entry.aspx.cs" Inherits="MiBo.pages.administer.group_role_entry" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <title>Thêm quyền</title>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Thêm quyền</h3>
        <ul class="content-box-tabs">
            <li><a href="#tabInfo" class="default-tab">Quyền</a></li>
        </ul>
        <div class="clear">
        </div>
    </div>
    <div class="content-box-content">
        <asp:FormView ID="fvwGroupRoleDatails" runat="server" RenderOuterTable="false">
            <ItemTemplate>
                <div class="tab-content default-tab" id="tabInfo">
                    <fieldset>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Mã nhóm</span>
                                </td>
                                <td width="180">
                                    <asp:HiddenField ID="hidGroupCd" Value='<%# Eval("GroupCd") %>' runat="server" />
                                    <asp:TextBox Width="100" Enabled="false" Text='<%# Eval("GroupCd") %>' ID="txtGroupCd" runat="server" CssClass="text-input"></asp:TextBox>
                                </td>
                                <td width="120">
                                    <span class="label">Tên nhóm</span>
                                </td>
                                <td>
                                    <asp:TextBox Width="180" Enabled="false" Text='<%# Eval("GroupName") %>' ID="txtGroupName" runat="server" CssClass="text-input"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Quyền</span>
                                </td>
                                <td width="180">
                                    <asp:DropDownList DataSource='<%# Eval("ListRole") %>' SelectedValue='<%# Bind("RoleCd") %>'
                                        DataValueField="Code" DataTextField="Name" ID="ddlRole" runat="server"
                                        CssClass="input-search text-input">
                                    </asp:DropDownList>
                                </td>
                                <td width="120">
                                    <span class="label">Dữ liệu</span>
                                </td>
                                <td >
                                    <asp:DropDownList DataSource='<%# Eval("ListDeleteFlag") %>' SelectedValue='<%# Bind("DeleteFlag") %>'
                                        DataValueField="Code" DataTextField="Name" ID="ddlDeleteFlag" runat="server"
                                        CssClass="input-search text-input">
                                    </asp:DropDownList>
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
                        </p>
                    </fieldset>
                </div>
            </ItemTemplate>
        </asp:FormView>
    </div>
    <script type="text/javascript">
        activeLink("#mnuUsers", "#lnkGroups");
    </script>
</asp:Content>
