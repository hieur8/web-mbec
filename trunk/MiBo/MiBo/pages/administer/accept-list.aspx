<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master"
    AutoEventWireup="true" CodeBehind="accept-list.aspx.cs" Inherits="MiBo.pages.administer.accept_list" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <title>Danh sách đơn hàng</title>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.list-data').dataTable({
                "bJQueryUI": true,
                "bLengthChange": false,
                "aaSorting": [],
                "sScrollX": "100%",
                "sScrollXInner": "2160",
                "bScrollCollapse": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Danh sách đơn hàng
        </h3>
        <div class="clear">
        </div>
    </div>
    <div class="content-box-content">
        <fieldset>
            <table>
                <tr>
                    <td width="120">
                        <span class="label">Ngày đặt</span>
                    </td>
                    <td width="300">
                        <asp:TextBox Width="100" ID="txtAcceptDataStart" runat="server" CssClass="input-search text-input"></asp:TextBox>
                        <span class="label">~</span>
                        <asp:TextBox Width="100" ID="txtAcceptDataEnd" runat="server" CssClass="input-search text-input"></asp:TextBox>
                    </td>
                    <td width="90">
                        <span class="label">Ngày giao</span>
                    </td>
                    <td>
                        <asp:TextBox Width="100" ID="txtDeliveryDataStart" runat="server" CssClass="input-search text-input"></asp:TextBox>
                        <span class="label">~</span>
                        <asp:TextBox Width="100" ID="txtDeliveryDataEnd" runat="server" CssClass="input-search text-input"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td width="120">
                        <span class="label">Mã hóa đơn</span>
                    </td>
                    <td width="300">
                        <asp:TextBox Width="100" ID="txtSlipNoStart" runat="server" CssClass="input-search text-input"></asp:TextBox>
                        <span class="label">~</span>
                        <asp:TextBox Width="100" ID="txtSlipNoEnd" runat="server" CssClass="input-search text-input"></asp:TextBox>
                    </td>
                    <td width="90">
                        <span class="label">Trạng thái</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSlipStatus" runat="server" CssClass="input-search text-input">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td width="120">
                        <span class="label">Mã khách hàng</span>
                    </td>
                    <td width="160">
                        <asp:TextBox Width="100" ID="txtClientCd" runat="server" CssClass="input-search text-input"></asp:TextBox>
                    </td>
                    <td width="120">
                        <span class="label">Tên khách hàng</span>
                    </td>
                    <td>
                        <asp:TextBox Width="200" ID="txtClientName" runat="server" CssClass="input-search text-input"></asp:TextBox>
                    </td>
                </tr>
            </table>
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
                <th width="150">
                    Mã hóa đơn
                </th>
                <th width="150">
                    Trạng thái
                </th>
                <th width="150">
                    Ngày đặt
                </th>
                <th width="150">
                    Ngày giao
                </th>
                <th width="180">
                    Mã khách hàng
                </th>
                <th width="480">
                    Tên khách hàng
                </th>
                <th width="200">
                    PT thanh toán
                </th>
                <th width="500">
                    Ghi chú
                </th>
                <th width="150">
                    Ngày cập nhật
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptAccepts" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hidAcceptSlipNo" runat="server" Value='<%# Eval("AcceptSlipNo") %>' />
                            <asp:ImageButton OnCommand="btnAction_Command" CommandName="edit" CommandArgument='<%# Eval("AcceptSlipNo") %>'
                                AlternateText="Cập nhật" ToolTip='Cập nhật' ImageUrl="/pages/resources/images/icons/edit.png"
                                ID="btnEdit" runat="server" />
                        </td>
                        <td>
                            <%# Eval("AcceptSlipNo")%>
                        </td>
                        <td>
                            <asp:DropDownList DataSource='<%# Eval("ListSlipStatus") %>' SelectedValue='<%# Bind("SlipStatus") %>'
                                DataValueField="Value" DataTextField="Text" ID="ddlSlipStatus" runat="server"
                                CssClass="input-search text-input">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <%# Eval("AcceptDate")%>
                        </td>
                        <td>
                            <%# Eval("DeliveryDate")%>
                        </td>
                        <td>
                            <%# Eval("ClientCd")%>
                        </td>
                        <td>
                            <%# Eval("ClientName")%>
                        </td>
                        <td>
                            <%# Eval("PaymentMethodsName")%>
                        </td>
                        <td>
                            <%# Eval("Notes")%>
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
        activeLink("#mnuAccepts", "#lnkAccepts");
    </script>
</asp:Content>
