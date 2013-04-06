<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="checkout.aspx.cs" Inherits="MiBo.pages.cln.checkout" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#frmMain").validate(
        {
            messages: {
                ctl00$main$email: "Hãy nhập địa chỉ email",
                ctl00$main$pass: "Hãy nhập mật khẩu",
                ctl00$main$clientName: "Hãy nhập họ và tên người mua hàng",
                ctl00$main$clientAddress: "Hãy nhập địa chỉ nơi mua hàng",
                ctl00$main$clientTell: "Hãy nhập số điện thoại nơi mua hàng",
                ctl00$main$deliveryName: "Hãy nhập họ và tên người nhận hàng",
                ctl00$main$deliveryAddress: "Hãy nhập địa chỉ nơi nhận hàng",
                ctl00$main$deliveryTell: "Hãy nhập số điện thoại người nhận hàng"

            }
        });
        $('#<%=passConfirm.ClientID%>').attr('equalTo', '#<%=pass.ClientID%>');
        });


        function makeDelivery() {
            $("#main_deliveryName").val($("#main_clientName").val());
            $("#main_deliveryAddress").val($("#main_clientAddress").val());
            $("#main_deliveryTell").val($("#main_clientTell").val());
        }
        function clearDelivery() {
            $("#main_deliveryName").val('');
            $("#main_deliveryAddress").val('');
            $("#main_deliveryTell").val('');
        }
    </script>
    <div class="main-container col2-right-layout">
        <div class="main">
            <div class="col-main">
            <% if (Session["payMethod"].ToString().Equals("0"))
               { %>
            <div class="fieldset">
                    <h2 class="legend">
                        Thông tin tài khoản</h2>
                    <p>
                        <%
                   if (Session["error"] != null)
                   {
                        %>
                        <ul class="messages">
                            <li class="error-msg">
                                <ul>
                                    <li>
                                        <%=Session["error"].ToString()%></li></ul>
                            </li>
                        </ul>
                        <% 
                       Session["error"] = null;
                   } %>
                    </p>
                    <ul class="form-list">
                        <li>
                            <label for="email_address" class="required">
                                <em>*</em>Địa chỉ email</label>
                            <div class="input-box">
                                <asp:TextBox ID="email" class="input-text required email" runat="server"></asp:TextBox>
                            </div>
                        </li>
                        <li class="fields">
                            <div class="field">
                                <label for="password" class="required">
                                    <em>*</em>Mật khẩu</label>
                                <div class="input-box">
                                    <asp:TextBox ID="pass" TextMode="Password" minlength="6" class="input-text required"
                                        runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="field">
                                <label for="confirmation" class="required">
                                    <em>*</em>Nhập lại mật khẩu</label>
                                <div class="input-box">
                                    <asp:TextBox ID="passConfirm" TextMode="Password" class="input-text" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
                <% } %>
                <div class="page-title">
                    <h1>
                        Thanh toán</h1>
                </div>
                <ol class="opc" id="checkoutSteps">
                    <li id="opc-billing" class="section allow active">
                        <div class="step-title">
                            <span class="number">1</span>
                            <h2>
                                Thông tin đơn hàng</h2>
                            <a href="#">Edit</a>
                        </div>
                        <div id="checkout-step-billing" class="step a-item" style="">
                            <fieldset>
                                <ul class="form-list">
                                    <li id="billing-new-address-form">
                                        <fieldset>
                                            <input type="hidden" name="billing[address_id]" value="1120" id="billing:address_id">
                                            <ul>
                                                <li class="fields">
                                                    <div class="customer-name">
                                                        <div class="field name-firstname">
                                                            <label for="billing:firstname" class="required">
                                                                <em>*</em>Họ và tên</label>
                                                            <div class="input-box">
                                                                <asp:TextBox class="input-text required" minlength="2" ID="clientName" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="wide">
                                                    <label for="billing:street1" class="required">
                                                        <em>*</em>Địa chỉ</label>
                                                    <div class="input-box">
                                                        <asp:TextBox class="input-text required" ID="clientAddress" runat="server"></asp:TextBox>
                                                    </div>
                                                </li>
                                                <li lang="fields">
                                                    <div class="field">
                                                        <label for="billing:telephone" class="required">
                                                            <em>*</em>Số điện thoại</label>
                                                        <div class="input-box">
                                                            <asp:TextBox class="input-text required" ID="clientTell" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="no-display">
                                                    <input type="hidden" name="billing[save_in_address_book]" value="1"></li>
                                            </ul>
                                        </fieldset>
                                    </li>
                                    <li class="control">
                                        <asp:RadioButton onclick="makeDelivery();" class="radio" Text="Giao hàng đến địa chỉ này"
                                            ID="RadioButton1" GroupName="methodDelivery" runat="server" />
                                    <li class="control">
                                        <asp:RadioButton onclick="clearDelivery();" class="radio" Checked="true" Text="Giao hàng đến địa chỉ khác"
                                            ID="methodDelivery1" GroupName="methodDelivery" runat="server" />
                                    </li>
                                </ul>
                            </fieldset>
                        </div>
                    </li>
                </ol>
                <ol class="opc" id="Ol2">
                    <li id="Li3" class="section allow active">
                        <div class="step-title">
                            <span class="number">2</span>
                            <h2>
                                Thông tin giao hàng</h2>
                            <a href="#">Edit</a>
                        </div>
                        <div id="Div3" class="step a-item" style="">
                            <fieldset>
                                <ul class="form-list">
                                    <li id="Li4">
                                        <fieldset>
                                            <input type="hidden" name="billing[address_id]" value="1120" id="Hidden2">
                                            <ul>
                                                <li class="fields">
                                                    <div class="customer-name">
                                                        <div class="field name-firstname">
                                                            <label for="billing:firstname" class="required">
                                                                <em>*</em>Họ và tên người nhận</label>
                                                            <div class="input-box">
                                                                <asp:TextBox class="input-text required" ID="deliveryName" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="wide">
                                                    <label for="billing:street1" class="required">
                                                        <em>*</em>Địa chỉ nơi giao hàng</label>
                                                    <div class="input-box">
                                                        <asp:TextBox class="input-text required" ID="deliveryAddress" runat="server"></asp:TextBox>
                                                    </div>
                                                </li>
                                                <li lang="fields">
                                                    <div class="field">
                                                        <label for="billing:telephone" class="required">
                                                            <em>*</em>Số điện thoại nơi giao hàng</label>
                                                        <div class="input-box">
                                                            <asp:TextBox class="input-text required" ID="deliveryTell" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li lang="fields">
                                                    <div class="field">
                                                        <label for="billing:telephone">
                                                            Ngày giao hàng mong muốn</label>
                                                        <div class="input-box">
                                                            <asp:TextBox class="input-text" ID="deliveryDate" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="no-display">
                                                    <input type="hidden" name="billing[save_in_address_book]" value="1"></li>
                                            </ul>
                                        </fieldset>
                                    </li>
                                </ul>
                            </fieldset>
                        </div>
                    </li>
                </ol>
                <ol class="opc" id="Ol1">
                    <li id="Li1" class="section allow active">
                        <div class="step-title">
                            <span class="number">3</span>
                            <h2>
                                Phương thức thanh toán</h2>
                            <a href="#">Edit</a>
                        </div>
                        <div id="Div1" class="step a-item" style="">
                            <input type="hidden" name="billing[save_in_address_book]" value="1">
                            <input type="hidden" name="billing[address_id]" value="1120" id="Hidden1">
                            <fieldset>
                                <ul class="form-list">
                                    <li class="control">
                                        <asp:RadioButton Checked="true" GroupName="rbPay" Text="Thanh toán tiền mặt khi nhận hàng"
                                            ID="pay1" runat="server" class="radio" />
                                    </li>
                                    <li class="control">
                                        <asp:RadioButton GroupName="rbPay" Enabled="false" Text="Thẻ ATM đăng ký Internet Banking (Miễn phí thanh toán)"
                                            ID="pay2" runat="server" class="radio" />
                                    </li>
                                    <li class="control">
                                        <asp:RadioButton GroupName="rbPay" Enabled="false" Text="Thanh toán bằng thẻ quốc Tế Visa, Master"
                                            ID="pay3" runat="server" class="radio" />
                                    </li>
                                    <li class="control">
                                        <asp:RadioButton GroupName="rbPay" Enabled="false" Text="Chuyển khoản ngân hàng (Quý khách tự thanh toán chi phí chuyển khoản)"
                                            ID="pay4" runat="server" class="radio" />
                                    </li>
                                </ul>
                            </fieldset>
                        </div>
                    </li>
                </ol>
                <ol class="opc" id="Ol3">
                    <li id="Li2" class="section allow active">
                        <div class="step-title">
                            <span class="number">4</span>
                            <h2>
                                Xác nhận</h2>
                            <a href="#">Edit</a>
                        </div>
                        <div id="Div2" class="step a-item" style="">
                            <fieldset>
                                <ul class="form-list">
                                    <li id="Li5">
                                        <fieldset>
                                            <input type="hidden" name="billing[address_id]" value="1120" id="Hidden3">
                                            <ul>
                                                <li class="fields">
                                                    <div class="customer-name">
                                                        <div class="field name-firstname">
                                                            <label for="billing:firstname" class="required">
                                                                Ghi chú</label>
                                                            <div class="input-box">
                                                                <asp:TextBox class="input-text" TextMode="MultiLine" ID="note" runat="server" Height="75px"
                                                                    Width="549px"></asp:TextBox>
                                                                <br />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </li>
                                            </ul>
                                        </fieldset>
                                    </li>
                                </ul>
                            </fieldset>
                            <div class="buttons-set" id="billing-buttons-container" style="">
                                <p class="required">* Bắt buộc nhập</p>
                                <asp:LinkButton ID="Button1" Width="120" runat="server" class="btn btn-blue" OnClientClick="return $('#frmMain').valid();" OnClick="Button1_Click"><span>Xác nhận</span></asp:LinkButton>
                            </div>
                            <asp:HiddenField ID="txtClientCd" runat="server" />
                        </div>
                    </li>
                </ol>
            </div>
            <div class="col-right sidebar">
                <div id="checkout-progress-wrapper">
                    <div class="block block-progress">
                        <div class="block-title">
                            <strong><span>Quá trình mua hàng</span></strong>
                        </div>
                        <div class="block-content">
                            <dl>
                                <dt>Thông tin đơn hàng</dt>
                                <dt>Thông tin giao hàng</dt>
                                <dt>Phương thức thanh toán</dt>
                                <dt>Xác nhận đơn hàng</dt>
                            </dl>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
