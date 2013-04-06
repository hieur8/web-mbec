<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="shopping-cart.aspx.cs" Inherits="MiBo.pages.cln.shopping_cart" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="main-container col1-layout">
        <div class="main">
            <div class="col-main">
                <div class="cart">
                    <div class="page-title title-buttons">
                        <h1>
                            Giỏ hàng</h1>
                        <ul class="checkout-types">
                            <li>
                                <button type="button" title="Proceed to Checkout" class="button btn-checkout" onclick="window.location='checkout.aspx';">
                                    <span><span>Proceed to Checkout</span></span></button>
                            </li>
                        </ul>
                    </div>
                    <ul class="messages">
                        <% if (Session["info"] != null)
                           { %>
                        <li class="success-msg">
                            <ul>
                                <li>
                                    <%= Session["info"]%></li></ul>
                        </li>
                        <% } %>
                        <% if (Session["error"] != null)
                           { %>
                        <li class="error-msg">
                            <ul>
                                <li>
                                    <%= Session["error"] %></li></ul>
                        </li>
                        <% } %>
                        <% if (Session["warn"] != null)
                           { %>
                        <li class="notice-msg">
                            <ul>
                                <li>
                                    <%= Session["warn"]%></li></ul>
                        </li>
                        <% } %>
                    </ul>
                    <fieldset>
                        <table id="shopping-cart-table" class="data-table cart-table">
                            <colgroup>
                                <col>
                                <col>
                                <col width="1">
                                <col width="1">
                                <col width="1">
                                <col width="1">
                                <col width="1">
                            </colgroup>
                            <thead>
                                <tr class="first last">
                                    <th rowspan="1" class="a-center prod-image-cart-table">
                                        Hình ảnh
                                    </th>
                                    <th rowspan="1" class="a-center">
                                        <span class="nobr">Tên sản phẩm</span>
                                    </th>
                                    <th class="a-center" colspan="1">
                                        <span class="nobr">Giá</span>
                                    </th>
                                    <th rowspan="1" class="a-center">
                                        Số lượng
                                    </th>
                                    <th class="a-center" colspan="1">
                                        Thành tiền
                                    </th>
                                    <th rowspan="1" class="a-center">
                                        Xóa
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptCartItem" runat="server">
                                    <ItemTemplate>
                                        <tr class="first last odd">
                                            <td style="width: 70px;text-align:center">
                                                <a href='/item-details.aspx?pid=<%# Eval("ItemCd") %>' title='<%# Eval("ItemName")%>'>
                                                    <img src='/pages/media/images/items/small/<%# Eval("ItemImage") %>' width="60" height="60"
                                                        alt='<%# Eval("ItemName")%>'></a>
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hidItemCd" runat="server" Value='<%# Eval("ItemCd") %>' />
                                                <h2 class="product-name">
                                                    <a href='/item-details.aspx?pid=<%# Eval("ItemCd") %>'>
                                                        <%# Eval("ItemName")%></a>
                                                </h2>
                                            </td>
                                            <td class="a-right" style="width: 100px">
                                                <span class="cart-price"><span class="price">
                                                    <%# Eval("Price") %></span> </span>
                                            </td>
                                            <td class="a-center" style="width: 100px">
                                                <asp:TextBox Text='<%# Eval("Quantity") %>' MaxLength="3" Width="80px" CssClass="input-text qty"
                                                    ID="txtItemQtty" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="a-right" style="width: 100px">
                                                <span class="cart-price"><span class="price">
                                                    <%# Eval("Amount") %></span> </span>
                                            </td>
                                            <td class="a-center padding-part-removebutton last" style="width: 10px">
                                                <asp:LinkButton OnCommand="lnkDelete_Command" CommandArgument='<%# Eval("ItemCd") %>'
                                                    ID="lnkDelete" runat="server" CssClass="btn-remove2">Xóa</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>
                                <tr class="first last">
                                    <td colspan="6" class="last a-right">
                                        <asp:LinkButton ID="LinkButtonCon" class="btn btn-blue f-left" runat="server" OnClick="LinkButtonCon_Click"><span>Tiếp tục mua hàng</span></asp:LinkButton>
                                        <asp:LinkButton ID="btnUpdate" OnClick="btnUpdate_Click" class="btn btn-blue" runat="server"><span>Cập nhật giỏ hàng</span></asp:LinkButton>
                                    </td>
                                </tr>
                            </tfoot>
                        </table>
                    </fieldset>
                    <div class="cart-collaterals">
                        <div class="col2-set">
                            <div class="col-1">
                            <div style="background: linear-gradient(to bottom, #fdfdfd 0%,#f4f4f4 100%);border: 1px solid #ddd;height:30px;padding-left:5px;padding-top:7px;border-bottom:0"  ><b>
                                        Khuyến mãi kèm theo</b></div>
                            <div class="crosssell" >
                                
                                    
                                        
                                    <asp:Repeater ID="rptOfferItems" runat="server">
                                        <HeaderTemplate>
                                            <ul id="crosssell-products-list">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li class="item odd"><a class="product-image" href='/item-details.aspx?pid=<%# Eval("ItemCd") %>'
                                                title='<%# Eval("ItemName")%>' style="width: 60px; height: 60px;">
                                                <img src='/pages/media/images/items/small/<%# Eval("ItemImage") %>' alt='<%# Eval("ItemName")%>'
                                                    width="60" height="60">
                                            </a>&nbsp;&nbsp;<div class="product-details">
                                                <p class="product-name">
                                                    <a href='/item-details.aspx?pid=<%# Eval("ItemCd") %>'>
                                                        <%# Eval("ItemName")%>
                                                    </a>
                                                    <br />
                                                    Số lượng:
                                                    <%# Eval("Quantity")%>
                                                </p>
                                            </div>
                                            </li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ul>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div><br />
                                <div class="crosssell" style="height:160px">
                                <div class="landscape" ><div style="left:25px;top:112px;position:relative;color:Red;font-weight:bold;font-size:16px;"><asp:Label ID="Label1" runat="server"></asp:Label> đ</div></div>
                                </div>
                            </div>
                            <div class="col-2">
                                <div class="discount">
                                    <div class="discount-form">
                                        <label for="coupon_code">
                                            <i class="icon-gift"></i>Nhập mã Gift Card nếu bạn có.</label>
                                        <input type="hidden" name="remove" id="remove-coupone" value="0">
                                        <div class="input-box">
                                            <asp:TextBox ID="txtGift" CssClass="input-text" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="buttons-set" style="text-align: center">
                                            <asp:LinkButton class="btn btn-blue" Width="122" ID="LinkButton1" runat="server"
                                                OnClick="LinkButton1_Click"><span>Áp dụng</span></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="totals" style="background-color:#dbf4ff">
                            <table id="shopping-cart-totals-table">
                                <colgroup>
                                    <col>
                                    <col width="1">
                                </colgroup>
                                <tfoot>
                                    <tr>
                                        <td style="" class="a-right" colspan="1">
                                            Tổng tiền sản phẩm
                                        </td>
                                        <td style="" class="a-right">
                                            <span class="price">
                                                <asp:Label CssClass="price" ID="lblSubTotal" runat="server" Text="0"></asp:Label></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="" class="a-right" colspan="1">
                                            Giảm giá Gift Card
                                            <br />
                                            <%
                                                if (Session["GiftCd"] != null)
                                                {
                                            %>
                                            <b><%=Session["GiftCd"].ToString()%></b>
                                            <% } %>
                                        </td>
                                        <td style="" class="a-right">
                                            <span class="price">
                                                -<asp:Label CssClass="price" ID="LblGiftPrice" runat="server" Text="0"></asp:Label></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="a-right" colspan="1">
                                            <strong>Tổng tiền</strong>
                                        </td>
                                        <td style="border-top:1px solid #BBBBBB" class="a-right">
                                            <strong>
                                                <asp:Label CssClass="price" ID="LblTotalPrice" runat="server" Text="0"></asp:Label></strong>
                                            <br />
                                            <p style="margin-top: 21px; text-align: center">
                                                <asp:LinkButton class="btn btn-orange" Width="122" ID="HyperLinkTT" runat="server"
                                                    OnClick="HyperLinkTT_Click"><span>Thanh toán</span></asp:LinkButton>
                                            </p>
                                        </td>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
