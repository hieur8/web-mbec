<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master"
    AutoEventWireup="true" CodeBehind="group-role-list.aspx.cs" Inherits="MiBo.pages.administer.group_role_list" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <title>Danh sách quyền</title>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.list-data').dataTable({
                "bJQueryUI": true,
                "bLengthChange": false,
                "aaSorting": [],
                "sScrollX": "100%",
                "sScrollXInner": "900",
                "bScrollCollapse": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Danh sách quyền
        </h3>
        <div class="clear">
        </div>
    </div>
    <table class="list-data display">
        <thead>
            <tr>
                <th width="40">
                    &nbsp;
                </th>
                <th width="280">
                    Tên nhóm
                </th>
                <th width="280">
                    Tên quyền
                </th>
                <th width="120">
                    Dữ liệu
                </th>
                <th width="180">
                    Ngày cập nhật
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptGroupRoles" runat="server">
                <ItemTemplate>
                    <tr ctrl="row">
                        <td>
                            <asp:CheckBox ctrl="edit" ID="chkEdit" runat="server" />
                            <asp:HiddenField ID="hidGroupCd" Value='<%# Eval("GroupCd") %>' runat="server" />
                            <asp:HiddenField ID="hidRoleCd" Value='<%# Eval("RoleCd") %>' runat="server" />
                        </td>
                        <td>
                            <%# Eval("GroupName")%>
                        </td>
                        <td>
                            <%# Eval("RoleName")%>
                        </td>
                        <td>
                            <asp:DropDownList ctrl="data" DataSource='<%# Eval("ListDeleteFlag") %>' SelectedValue='<%# Bind("DeleteFlag") %>'
                                DataValueField="Code" DataTextField="Name" ID="ddlDeleteFlag" runat="server"
                                CssClass="text-input">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%# Eval("UpdateDate")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
        <tfoot>
            <tr>
                <td>
                    <asp:LinkButton OnClick="btnUpdate_Click" CssClass="button" ID="btnUpdate" runat="server">Cập nhật</asp:LinkButton>
                </td>
            </tr>
        </tfoot>
    </table>
    <div class="clear">
    </div>
    <p style="padding-left:10px">
        <asp:HiddenField ID="hidGroupCd" runat="server" />
        <asp:LinkButton ID="btnAddRole" runat="server" CssClass="button" OnCommand="btnAddRole_Command"
            CausesValidation="false">Thêm quyền</asp:LinkButton>
        <asp:LinkButton ID="btnList" runat="server" CssClass="button" OnCommand="btnList_Command"
            CausesValidation="false">Danh sách nhóm</asp:LinkButton>
    </p>
    <script type="text/javascript">
        activeLink("#mnuUsers", "#lnkGroups");
    </script>
</asp:Content>
