<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="checkout.aspx.cs" Inherits="MiBo.pages.cln.checkout" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="main-container col2-right-layout">
        <div class="main">
            <div class="col-main">
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
                                                                <asp:TextBox class="input-text" ID="clientName" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="wide">
                                                    <label for="billing:street1" class="required">
                                                        <em>*</em>Địa chỉ</label>
                                                    <div class="input-box">
                                                       <asp:TextBox class="input-text" ID="clientAddress" runat="server"></asp:TextBox>
                                                    </div>
                                                </li>
                                                <li lang="fields">
                                                    <div class="field">
                                                        <label for="billing:telephone" class="required">
                                                            <em>*</em>Số điện thoại</label>
                                                        <div class="input-box">
                                                           <asp:TextBox class="input-text" ID="clientTell" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
      
                                                </li>
                                                <li class="no-display">
                                                    <input type="hidden" name="billing[save_in_address_book]" value="1"></li>
                                            </ul>
                                        </fieldset>
                                    </li>
                                    <li class="control">
                                    <asp:RadioButton class="radio" Text="Giao hàng đến địa chỉ này" ID="RadioButton1" GroupName="methodDelivery" runat="server" />
                                    <li class="control">
                                        <asp:RadioButton class="radio" Checked="true" Text="Giao hàng đến địa chỉ khác" ID="methodDelivery1" GroupName="methodDelivery" runat="server" />
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
                                                                <asp:TextBox class="input-text" ID="deliveryName" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </li>
                                                <li class="wide">
                                                    <label for="billing:street1" class="required">
                                                        <em>*</em>Địa chỉ nơi giao hàng</label>
                                                    <div class="input-box">
                                                        <asp:TextBox class="input-text" ID="deliveryAddress" runat="server"></asp:TextBox>
                                                    </div>
                                                </li>
                                                <li lang="fields">
                                                    <div class="field">
                                                        <label for="billing:telephone" class="required">
                                                            <em>*</em>Số điện thoại nơi giao hàng</label>
                                                        <div class="input-box">
                                                            <asp:TextBox class="input-text" ID="deliveryTell" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
      
                                                </li>
                                                <li lang="fields">
                                                    <div class="field">
                                                        <label for="billing:telephone">
                                                            <em>*</em>Ngày giao hàng mong muốn</label>
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
                                        <asp:RadioButton Checked="true" GroupName="rbPay" Text="Thanh toán tiền mặt khi nhận hàng" ID="pay1" runat="server" class="radio" />
                                    </li>
                                    <li class="control">
                                    <asp:RadioButton GroupName="rbPay" Text="Thẻ ATM đăng ký Internet Banking (Miễn phí thanh toán)" ID="pay2" runat="server" class="radio" />
                                    </li>
                                    <li class="control">
                                    <asp:RadioButton GroupName="rbPay" Text="Thanh toán bằng thẻ quốc Tế Visa, Master" ID="pay3" runat="server" class="radio" />
                                    </li>
                                    <li class="control">
                                    <asp:RadioButton GroupName="rbPay" Text="Chuyển khoản ngân hàng (Quý khách tự thanh toán chi phí chuyển khoản)" ID="pay4" runat="server" class="radio" />
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
                                                                <em>*</em>Ghi chú</label>
                                                            <div class="input-box">
                                                                <asp:TextBox class="input-text" TextMode="MultiLine" ID="note" 
                                                                    runat="server" Height="75px" Width="549px"></asp:TextBox>
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
        <asp:Button ID="Button1" class="button" runat="server" Text="Xác nhận" onclick="Button1_Click" />
        </div>
                            
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
