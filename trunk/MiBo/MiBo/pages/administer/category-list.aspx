<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master"
    AutoEventWireup="true" CodeBehind="category-list.aspx.cs" Inherits="MiBo.pages.administer.category_list" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <title>Danh sách loại sản phẩm</title>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.list-data').dataTable({
                "bJQueryUI": true,
                "bLengthChange": false,
                "aaSorting": [],
                "sScrollX": "100%",
                "sScrollXInner": "1060",
                "bScrollCollapse": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Danh sách loại sản phẩm
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
                <th width="120">
                    Mã loại
                </th>
                <th width="280">
                    Tên loại
                </th>
                <th width="180">
                    Chủng loại
                </th>
                <th width="140">
                    Thứ tự
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
            <asp:Repeater ID="rptCategories" runat="server">
                <ItemTemplate>
                    <tr ctrl="row">
                        <td>
                            <asp:CheckBox ctrl="edit" ID="chkEdit" runat="server" />
                            <asp:HiddenField ID="hidCategoryCd" Value='<%# Eval("CategoryCd") %>' runat="server" />
                        </td>
                        <td>
                            <%# Eval("CategoryCd")%>
                        </td>
                        <td>
                            <asp:TextBox ctrl="data" Width="200" Text='<%# Eval("CategoryName")%>' ID="txtCategoryName" runat="server"
                                CssClass="text-input"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ctrl="data" DataSource='<%# Eval("ListCategoryDiv") %>' SelectedValue='<%# Bind("CategoryDiv") %>'
                                DataValueField="Code" DataTextField="Name" ID="ddlCategoryDiv" runat="server"
                                CssClass="text-input">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ctrl="data" Width="80" Text='<%# Eval("SortKey")%>' ID="txtSortKey" runat="server"
                                CssClass="text-input"></asp:TextBox>
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
    <script type="text/javascript">
        activeLink("#mnuCategories", "#lnkCategories");
    </script>
</asp:Content>
