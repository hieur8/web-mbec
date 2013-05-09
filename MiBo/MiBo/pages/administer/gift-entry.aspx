<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master" AutoEventWireup="true" CodeBehind="gift-entry.aspx.cs" Inherits="MiBo.pages.administer.gift_entry" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <title>Tạo thẻ</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<div class="content-box-header">
        <h3>
            Tạo thẻ</h3>
        <ul class="content-box-tabs">
            <li><a href="#tabInfo" class="default-tab">Thẻ</a></li>
        </ul>
        <div class="clear">
        </div>
    </div>
    <div class="content-box-content">
        <asp:FormView ID="fvwGiftDatails" runat="server" RenderOuterTable="false">
            <ItemTemplate>
                <div class="tab-content default-tab" id="tabInfo">
                    <fieldset>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Mã thẻ</span>
                                </td>
                                <td width="180">
                                    <asp:TextBox Width="100" ID="txtGiftCd" runat="server" CssClass="text-input" Text='<%# Eval("GiftCd") %>'><></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="btnGen" runat="server" CssClass="button" OnCommand="btnGen_Command">Gen</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Số tiền</span>
                                </td>
                                <td>
                                    <asp:TextBox Width="100" ID="txtPrice" runat="server" CssClass="text-input" Text="0"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Ngày hữu hiệu</span>
                                </td>
                                <td>
                                    <asp:TextBox Width="100" ID="txtStartDate" runat="server" CssClass="input-search text-input" Text='<%# Eval("StartDate") %>'></asp:TextBox>
                                    <span class="label">~</span>
                                    <asp:TextBox Width="100" ID="txtEndDate" runat="server" CssClass="input-search text-input" Text='<%# Eval("EndDate") %>'></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <label>
                                        Ghi chú</label>
                                    <asp:TextBox Text='' ID="txtNotes" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
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
        activeLink("#mnuGifts", "#lnkGiftEntry");
    </script>
</asp:Content>
