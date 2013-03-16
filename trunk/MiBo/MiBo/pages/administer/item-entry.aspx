<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master"
    ValidateRequest="false" AutoEventWireup="true" CodeBehind="item-entry.aspx.cs"
    Inherits="MiBo.pages.administer.item_entry" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <!-- TinyMCE -->
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <script type="text/javascript" src="/pages/resources/scripts/tiny_mce.js"></script>
    <script type="text/javascript">
        tinyMCE.init({
            // General options
            mode: "textareas",
            elements: "", //input id of textareas
            theme: "advanced",
            skin: "o2k7",
            plugins: "lists,pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,inlinepopups,autosave",

            // Theme options
            theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect",
            theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
            theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,advhr,|,print,|,ltr,rtl,|,fullscreen",
            theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,spellchecker,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,blockquote,pagebreak,|,insertfile,insertimage",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom",
            theme_advanced_resizing: true,

            // Example content CSS (should be your site CSS)
            content_css: "/pages/resources/styles/content.css",

            // Drop lists for image dialogs
            external_image_list_url: "/pages/resources/scripts/plugins/advimage/tiny-image-list.aspx",

            // Replace values for the template plugin
            template_replace_values: {
                username: "Some User",
                staffid: "991234"
            }
        });</script>
    <!-- /TinyMCE -->
    <!-- MyScript -->
    <script type="text/javascript">
        function getObjectById(id) {
            if (document.getElementById)
                var returnVar = document.getElementById(id);
            else if (document.all)
                var returnVar = document.all[id];
            else if (document.layers)
                var returnVar = document.layers[id];
            return returnVar;
        }
        function popitup(val) {
            var newwindow = window.open(val.href, 'uploadimage', 'directories=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=550,height=400');
            if (window.focus) { newwindow.focus() }
            return false;
        }
        function getaliastext(val) {
            var s = generateAlias(val);
            var hidItemSearchNameId = "#" + '<%= fvwItemDatails.FindControl("hidItemSearchName").ClientID %>'
            var txtItemSearchNameId = "#" + '<%= fvwItemDatails.FindControl("txtItemSearchName").ClientID %>'
            $(hidItemSearchNameId).val(s)
            $(txtItemSearchNameId).val(s);
        }
    </script>
    <title>Thêm/sửa sản phẩm</title>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Thêm/sửa sản phẩm</h3>
        <ul class="content-box-tabs">
            <li><a href="#tabInfo" class="default-tab">Sản phẩm</a></li>
        </ul>
        <div class="clear">
        </div>
    </div>
    <div class="content-box-content">
        <asp:FormView ID="fvwItemDatails" runat="server" RenderOuterTable="false">
            <ItemTemplate>
                <asp:HiddenField ID="hidStatus" Value='<%# Eval("Status") %>' runat="server" />
                <asp:HiddenField ID="hidImagePath" Value='<%# Eval("ImagePath") %>' runat="server" />
                <asp:HiddenField ID="hidItemSearchName" Value='<%# Eval("ItemSearchName") %>' runat="server" />
                <div class="tab-content default-tab" id="tabInfo">
                    <fieldset>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Mã sản phẩm</span>
                                </td>
                                <td width="160">
                                    <asp:TextBox Width="100" Text='<%# Eval("ItemCd") %>' Enabled='<%# Eval("Status") == "add" %>'
                                        ID="txtItemCd" runat="server" CssClass="text-input"></asp:TextBox>
                                </td>
                                <td width="120">
                                    <span class="label">Tên sản phẩm</span>
                                </td>
                                <td width="240">
                                    <asp:TextBox Width="200" Text='<%# Eval("ItemName") %>' ID="txtItemName" runat="server"
                                        CssClass="text-input" onchange="getaliastext(this.value)"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox Width="200" Text='<%# Eval("ItemSearchName") %>' ID="txtItemSearchName"
                                        runat="server" CssClass="text-input" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Loại sản phẩm</span>
                                </td>
                                <td width="160">
                                    <asp:DropDownList DataSource='<%# Eval("ListCategory") %>' SelectedValue='<%# Bind("CategoryCd") %>'
                                        DataValueField="Value" DataTextField="Text" ID="ddlCategory" runat="server" CssClass="input-search text-input">
                                    </asp:DropDownList>
                                </td>
                                <td width="120">
                                    <span class="label">Sản phẩm</span>
                                </td>
                                <td width="130">
                                    <asp:DropDownList DataSource='<%# Eval("ListItemDiv") %>' SelectedValue='<%# Bind("ItemDiv") %>'
                                        DataValueField="Value" DataTextField="Text" ID="ddlItemDiv" runat="server" CssClass="input-search text-input">
                                    </asp:DropDownList>
                                </td>
                                <td width="80">
                                    <span class="label">Đơn vị</span>
                                </td>
                                <td>
                                    <asp:DropDownList DataSource='<%# Eval("ListUnit") %>' SelectedValue='<%# Bind("UnitCd") %>'
                                        DataValueField="Value" DataTextField="Text" ID="ddlUnit" runat="server" CssClass="input-search text-input">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Độ tuổi</span>
                                </td>
                                <td width="160">
                                    <asp:DropDownList DataSource='<%# Eval("ListAge") %>' SelectedValue='<%# Bind("AgeCd") %>'
                                        DataValueField="Value" DataTextField="Text" ID="ddlAge" runat="server" CssClass="input-search text-input">
                                    </asp:DropDownList>
                                </td>
                                <td width="120">
                                    <span class="label">Giới tính</span>
                                </td>
                                <td>
                                    <asp:DropDownList DataSource='<%# Eval("ListGender") %>' SelectedValue='<%# Bind("GenderCd") %>'
                                        DataValueField="Value" DataTextField="Text" ID="ddlGender" runat="server" CssClass="input-search text-input">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Thương hiệu</span>
                                </td>
                                <td width="160">
                                    <asp:DropDownList DataSource='<%# Eval("ListBrand") %>' SelectedValue='<%# Bind("BrandCd") %>'
                                        DataValueField="Value" DataTextField="Text" ID="ddlBrand" runat="server" CssClass="input-search text-input">
                                    </asp:DropDownList>
                                </td>
                                <td width="120">
                                    <span class="label">Xuất xứ</span>
                                </td>
                                <td>
                                    <asp:DropDownList DataSource='<%# Eval("ListCountry") %>' SelectedValue='<%# Bind("CountryCd") %>'
                                        DataValueField="Value" DataTextField="Text" ID="ddlCountry" runat="server" CssClass="input-search text-input">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Giá mua</span>
                                </td>
                                <td width="160">
                                    <asp:TextBox Width="100" Text='<%# Eval("BuyingPrice") %>' ID="txtBuyingPrice" runat="server"
                                        CssClass="text-input"></asp:TextBox>
                                </td>
                                <td width="120">
                                    <span class="label">Giá bán</span>
                                </td>
                                <td>
                                    <asp:TextBox Width="100" Text='<%# Eval("SalesPrice") %>' ID="txtSalesPrice" runat="server"
                                        CssClass="text-input"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Thứ tự</span>
                                </td>
                                <td width="160">
                                    <asp:TextBox Width="80" Text='<%# Eval("SortKey") %>' ID="txtSortKey" runat="server"
                                        CssClass="text-input small-input"></asp:TextBox>
                                </td>
                                <td width="120">
                                    <span class="label">Dữ liệu</span>
                                </td>
                                <td width="80">
                                    <asp:DropDownList DataSource='<%# Eval("ListDeleteFlag") %>' SelectedValue='<%# Bind("DeleteFlag") %>'
                                        DataValueField="Value" DataTextField="Text" ID="ddlDeleteFlag" runat="server"
                                        CssClass="input-search text-input">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <span class="label"></span><a class="button" href='/pages/administer/upload-image.aspx?g=item&p=<%# Eval("ImagePath") %>'
                                        onclick="return popitup(this);">Upload hình</a>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <label>
                                        Mô tả</label>
                                    <asp:TextBox Text='<%# Eval("Notes") %>' ID="txtContents" runat="server" TextMode="MultiLine"></asp:TextBox>
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
        activeLink("#mnuItems", "#lnkItemEntry");
    </script>
</asp:Content>
