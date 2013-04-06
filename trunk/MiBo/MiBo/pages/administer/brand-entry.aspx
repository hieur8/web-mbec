<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master"
    ValidateRequest="false" AutoEventWireup="true" CodeBehind="brand-entry.aspx.cs"
    Inherits="MiBo.pages.administer.brand_entry" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <!-- TinyMCE -->
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <script type="text/javascript" src="/pages/resources/scripts/tiny_mce.js"></script>
    <script type="text/javascript">
        tinyMCE.init({
            // General options
            mode: "textareas",
            editor_selector: 'showEditer', //input id of textareas
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
        function popitup(val) {
            var newwindow = window.open(val.href, 'uploadimage', 'directories=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,scrollbars=no,resizable=yes,width=550,height=400');
            if (window.focus) { newwindow.focus() }
            return false;
        }
        function getaliastext(val) {
            var s = generateAlias(val);
            var hidBrandSearchNameId = "#" + '<%= fvwBrandDatails.FindControl("hidBrandSearchName").ClientID %>'
            var txtBrandSearchNameId = "#" + '<%= fvwBrandDatails.FindControl("txtBrandSearchName").ClientID %>'
            $(hidBrandSearchNameId).val(s)
            $(txtBrandSearchNameId).val(s);
        }
    </script>
    <title>Thêm/sửa thương hiệu</title>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Thêm/sửa thương hiệu</h3>
        <ul class="content-box-tabs">
            <li><a href="#tabInfo" class="default-tab">Thương hiệu</a></li>
        </ul>
        <div class="clear">
        </div>
    </div>
    <div class="content-box-content">
        <asp:FormView ID="fvwBrandDatails" runat="server" RenderOuterTable="false">
            <ItemTemplate>
                <asp:HiddenField ID="hidStatus" Value='<%# Eval("Status") %>' runat="server" />
                <asp:HiddenField ID="hidFileId" Value='<%# Eval("FileId") %>' runat="server" />
                <asp:HiddenField ID="hidBrandSearchName" Value='<%# Eval("BrandSearchName") %>' runat="server" />
                <div class="tab-content default-tab" id="tabInfo">
                    <fieldset>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Mã TH</span>
                                </td>
                                <td width="180">
                                    <asp:TextBox Width="100" Text='<%# Eval("BrandCd") %>' Enabled='<%# Eval("Status") == "add" %>'
                                        ID="txtBrandCd" runat="server" CssClass="text-input"></asp:TextBox>
                                </td>
                                <td width="120">
                                    <span class="label">Tên TH</span>
                                </td>
                                <td width="194">
                                    <asp:TextBox Width="180" Text='<%# Eval("BrandName") %>' ID="txtBrandName" runat="server"
                                        CssClass="text-input" onchange="getaliastext(this.value)"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox Width="180" Text='<%# Eval("BrandSearchName") %>' ID="txtBrandSearchName"
                                        runat="server" CssClass="text-input" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td width="120">
                                    <span class="label">Thứ tự</span>
                                </td>
                                <td width="180">
                                    <asp:TextBox Width="80" Text='<%# Eval("SortKey") %>' ID="txtSortKey" runat="server"
                                        CssClass="text-input small-input"></asp:TextBox>
                                </td>
                                <td width="120">
                                    <span class="label">Dữ liệu</span>
                                </td>
                                <td>
                                    <!-- width="80" -->
                                    <asp:DropDownList DataSource='<%# Eval("ListDeleteFlag") %>' SelectedValue='<%# Bind("DeleteFlag") %>'
                                        DataValueField="Code" DataTextField="Name" ID="ddlDeleteFlag" runat="server"
                                        CssClass="input-search text-input">
                                    </asp:DropDownList>
                                </td>
                                <!--
                                <td>
                                    <span class="label"></span><a class="button" href='/pages/administer/upload-image.aspx?fg=brands&fid=<%# Eval("FileId") %>'
                                        onclick="return popitup(this);">Upload hình</a>
                                </td>
                                -->
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <label>
                                        Mô tả</label>
                                    <asp:TextBox Text='<%# Eval("Notes") %>' CssClass="showEditer" ID="txtContents" runat="server"
                                        TextMode="MultiLine" Rows="5"></asp:TextBox>
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
        activeLink("#mnuBrands", "#lnkBrandEntry");
    </script>
</asp:Content>
