<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true" CodeBehind="confirm-checkout.aspx.cs" Inherits="MiBo.pages.cln.confirm_checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
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
                                <B><asp:Label ID="email" runat="server"></asp:Label></B>
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
                                                            <B><asp:Label ID="clientName" runat="server"></asp:Label></B>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="wide">
                                                    <label for="billing:street1" class="required">
                                                        <em>*</em>Địa chỉ</label>
                                                    <div class="input-box">
                                                    <B><asp:Label ID="clientAddress" runat="server"></asp:Label></B>
                                                    
                                                    </div>
                                                </li>
                                                <li>
                                                    <label for="fields" class="required">
                                                        <em>*</em>Tỉnh thành</label>
                                                    <div class="input-box">
                                                        <asp:DropDownList ID="DropDownList1" DataValueField="Code" DataTextField="Name" 
                                                            runat="server" Enabled="False">
                                                        </asp:DropDownList>
                                                    </div>
                                                </li>
                                                <li lang="fields">
                                                    <div class="field">
                                                        <label for="billing:telephone" class="required">
                                                            <em>*</em>Số điện thoại</label>
                                                        <div class="input-box">
                                                        <B><asp:Label ID="clientTell" runat="server"></asp:Label></B>
                                                          
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
                                                            <B><asp:Label ID="deliveryName" runat="server"></asp:Label></B>
                                                             
                                                            </div>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="wide">
                                                    <label for="billing:street1" class="required">
                                                        <em>*</em>Địa chỉ nơi giao hàng</label>
                                                    <div class="input-box">
                                                    <B><asp:Label ID="deliveryAddress" runat="server"></asp:Label></B>
                                                    </div>
                                                </li>
                                                <li>
                                                    <label for="fields" class="required">
                                                        <em>*</em>Tỉnh thành</label>
                                                    <div class="input-box">
                                                        <asp:DropDownList ID="DropDownList2" DataValueField="Code" DataTextField="Name" 
                                                            runat="server" Enabled="False">
                                                        </asp:DropDownList>
                                                    </div>
                                                </li>
                                                <li lang="fields">
                                                    <div class="field">
                                                        <label for="billing:telephone" class="required">
                                                            <em>*</em>Số điện thoại nơi giao hàng</label>
                                                        <div class="input-box">
                                                        <B><asp:Label ID="deliveryTell" runat="server"></asp:Label></B>
                                                        </div>
                                                    </div>
                                                </li>
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
                                                                    Width="549px" Enabled="False"></asp:TextBox>
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
                            <a href="#" onclick="JavaScript:window.history.back(1);return false;" class="btn btn-brown" ><span>Chỉnh sửa</span></a>
                                <asp:LinkButton ID="Button1" Width="120" runat="server" class="btn btn-blue" onclick="Button1_Click"
                                    ><span>Xác nhận</span></asp:LinkButton>
                            </div>
                        </div>
                    </li>
                </ol>
            </div>
            <div class="col-right sidebar">
                <div id="checkout-progress-wrapper">
                    <div class="block block-progress">
                        <div class="block-title">
                            <strong><span>Đơn hàng</span></strong>
                        </div>
                        <div class="block-content">
                            <dl>
                                <dt>Tổng tiền:<asp:Label ForeColor="Red" ID="Label1" runat="server" Text="0"></asp:Label></dt>
                                <dt>Phí giao hàng:<asp:Label ForeColor="Red" ID="Label2" runat="server" Text="Miễn phí"></asp:Label></dt>
                                <dt>Tổng cộng:<asp:Label ForeColor="Red" ID="Label3" runat="server" Text="0"></asp:Label></dt>
                            </dl>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
