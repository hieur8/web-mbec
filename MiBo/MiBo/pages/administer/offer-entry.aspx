<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master"
    AutoEventWireup="true" CodeBehind="offer-entry.aspx.cs" Inherits="MiBo.pages.administer.offer_entry" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <title>Thêm khuyến mãi</title>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Thêm khuyến mãi</h3>
        <ul class="content-box-tabs">
            <li><a href="#tabInfo" class="default-tab">Khuyến mãi</a></li>
        </ul>
        <div class="clear">
        </div>
    </div>
    <div class="content-box-content">
        <asp:FormView ID="fvwGroupDatails" runat="server" RenderOuterTable="false">
            <ItemTemplate>
                <div class="tab-content default-tab" id="tabInfo">
                    <fieldset>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Mã khuyến mãi</span>
                                </td>
                                <td width="180">
                                    <asp:TextBox Width="100" ID="txtOfferCd" runat="server" CssClass="text-input" Enabled="false" Text='<%# Eval("OfferCd") %>'></asp:TextBox>
                                </td>
                                <td width="120">
                                    <span class="label">Mã sản phẩm</span>
                                </td>
                                <td>
                                    <asp:TextBox Width="100" ID="txtItemCd" runat="server" CssClass="text-input"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Ngày bắt đầu</span>
                                </td>
                                <td width="180">
                                    <asp:TextBox Width="100" ID="txtStartDate" runat="server" CssClass="text-input" Text='<%# Eval("StartDate") %>'></asp:TextBox>
                                </td>
                                <td width="120">
                                    <span class="label">Ngày kết thúc</span>
                                </td>
                                <td>
                                    <asp:TextBox Width="100" ID="txtEndDate" runat="server" CssClass="text-input" Text='<%# Eval("EndDate") %>'></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Giảm (%)</span>
                                </td>
                                <td width="180">
                                    <asp:TextBox Width="100" ID="txtPercent" runat="server" CssClass="text-input small-input"></asp:TextBox>
                                </td>
                                <td width="120">
                                    <span class="label">Loại</span>
                                </td>
                                <td>
                                    <asp:DropDownList DataSource='<%# Eval("ListOfferDiv") %>' SelectedValue='<%# Bind("OfferDiv") %>'
                                        DataValueField="Code" DataTextField="Name" ID="ddlOfferDiv" runat="server"
                                        CssClass="input-search text-input">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <label>
                                        Ghi chú</label>
                                    <asp:TextBox ID="txtNotes" runat="server"
                                        TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <div class="clear">
                        </div>
                        <p>
                            <asp:LinkButton ID="btnSave" runat="server" CssClass="button" OnCommand="btnSave_Command">
                            Lưu</asp:LinkButton>
                            &nbsp;
                            <asp:LinkButton ID="btnList" runat="server" CssClass="button" OnCommand="btnList_Command"
                                CausesValidation="false">Danh sách</asp:LinkButton>
                        </p>
                    </fieldset>
                </div>
            </ItemTemplate>
        </asp:FormView>
    </div>
    <script type="text/javascript">
        activeLink("#mnuOffers", "#lnkOfferEntry");
    </script>
</asp:Content>
