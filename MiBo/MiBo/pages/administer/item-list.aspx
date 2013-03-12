<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master"
    AutoEventWireup="true" CodeBehind="item-list.aspx.cs" Inherits="MiBo.pages.administer.item_list" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <title>Danh sách sản phẩm</title>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.list-data').dataTable({
                "bJQueryUI": true,
                "bLengthChange": false,
                "aaSorting": [],
                "sScrollX": "100%",
                "sScrollXInner": "1720",
                "bScrollCollapse": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box">
        <div class="content-box-header">
            <h3>
                Danh sách sản phẩm
            </h3>
            <div class="clear">
            </div>
        </div>
        <div class="content-box-content">
            <fieldset>
                Tên sản phẩm: <asp:TextBox ID="txtItemName" runat="server" CssClass="input-search text-input"></asp:TextBox>
                Loại sản phẩm: <asp:DropDownList ID="ddlCategory" runat="server" CssClass="input-search text-input"></asp:DropDownList>
                Độ tuổi: <asp:DropDownList ID="ddlAge" runat="server" CssClass="input-search text-input"></asp:DropDownList>
                Giới tính: <asp:DropDownList ID="ddlGender" runat="server" CssClass="input-search text-input"></asp:DropDownList>
                <br />
                Thương hiệu: <asp:DropDownList ID="ddlBrand" runat="server" CssClass="input-search text-input"></asp:DropDownList>
                Xuất xứ: <asp:DropDownList ID="ddlCountry" runat="server" CssClass="input-search text-input"></asp:DropDownList>
                Đơn vị: <asp:DropDownList ID="ddlUnit" runat="server" CssClass="input-search text-input"></asp:DropDownList>
                Sản phẩm: <asp:DropDownList ID="ddlItemDiv" runat="server" CssClass="input-search text-input"></asp:DropDownList>
                <asp:LinkButton OnClick="btnSearch_Click" CssClass="button" ID="btnSearch" runat="server">Tìm kiếm</asp:LinkButton>
            </fieldset>
        </div>
    </div>
    <table class="list-data display">
        <thead>
            <tr>
                <th style="width: 40px !important">
                    &nbsp;
                </th>
                <th style="width: 150px !important">
                    Mã sản phẩm
                </th>
                <th style="width: 450px !important">
                    Tên sản phẩm
                </th>
                <th style="width: 150px !important">
                    Loại sản phẩm
                </th>
                <th style="width: 100px !important">
                    Độ tuổi
                </th>
                <th style="width: 100px !important">
                    Giới tính
                </th>
                <th style="width: 150px !important">
                    Thương hiệu
                </th>
                <th style="width: 100px !important">
                    Xuất xứ
                </th>
                <th style="width: 100px !important">
                    Đơn vị
                </th>
                <th style="width: 150px !important">
                    Sản phẩm
                </th>
                <th style="width: 150px !important">
                    Ngày cập nhật
                </th>
                <th style="width: 80px !important">
                    &nbsp;
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptItems" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href='/item-details.aspx?pid=<%# Eval("ItemCd") %>'>
                                <img src="/pages/resources/images/icons/view.png" alt="Xem" title="Xem" />
                            </a>
                            <asp:ImageButton OnCommand="btnAction_Command" CommandName="edit" CommandArgument='<%# Eval("ItemCd") %>'
                                AlternateText="Cập nhật" ToolTip='Cập nhật' ImageUrl="/pages/resources/images/icons/edit.png"
                                ID="btnEdit" runat="server" />
                        </td>
                        <td>
                            <%# Eval("ItemCd") %>
                        </td>
                        <td>
                            <%# Eval("ItemName") %>
                        </td>
                        <td>
                            <%# Eval("CategoryName")%>
                        </td>
                        <td>
                            <%# Eval("AgeName")%>
                        </td>
                        <td>
                            <%# Eval("GenderName")%>
                        </td>
                        <td>
                            <%# Eval("BrandName")%>
                        </td>
                        <td>
                            <%# Eval("CountryName")%>
                        </td>
                        <td>
                            <%# Eval("UnitName")%>
                        </td>
                        <td>
                            <%# Eval("ItemDivName")%>
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
        activeLink("#mnuItems", "#lnkItems");
    </script>
</asp:Content>
