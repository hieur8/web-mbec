<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="items.aspx.cs" Inherits="MiBo.pages.cln.items" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <div class="main-container col2-right-layout">
        <div class="main">
            <div class="col-main" style="width: 769px; border: 1px solid #ddd">
                <div class="breadcrumbs" style="height: 35px; border-bottom: 1px solid #ddd">
                    <ul style="width: 580px; float: left; padding: 10px 0;">
                        <li class="home"><a href="" title="Trở về trang chủ">Trang chủ</a> <span>/ </span>
                        </li>
                        <li class="category37"><strong>
                            <asp:Literal ID="litTitle" runat="server"></asp:Literal></strong> </li>
                    </ul>
                    <div class="sort-by" style="float: right; padding: 7px 5px 6px 5px;">
                        <label style="padding-right: 5px;">
                            Sắp xếp</label>
                        <select>
                            <option value="SortKey" selected="selected">Vị trí</option>
                            <option value="ItemName">Tên sản phẩm</option>
                            <option value="Price">Giá</option>
                        </select>
                    </div>
                </div>
                <div class="category-products" style="width: 769px">
                    <div class="grid-view" style="width: 769px; border: 0">
                        <asp:Repeater ID="rptItem" runat="server">
                            <HeaderTemplate>
                                <ul class="products-grid last odd" style="width: 769px">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li class="item first" style="padding-left: 10px; padding-right: 10px"><a href='/item-details.aspx?pid=<%# Eval("ItemCd") %>'
                                    title="<%# Eval("ItemName") %>" class="product-image">
                                    <img src='/pages/media/images/items/normal/<%# Eval("ItemImage") %>' alt='<%# Eval("ItemName") %>'>
                                </a>
                                    <div class="align-prodname-price-review">
                                        <h3 class="product-name">
                                            <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>" title='<%# Eval("Tooltip") %>'
                                                class="title">
                                                <%# Eval("ItemName") %>
                                            </a>
                                        </h3>
                                        <div class="price-box">
                                            <p style="margin: 0">
                                                Thương hiệu :
                                                <%# Eval("BrandName") %>
                                            </p>
                                            <span class="regular-price" id="product-price-181-new"><span style="text-align: right"
                                                class="price">
                                                <%# Eval("Price") %>
                                            </span>
                                                <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<span  style='text-align:right' class='pricesub'>" + Eval("PriceOld") + "</span>" : ""%>
                                            </span>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="toolbar-bottom">
                    </div>
                </div>
                <div class="toolbar" style="border: 0;">
                    <div class="pager">
                        <p class="amount">
                            <asp:Literal ID="litPagingInfo" runat="server"></asp:Literal>
                        </p>
                        <div class="pages">
                            <asp:Repeater ID="rptPaging" runat="server">
                                <HeaderTemplate>
                                    <ul class="paging">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li class="page"><a href='<%# Eval("Url") %>'>
                                        <%# Eval("Name") %></a></li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-right sidebar" style="width: 228px">
                <div class="perfume1">
                    <div class="tbl-right-box box-176 padd-bg-hotline ui-corner-tbl-top">
                        <span class="ui-hotline-2"></span>
                        <p class="padd-hotline-2">
                            <span style="font-size: 12px">hotline (24/7)</span>
                        </p>
                        <h4 class="num-hot">
                            <asp:Literal ID="litHotline" runat="server"></asp:Literal></h4>
                        <p>
                        </p>
                    </div>
                    <div id="right-cp" class="bg-cp">
                        <div class="padd-in-7 tbl-cp" style="padding-top: 0;">
                            <div class="c1" style="height: 1px; background: #dbdde0">
                            </div>
                            <div class="wrapper" style="margin-top: 9px;">
                                <a><span class="duty-40x40 duty-1a"></span>
                                    <p class="font-medium">
                                        Tặng thẻ giảm giá tương đương 10% giá trị đơn hàng 
                                     </p>
                                </a>
                            </div>
                            <div class="wrapper">
                                <a><span class="duty-40x40 duty-2a"></span>
                                    <p class="font-medium">
                                        100% các sản phẩm chính hãng giá tốt</p>
                                </a>
                            </div>
                            <div class="wrapper">
                                <a><span class="duty-40x40 duty-3a"></span>
                                    <p class="font-medium">
                                        7 ngày đổi trả hàng miễn <br /> phí</p>
                                </a>
                            </div>
                            <div class="wrapper">
                                <a><span class="duty-40x40 duty-4a"></span>
                                    <p class="font-medium">
                                        Giao hàng miễn phí với các đơn hàng trị giá từ 200.000 đ</p>
                                </a>
                            </div>
                            <hr />
                            <div class="wrapper">
                                <a id="lnkChatYahoo" runat="server" title="Click vào đây để Chat trực tiếp" style="text-decoration: none;
                                    padding: 0 6px">
                                    <img id="icoChatYahoo" runat="server" style="cursor: pointer; width: 72px" border="0"></a>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
