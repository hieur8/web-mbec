<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/client.Master" AutoEventWireup="true"
    CodeBehind="items.aspx.cs" Inherits="MiBo.pages.cln.items" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="main" runat="server">
    <asp:Repeater ID="rptPaging" runat="server">
        <HeaderTemplate>
            <ul class="paging">
                <li class="pre"><a>Trước</a></li>
        </HeaderTemplate>
        <ItemTemplate>
            <li class="page">
                <a></a>
            </li>
        </ItemTemplate>
        <FooterTemplate>
                <li class="next"><a>Sau</a></li>
            </ul>
        </FooterTemplate>
    </asp:Repeater>

    <div class="main-container col1-layout">
        <div class="main">
            <div class="col-main box jplist">
                <div class="breadcrumbs">
                    <ul>
                        <li class="home"><a href="/index.aspx" title="Trở về trang chủ">Trang chủ</a> <span>
                            / </span></li>
                        <li class="category37"><strong>Sản phẩm</strong> </li>
                    </ul>
                </div>
                <div class="page-title category-title">
                    <h1>
                        Sản phẩm</h1>
                </div>
                <div id="listItems" class="toolbar jplist">
                    <!-- panel -->
                    <div class="toolbar panel">
                        <div class="pager box">
                            <div class="drop-down" data-control-type="drop-down" data-control-name="paging" data-control-action="paging">
                                <div class="panel">
                                    10 per page
                                </div>
                                <ul style="display: none;">
                                    <li class=""><span data-number="3">3 sp mỗi trang </span></li>
                                    <li><span data-number="5">5 sp mỗi trang </span></li>
                                    <li class="active"><span data-number="10" data-default="true">10 sp mỗi trang </span>
                                    </li>
                                    <li><span data-number="all">xem tất cả sp </span></li>
                                </ul>
                            </div>
                            <div class="drop-down" data-control-type="drop-down" data-control-name="sort" data-control-action="sort"
                                data-datetime-format="{month}/{day}/{year}">
                                <div class="panel">
                                    Likes asc</div>
                                <!-- {year}, {month}, {day}, {hour}, {min}, {sec} -->
                                <ul style="display: none;">
                                    <li class=""><span data-path="default">Xắp xếp</span></li>
                                    <li><span data-path=".title" data-order="asc" data-type="text">Tên sp A-Z</span></li>
                                    <li><span data-path=".title" data-order="desc" data-type="text">Tên sp Z-A</span></li>
                                    <li><span data-path=".date" data-order="asc" data-type="datetime">Date asc</span></li>
                                    <li><span data-path=".date" data-order="desc" data-type="datetime">Date desc</span></li>
                                </ul>
                            </div>
                            <!-- filter -->
                            <div class="filter">
                                <div class="search-title">
                                    Lọc theo tên</div>
                                <input data-path=".title" type="text" value="" placeholder="nhập tên cần lọc" data-control-type="textbox"
                                    data-control-name="title-filter" data-control-action="filter" />
                                <div class="clear">
                                </div>
                            </div>
                            <br />
                            <!-- paging -->
                            <div class="paging-results" data-type="Trang {current} của {pages}" data-control-type="label"
                                data-control-name="paging" data-control-action="paging">
                                Page 1 of 4</div>
                            <div class="paging" data-control-type="placeholder" data-control-name="paging" data-control-action="paging">
                                <div class="pagingprev hidden">
                                    <span class="first" data-number="0">&lt;&lt;</span> <span class="prev" data-number="0">
                                        &lt;</span>
                                </div>
                                <div class="pagingmid">
                                    <div class="pagesbox">
                                        <span class="current" data-active="true" data-number="0">1</span> <span data-number="1">
                                            2</span> <span data-number="2">3</span> <span data-number="3">4</span>
                                    </div>
                                </div>
                                <div class="pagingnext">
                                    <span class="next" data-number="1">&gt;</span><span class="last" data-number="3">&gt;&gt;</span>
                                </div>
                            </div>
                        </div>
                        <!-- data -->
                        <div class="category-products">
                            <div class="list-view">
                                <asp:Repeater ID="rptItem" runat="server">
                                    <HeaderTemplate>
                                        <ol class="products-list" id="products-list">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li class="item"><a href='/item-details.aspx?pid=<%# Eval("ItemCd") %>' title="<%# Eval("ItemName") %>"
                                            class="product-image">
                                            <img src='/pages/media/images/items/<%# Eval("ItemCd") %>/small/<%# Eval("ItemImage") %>'
                                                alt='<%# Eval("ItemName") %>'>
                                        </a>&nbsp;&nbsp;<div class="product-shop">
                                            <div class="f-fix">
                                                <h3 class="product-name">
                                                    <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>" title='<%# Eval("ItemName") %>'
                                                        class="title">
                                                        <%# Eval("ItemName") %></a>
                                                </h3>
                                                <div class="price-box">
                                                    <span class="regular-price" id="product-price-181-new">
                                                        <%# Equals("", Eval("ItemDiv")) && Equals("01", Eval("OfferDiv")) ? "<span class='pricesub'>" + Eval("PriceOld") + "</span>" : ""%>
                                                        <br />
                                                        <span class="price">
                                                            <%# Eval("Price") %>
                                                        </span></span>
                                                </div>
                                                <p>
                                                    <asp:LinkButton Visible="false" CssClass="button btn-cart" OnCommand="lnkBuy_Command"
                                                        CommandArgument='<%# Eval("ItemCd") %>' ID="lnkBuy" runat="server">Mua hàng</asp:LinkButton>
                                                </p>
                                                <div class="desc std">
                                                    <p class="desc">
                                                        <%# Eval("SummaryNotes")%>
                                                        <a href="/item-details.aspx?pid=<%# Eval("ItemCd") %>" title='<%# Eval("ItemName") %>'
                                                            class="link-more">Chi tiết</a>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                        </li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </ol>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="box jplist-no-results" style="display: none;">
                            <p>
                                Không có sản phẩm nào</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
