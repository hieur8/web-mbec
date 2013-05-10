<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master" AutoEventWireup="true" CodeBehind="offer-item-entry.aspx.cs" Inherits="MiBo.pages.administer.offer_item_entry" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <title>Thêm sản phẩm tăng</title>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Thêm sản phẩm tăng</h3>
        <ul class="content-box-tabs">
            <li><a href="#tabInfo" class="default-tab">Sản phẩm tăng</a></li>
        </ul>
        <div class="clear">
        </div>
    </div>
    <div class="content-box-content">
        <asp:FormView ID="fvwOfferItemDatails" runat="server" RenderOuterTable="false">
            <ItemTemplate>
                <div class="tab-content default-tab" id="tabInfo">
                    <fieldset>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Mã khuyến mãi</span>
                                </td>
                                <td width="180">
                                    <asp:HiddenField ID="hidOfferCd" Value='<%# Eval("OfferCd") %>' runat="server" />
                                    <asp:TextBox Width="100" Enabled="false" Text='<%# Eval("OfferCd") %>' ID="txtOfferCd" runat="server" CssClass="text-input"></asp:TextBox>
                                </td>
                                <td width="120">
                                    <span class="label">Mã sản phẩm</span>
                                </td>
                                <td>
                                    <asp:TextBox Width="100" ID="txtOfferItemCd" runat="server" CssClass="text-input"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Số lượng</span>
                                </td>
                                <td width="180">
                                    <asp:TextBox Width="100" ID="txtOfferItemQtty" Text="0" runat="server" CssClass="text-input"></asp:TextBox>
                                </td>
                                <td width="120">
                                    <span class="label">Dữ liệu</span>
                                </td>
                                <td >
                                    <asp:DropDownList DataSource='<%# Eval("ListDeleteFlag") %>' SelectedValue='<%# Bind("DeleteFlag") %>'
                                        DataValueField="Code" DataTextField="Name" ID="ddlDeleteFlag" runat="server"
                                        CssClass="input-search text-input">
                                    </asp:DropDownList>
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
        activeLink("#mnuOffers", "#lnkOffers");
    </script>
</asp:Content>
