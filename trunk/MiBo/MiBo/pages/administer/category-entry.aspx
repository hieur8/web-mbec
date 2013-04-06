<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master"
    AutoEventWireup="true" CodeBehind="category-entry.aspx.cs" Inherits="MiBo.pages.administer.category_entry" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <!-- MyScript -->
    <script type="text/javascript">
        function getaliastext(val) {
            var s = generateAlias(val);
            var hidCategorySearchNameId = "#" + '<%= fvwCategoryDatails.FindControl("hidCategorySearchName").ClientID %>'
            var txtCategorySearchNameId = "#" + '<%= fvwCategoryDatails.FindControl("txtCategorySearchName").ClientID %>'
            $(hidCategorySearchNameId).val(s)
            $(txtCategorySearchNameId).val(s);
        }
    </script>
    <title>Thêm loại sản phẩm</title>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Thêm loại sản phẩm</h3>
        <ul class="content-box-tabs">
            <li><a href="#tabInfo" class="default-tab">Loại sản phẩm</a></li>
        </ul>
        <div class="clear">
        </div>
    </div>
    <div class="content-box-content">
        <asp:FormView ID="fvwCategoryDatails" runat="server" RenderOuterTable="false">
            <ItemTemplate>
                <div class="tab-content default-tab" id="tabInfo">
                    <fieldset>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Mã loại</span>
                                </td>
                                <td width="180">
                                    <asp:TextBox Width="100" ID="txtCategoryCd" runat="server" CssClass="text-input"></asp:TextBox>
                                </td>
                                <td width="120">
                                    <span class="label">Tên loại</span>
                                </td>
                                <td width="194">
                                    <asp:TextBox Width="180" ID="txtCategoryName" runat="server" CssClass="text-input"
                                    onchange="getaliastext(this.value)"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hidCategorySearchName" runat="server" />
                                    <asp:TextBox Width="180" ID="txtCategorySearchName" runat="server" CssClass="text-input" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="100">
                                    <span class="label">Chủng loại</span>
                                </td>
                                <td width="160">
                                    <asp:DropDownList DataSource='<%# Eval("ListCategoryDiv") %>' SelectedValue='<%# Bind("CategoryDiv") %>'
                                        DataValueField="Code" DataTextField="Name" ID="ddlCategoryDiv" runat="server" CssClass="input-search text-input">
                                    </asp:DropDownList>
                                </td>
                                <td width="100">
                                    <span class="label">Thứ tự</span>
                                </td>
                                <td width="140">
                                    <asp:TextBox Width="80" ID="txtSortKey" runat="server" CssClass="text-input small-input"></asp:TextBox>
                                </td>
                                <td width="100">
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
        activeLink("#mnuCategories", "#lnkCategoryEntry");
    </script>
</asp:Content>
