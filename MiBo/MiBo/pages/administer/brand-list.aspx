<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master"
    AutoEventWireup="true" CodeBehind="brand-list.aspx.cs" Inherits="MiBo.pages.administer.brand_list" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <title>Danh sách thương hiệu</title>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.list-data').dataTable({
                "bJQueryUI": true,
                "bLengthChange": false,
                "aaSorting": [],
                "sScrollX": "100%",
                "sScrollXInner": "970",
                "bScrollCollapse": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Danh sách thương hiệu
        </h3>
        <div class="clear">
        </div>
    </div>
    <div class="content-box-content">
        <fieldset>
            <table>
                <tr>
                    <td width="60">
                        <span class="label">Mã TH</span>
                    </td>
                    <td width="160">
                        <asp:TextBox Width="100" ID="txtBrandCd" runat="server" CssClass="input-search text-input"></asp:TextBox>
                    </td>
                    <td width="80">
                        <span class="label">Tên TH</span>
                    </td>
                    <td width="250">
                        <asp:TextBox Width="200" ID="txtBrandName" runat="server" CssClass="input-search text-input"></asp:TextBox>
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
                    Mã thương hiệu
                </th>
                <th width="450">
                    Tên thương hiệu
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
            <asp:Repeater ID="rptBrands" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:ImageButton OnCommand="btnAction_Command" CommandName="edit" CommandArgument='<%# Eval("BrandCd") %>'
                                AlternateText="Cập nhật" ToolTip='Cập nhật' ImageUrl="/pages/resources/images/icons/edit.png"
                                ID="btnEdit" runat="server" />
                        </td>
                        <td>
                            <%# Eval("BrandCd")%>
                        </td>
                        <td>
                            <%# Eval("BrandName")%>
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
        activeLink("#mnuBrands", "#lnkBrands");
    </script>
</asp:Content>
