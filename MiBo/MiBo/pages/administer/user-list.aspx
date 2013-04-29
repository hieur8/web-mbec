<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master" AutoEventWireup="true" CodeBehind="user-list.aspx.cs" Inherits="MiBo.pages.administer.user_list" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <title>Danh sách tài khoản</title>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.list-data').dataTable({
                "bJQueryUI": true,
                "bLengthChange": false,
                "aaSorting": [],
                "sScrollX": "100%",
                "sScrollXInner": "1830",
                "bScrollCollapse": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Danh sách tài khoản
        </h3>
        <div class="clear">
        </div>
    </div>
    <div class="content-box-content">
        <fieldset>
            <table>
                <tr>
                    <td width="120">
                        <span class="label">Tên đăng nhập</span>
                    </td>
                    <td width="220">
                        <asp:TextBox Width="200" ID="txtEmail" runat="server" CssClass="input-search text-input"></asp:TextBox>
                    </td>
                    <td width="70">
                        <span class="label">Họ tên</span>
                    </td>
                    <td>
                        <asp:TextBox Width="315" ID="txtFullName" runat="server" CssClass="input-search text-input"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td width="120">
                        <span class="label">Tỉnh thành</span>
                    </td>
                    <td width="220">
                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="input-search text-input"
                            DataValueField="Code" DataTextField="Name">
                        </asp:DropDownList>
                    </td>
                    <td width="70">
                        <span class="label">Nhóm</span>
                    </td>
                    <td width="150">
                        <asp:DropDownList ID="ddlGroup" runat="server" CssClass="input-search text-input"
                            DataValueField="Code" DataTextField="Name">
                        </asp:DropDownList>
                    </td>
                    <td width="80">
                        <span class="label">Dữ liệu</span>
                    </td>
                    <td width="80">
                        <asp:DropDownList ID="ddlDeleteFlag" runat="server" CssClass="input-search text-input"
                            DataValueField="Code" DataTextField="Name">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:LinkButton OnClick="btnSearch_Click" CssClass="button" ID="btnSearch" runat="server">Tìm kiếm</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <table class="list-data display">
        <thead>
            <tr>
                <th width="40">
                    &nbsp;
                </th>
                <th width="180">
                    Tên đăng nhập
                </th>
                <th width="250">
                    Họ tên
                </th>
                <th width="180">
                    Nhóm
                </th>
                <th width="180">
                    Tỉnh thành
                </th>
                <th width="250">
                    Điện thoại
                </th>
                <th width="450">
                    Địa chỉ
                </th>
                <th width="180">
                    Ngày cập nhật
                </th>
                <th width="120">
                    Dữ liệu
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptUsers" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:ImageButton OnCommand="btnAction_Command" CommandName="edit" CommandArgument='<%# Eval("UserCd") %>'
                                AlternateText="Cập nhật" ToolTip='Cập nhật' ImageUrl="/pages/resources/images/icons/edit.png"
                                ID="btnEdit" runat="server" />
                        </td>
                        <td>
                            <%# Eval("Email")%>
                        </td>
                        <td>
                            <%# Eval("FullName")%>
                        </td>
                        <td>
                            <%# Eval("GroupName")%>
                        </td>
                        <td>
                            <%# Eval("CityName")%>
                        </td>
                        <td>
                            <%# Eval("Phone1")%> - <%# Eval("Phone2")%>
                        </td>
                        <td>
                            <%# Eval("Address")%>
                        </td>
                        <td>
                            <%# Eval("UpdateDate")%>
                        </td>
                        <td>
                            <%# Eval("DeleteFlagName")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <script type="text/javascript">
        activeLink("#mnuUsers", "#lnkUsers");
    </script>
</asp:Content>
