<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master" AutoEventWireup="true" CodeBehind="offer-item-list.aspx.cs" Inherits="MiBo.pages.administer.offer_item_list" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <title>Danh sách sản phẩm tặng</title>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.list-data').dataTable({
                "bJQueryUI": true,
                "bLengthChange": false,
                "aaSorting": [],
                "sScrollX": "100%",
                "sScrollXInner": "880",
                "bScrollCollapse": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Danh sách sản phẩm tặng
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
                    Mã khuyến mãi
                </th>
                <th width="180">
                    Mã sản phẩm
                </th>
                <th width="180">
                    Số lượng
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
            <asp:Repeater ID="rptOfferItems" runat="server">
                <ItemTemplate>
                    <tr ctrl="row">
                        <td>
                            <asp:CheckBox ctrl="edit" ID="chkEdit" runat="server" />
                            <asp:HiddenField ID="hidOfferCd" Value='<%# Eval("OfferCd") %>' runat="server" />
                            <asp:HiddenField ID="hidDetailNo" Value='<%# Eval("DetailNo") %>' runat="server" />
                        </td>
                        <td>
                            <%# Eval("OfferCd")%>
                        </td>
                        <td>
                            <asp:TextBox ctrl="data" Width="120" Text='<%# Eval("OfferItemCd")%>' ID="txtOfferItemCd"
                                runat="server" CssClass="text-input"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ctrl="data" Width="120" Text='<%# Eval("OfferItemQtty")%>' ID="txtOfferItemQtty"
                                runat="server" CssClass="text-input"></asp:TextBox>
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
        <asp:HiddenField ID="hidOfferCd" runat="server" />
        <asp:LinkButton ID="btnAdd" runat="server" CssClass="button" OnCommand="btnAdd_Command"
            CausesValidation="false">Thêm sản phẩm tặng</asp:LinkButton>
        <asp:LinkButton ID="btnList" runat="server" CssClass="button" OnCommand="btnList_Command"
            CausesValidation="false">Danh sách sản phẩm tặng</asp:LinkButton>
    </p>
    <script type="text/javascript">
        activeLink("#mnuOffers", "#lnkOffers");
    </script>
</asp:Content>
