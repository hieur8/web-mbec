<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/administer.Master"
    AutoEventWireup="true" CodeBehind="param-list.aspx.cs" Inherits="MiBo.pages.administer.param_list" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <title>Danh sách tham số</title>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.list-data').dataTable({
                "bJQueryUI": true,
                "bLengthChange": false,
                "aaSorting": [],
                "sScrollX": "100%",
                "sScrollXInner": "1230",
                "bScrollCollapse": true,
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="content-box-header">
        <h3>
            Danh sách tham số
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
                <th width="120">
                    Mã tham số
                </th>
                <th width="240">
                    Tên tham số
                </th>
                <th width="180">
                    Giá trị
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
            <asp:Repeater ID="rptParams" runat="server">
                <ItemTemplate>
                    <tr ctrl="row">
                        <td>
                            <asp:CheckBox ctrl="edit" ID="chkEdit" runat="server" />
                            <asp:HiddenField ID="hidParamCd" Value='<%# Eval("ParamCd") %>' runat="server" />
                            <asp:HiddenField ID="hidParamType" Value='<%# Eval("ParamType") %>' runat="server" />
                        </td>
                        <td>
                            <%# Eval("ParamCd")%>
                        </td>
                        <td>
                            <%# Eval("ParamName")%>
                        </td>
                        <td>
                            <asp:TextBox ctrl="data" Width="150" Text='<%# Eval("ParamValue")%>' value='<%# Eval("ParamValue")%>'
                                ID="txtParamValue" runat="server" CssClass="text-input" TextMode='<%# Equals(Eval("ParamType"),"Password")?TextBoxMode.Password:TextBoxMode.SingleLine %>'></asp:TextBox>
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
        activeLink("#mnuSystems", "#lnkParmas");
    </script>
</asp:Content>
