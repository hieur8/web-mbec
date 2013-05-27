<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master"
    AutoEventWireup="true" CodeBehind="offer-list.aspx.cs" Inherits="MiBo.pages.administer.offer_list" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <title>Danh khuyến mãi</title>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.list-data').dataTable({
                "bJQueryUI": true,
                "bLengthChange": false,
                "aaSorting": [],
                "sScrollX": "100%",
                "sScrollXInner": "2040",
                "bScrollCollapse": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Danh khuyến mãi
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
                    <td width="90">
                        <span class="label">Loại</span>
                    </td>
                    <td width="160">
                        <asp:DropDownList ID="ddlOfferDiv" runat="server" CssClass="input-search text-input"
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
                <th width="60">
                    &nbsp;
                </th>
                <th width="180">
                    Mã khuyến mãi
                </th>
                <th width="220">
                    Loại khuyến mãi
                </th>
                <th width="180">
                    Nhóm khuyến mãi
                </th>
                <th width="180">
                    Mã sản phẩm
                </th>
                <th width="180">
                    Ngày bắt đầu
                </th>
                <th width="180">
                    Ngày kết thúc
                </th>
                <th width="120">
                    Giảm (%)
                </th>
                <th width="400">
                    Ghi chú
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
            <asp:Repeater ID="rptOffers" runat="server">
                <ItemTemplate>
                    <tr ctrl="row">
                        <td>
                            <asp:CheckBox ctrl="edit" ID="chkEdit" runat="server" />
                            <asp:HiddenField ID="hidOfferCd" Value='<%# Eval("OfferCd") %>' runat="server" />
                        </td>
                        <td>
                            <asp:ImageButton OnCommand="btnAction_Command" CommandName="list" CommandArgument='<%# Eval("OfferCd") %>'
                                AlternateText="Danh sách sản phẩm" ToolTip='Danh sách sản phẩm' ImageUrl="/pages/resources/images/icons/view.png"
                                ID="btnList" runat="server" Visible='<%# Equals("02", Eval("OfferDiv")) %>' />
                            <asp:ImageButton OnCommand="btnAction_Command" CommandName="add" CommandArgument='<%# Eval("OfferCd") %>'
                                AlternateText="Thêm sản phẩm" ToolTip='Thêm sản phẩm' ImageUrl="/pages/resources/images/icons/add.png"
                                ID="btnAdd" runat="server" Visible='<%# Equals("02", Eval("OfferDiv")) %>' />
                        </td>
                        <td>
                            <%# Eval("OfferCd")%>
                        </td>
                        <td>
                            <%# Eval("OfferDivName")%>
                        </td>
                        <td>
                            <asp:TextBox ctrl="data" Width="80" Text='<%# Eval("OfferGroupCd")%>' ID="txtOfferGroupCd" runat="server"
                                CssClass="text-input"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ctrl="data" Width="80" Text='<%# Eval("ItemCd")%>' ID="txtItemCd" runat="server"
                                CssClass="text-input"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ctrl="data" Width="80" Text='<%# Eval("StartDate")%>' ID="txtStartDate"
                                runat="server" CssClass="text-input"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ctrl="data" Width="80" Text='<%# Eval("EndDate")%>' ID="txtEndDate"
                                runat="server" CssClass="text-input"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ctrl="data" Width="80" Text='<%# Eval("Percent")%>' ID="txtPercent"
                                runat="server" CssClass="text-input"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ctrl="data" Width="360" Text='<%# Eval("Notes")%>' ID="txtNotes" runat="server"
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
        activeLink("#mnuOffers", "#lnkOffers");
    </script>
</asp:Content>
