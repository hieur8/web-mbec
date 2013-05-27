<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master" AutoEventWireup="true" CodeBehind="banner-list.aspx.cs" Inherits="MiBo.pages.administer.banner_list" %>
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
                "sScrollXInner": "1360",
                "bScrollCollapse": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Danh sách banner
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
                <th width="180">
                    Mã banner
                </th>
                <th width="480">
                    Tên banner
                </th>
                <th width="100">
                    Thứ tự
                </th>
                <th width="180">
                    Nhóm khuyến mãi
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
            <asp:Repeater ID="rptBanners" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:ImageButton OnCommand="btnAction_Command" CommandName="edit" CommandArgument='<%# Eval("BannerCd") %>'
                                AlternateText="Cập nhật" ToolTip='Cập nhật' ImageUrl="/pages/resources/images/icons/edit.png"
                                ID="btnEdit" runat="server" />
                        </td>
                        <td>
                            <%# Eval("BannerCd") %>
                        </td>
                        <td>
                            <%# Eval("BannerName")%>
                        </td>
                        <td>
                            <%# Eval("SortKey")%>
                        </td>
                        <td>
                            <%# Eval("OfferGroupCd")%>
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
        activeLink("#mnuBanners", "#lnkBanners");
    </script>
</asp:Content>
