<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master" AutoEventWireup="true" CodeBehind="gift-list.aspx.cs" Inherits="MiBo.pages.administer.gift_list" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
<meta charset="utf-8">
    <title>Danh sách thẻ quà tặng</title>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.list-data').dataTable({
                "bJQueryUI": true,
                "bLengthChange": false,
                "aaSorting": [],
                "sScrollX": "100%",
                "sScrollXInner": "1070",
                "bScrollCollapse": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
<div class="content-box-header">
        <h3>
            Danh sách thẻ quà tặng
        </h3>
        <div class="clear">
        </div>
    </div>
    <div class="content-box-content">
        <fieldset>
            <table>
                <tr>
                    <td width="90">
                        <span class="label">Mã thẻ</span>
                    </td>
                    <td width="160">
                        <asp:TextBox Width="100" ID="txtGiftCd" runat="server" CssClass="input-search text-input"></asp:TextBox>
                    </td>
                    <td width="90">
                        <span class="label">Trạng thái</span>
                    </td>
                    <td width="160">
                        <asp:DropDownList ID="ddlGiftStatus" runat="server" CssClass="input-search text-input"
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
                <th width="120">
                    Mã thẻ
                </th>
                <th width="160">
                    Trạng thái
                </th>
                <th width="150">
                    Ngày bắt đầu
                </th>
                <th width="150">
                    Ngày kết thúc
                </th>
                <th width="150">
                    Số tiền
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
            <asp:Repeater ID="rptGifts" runat="server">
                <ItemTemplate>
                    <tr ctrl="row">
                        <td>
                            <asp:CheckBox ctrl="edit" ID="chkEdit" runat="server" />
                            <asp:HiddenField ID="hidGiftCd" Value='<%# Eval("GiftCd") %>' runat="server" />
                        </td>
                        <td>
                            <%# Eval("GiftCd")%>
                        </td>
                        <td>
                            <asp:DropDownList ctrl="data" DataSource='<%# Eval("ListGiftStatus") %>' SelectedValue='<%# Bind("GiftStatus") %>'
                                DataValueField="Code" DataTextField="Name" ID="ddlGiftStatus" runat="server"
                                CssClass="text-input">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%# Eval("StartDate")%>
                        </td>
                        <td>
                            <%# Eval("EndDate")%>
                        </td>
                        <td>
                            <%# Eval("Price")%>
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
        <tfoot>
            <tr>
                <td>
                    <asp:LinkButton OnClick="btnUpdate_Click" CssClass="button" ID="btnUpdate" runat="server">Cập nhật</asp:LinkButton>
                </td>
            </tr>
        </tfoot>
    </table>
    <script type="text/javascript">
        activeLink("#mnuGifts", "#lnkGifts");
    </script>
</asp:Content>
