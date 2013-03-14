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
                "sScrollXInner": "1820",
                "bScrollCollapse": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Danh sách sản phẩm
        </h3>
        <div class="clear">
        </div>
    </div>
    <div class="content-box-content">
        <fieldset>
            <table>
                <tr>
                    <td width="120">
                        <span class="label">Mã sản phẩm</span>
                    </td>
                    <td width="160">
                        <asp:TextBox Width="100" ID="txtItemCd" runat="server" CssClass="input-search text-input"></asp:TextBox>
                    </td>
                    <td width="120">
                        <span class="label">Tên sản phẩm</span>
                    </td>
                    <td>
                        <asp:TextBox Width="200" ID="txtItemName" runat="server" CssClass="input-search text-input"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td width="120">
                        <span class="label">Loại sản phẩm</span>
                    </td>
                    <td width="160">
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="input-search text-input">
                        </asp:DropDownList>
                    </td>
                    <td width="120">
                        <span class="label">Sản phẩm</span>
                    </td>
                    <td width="130">
                        <asp:DropDownList ID="ddlItemDiv" runat="server" CssClass="input-search text-input">
                        </asp:DropDownList>
                    </td>
                    <td width="80">
                        <span class="label">Đơn vị</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlUnit" runat="server" CssClass="input-search text-input">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td width="120">
                        <span class="label">Độ tuổi</span>
                    </td>
                    <td width="160">
                        <asp:DropDownList ID="ddlAge" runat="server" CssClass="input-search text-input">
                        </asp:DropDownList>
                    </td>
                    <td width="120">
                        <span class="label">Giới tính</span>
                    </td>
                    <td width="130">
                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="input-search text-input">
                        </asp:DropDownList>
                    </td>
                    <td width="80">
                        <span class="label">Dữ liệu</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDeleteFlag" runat="server" CssClass="input-search text-input">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td width="120">
                        <span class="label">Thương hiệu</span>
                    </td>
                    <td width="160">
                        <asp:DropDownList ID="ddlBrand" runat="server" CssClass="input-search text-input">
                        </asp:DropDownList>
                    </td>
                    <td width="120">
                        <span class="label">Xuất xứ</span>
                    </td>
                    <td width="130">
                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="input-search text-input">
                        </asp:DropDownList>
                    </td>
                    <td width="50">
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
                <th width="50">
                    &nbsp;
                </th>
                <th width="180">
                    Mã sản phẩm
                </th>
                <th width="480">
                    Tên sản phẩm
                </th>
                <th width="180">
                    Loại sản phẩm
                </th>
                <th width="100">
                    Độ tuổi
                </th>
                <th width="100">
                    Giới tính
                </th>
                <th width="150">
                    Thương hiệu
                </th>
                <th width="100">
                    Xuất xứ
                </th>
                <th width="100">
                    Đơn vị
                </th>
                <th width="150">
                    Sản phẩm
                </th>
                <th width="150">
                    Ngày cập nhật
                </th>
                <th width="80">
                    Dữ liệu
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptItems" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href='/item-details.aspx?pid=<%# Eval("ItemCd") %>' target="_blank">
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
