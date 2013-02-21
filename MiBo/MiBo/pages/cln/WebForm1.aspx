<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/customer.Master" AutoEventWireup="true"
    CodeBehind="WebForm1.aspx.cs" Inherits="MiBo.pages.cln.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script src="../resources/scripts/jplist.min.js"</script>		
<script src='../resources/scripts/json2.min.js'></script>
<script>
    $('document').ready(function () {
        $('#demo').jplist({

            items_box: '.products-list'
					, item_path: '.item'
					, panel_path: '.panel'

            //cookies
					, cookies: false
					, expiration: -1 //cookies expiration in days (-1 = cookies expire when browser is closed)
					, cookie_name: 'jplist-div-layout'
        });
    });
		</script>
    <div class="main-container col1-layout">
        <div class="main">
            <div class="col-main box jplist">
                <div class="breadcrumbs">
                    <ul>
                        <li class="home"><a href="index.aspx"
                            title="Go to Home Page">Trang chủ</a> <span>/ </span></li>
                        <li class="category37"><strong>Sản phẩm</strong> </li>
                    </ul>
                </div>
                <div class="page-title category-title">
                    <h1>Sản phẩm</h1>
                </div>
                <div id="demo" class="toolbar jplist">
					
						<!-- panel -->
                        <div class="toolbar panel">
						<div class="pager box">						
													
							<div class="drop-down" data-control-type="drop-down" data-control-name="paging" data-control-action="paging"><div class="panel"> 10 per page </div>
								
								<ul style="display: none;">
									<li class=""><span data-number="3"> 3 sp mỗi trang </span></li>
									<li><span data-number="5"> 5 sp mỗi trang </span></li>
									<li class="active"><span data-number="10" data-default="true"> 10 sp mỗi trang </span></li>
									<li><span data-number="all"> xem tất cả sp </span></li>
								</ul>
							</div>
							
							<div class="drop-down" data-control-type="drop-down" data-control-name="sort" data-control-action="sort" data-datetime-format="{month}/{day}/{year}"><div class="panel">Likes asc</div> <!-- {year}, {month}, {day}, {hour}, {min}, {sec} -->
								
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
							
								<div class="search-title">Lọc theo tên</div>
								<input data-path=".title" type="text" value="" placeholder="nhập tên cần lọc" data-control-type="textbox" data-control-name="title-filter" data-control-action="filter">
			<div class="clear"></div>
							
									
						</div>

                        <br />
                        <!-- paging -->
							<div class="paging-results" data-type="Trang {current} của {pages}" data-control-type="label" data-control-name="paging" data-control-action="paging">Page 1 of 4</div>
								
							<div class="paging" data-control-type="placeholder" data-control-name="paging" data-control-action="paging"><div class="pagingprev hidden"><span class="first" data-number="0">&lt;&lt;</span><span class="prev" data-number="0">&lt;</span></div><div class="pagingmid"><div class="pagesbox"><span class="current" data-active="true" data-number="0">1</span> <span data-number="1">2</span> <span data-number="2">3</span> <span data-number="3">4</span> </div></div><div class="pagingnext"><span class="next" data-number="1">&gt;</span><span class="last" data-number="3">&gt;&gt;</span></div></div>			
						</div>
						<!-- data -->   
						<div class="category-products" >
                        <div class="list-view" >
                        <ol class="products-list" id="products-list">
                        
    <li class="item">
    <a href="#"
        title="Bee Toy" class="product-image">
        <img src="../media/images/items/01/small/01.jpg"
            width="135" height="135" alt="Bee Toy"></a>
        <div class="product-shop">
            <div class="f-fix">
                <h2 class="product-name">
                    <a href="#"
                        title="Bee Toy" class="title">ABC</a></h2>
                <div class="price-box">
                    <span class="regular-price" id="Span2"><span class="price">$50.00</span>
                    </span>
                </div>
                <p>
                    <button type="button" title="Mua hàng" class="button btn-cart" onclick="setLocation('http://www.magento-themes.jextn.com/demo/mageno_blue_toys_theme_demo/index.php/checkout/cart/add/uenc/aHR0cDovL3d3dy5tYWdlbnRvLXRoZW1lcy5qZXh0bi5jb20vZGVtby9tYWdlbm9fYmx1ZV90b3lzX3RoZW1lX2RlbW8vaW5kZXgucGhwL2dpZnRzaG9wLmh0bWw_X19fU0lEPVUmZGlyPWFzYyZtb2RlPWxpc3Qmb3JkZXI9bmFtZQ,,/product/175/')">
                        <span><span>Mua hàng</span></span></button></p>
                <div class="desc std"><p class="desc">
                    The name Teddy Bear comes from former United States President Theodore Roosevelt
                    <a href="#"
                        title="Bee Toy" class="link-more">Learn More</a></p>
                </div>
            </div>
        </div>
    </li>
    <li class="item">
    <a href="#"
        title="Bee Toy" class="product-image">
        <img src="../media/images/items/01/small/01.jpg"
            width="135" height="135" alt="Bee Toy"></a>
        <div class="product-shop">
            <div class="f-fix">
                <h2 class="product-name">
                    <a href="#"
                        title="Bee Toy" class="title">XYZ</a></h2>
                <div class="price-box">
                    <span class="regular-price" id="Span1"><span class="price">$50.00</span>
                    </span>
                </div>
                <p>
                    <button type="button" title="Mua hàng" class="button btn-cart">
                        <span><span>Mua hàng</span></span></button></p>
                <div class="desc std"><p class="desc">
                    89 The name Teddy Bear comes from former United States President Theodore Roosevelt
                    <a href="#"
                        title="Bee Toy" class="link-more">Learn More</a></p>
                </div>
            </div>
            </div>
    </li>
    <li class="item">
    <a href="#"
        title="Bee Toy" class="product-image">
        <img src="../media/images/items/01/small/01.jpg"
            width="135" height="135" alt="Bee Toy"></a>
        <div class="product-shop">
            <div class="f-fix">
                <h2 class="product-name">
                    <a href="#"
                        title="Bee Toy" class="title">XYZ 2</a></h2>
                <div class="price-box">
                    <span class="regular-price" id="Span3"><span class="price">$50.00</span>
                    </span>
                </div>
                <p>
                    <button type="button" title="Mua hàng" class="button btn-cart">
                        <span><span>Mua hàng</span></span></button></p>
                <div class="desc std"><p class="desc">
                    545n The name Teddy Bear comes from former United States President Theodore Roosevelt
                    <a href="#"
                        title="Bee Toy" class="link-more">Learn More</a></p>
                </div>
            </div>
            </div>
    </li>
    <li class="item">
    <a href="#"
        title="Bee Toy" class="product-image">
        <img src="../media/images/items/01/small/01.jpg"
            width="135" height="135" alt="Bee Toy"></a>
        <div class="product-shop">
            <div class="f-fix">
                <h2 class="product-name">
                    <a href="#"
                        title="Bee Toy" class="title">XYZ 3</a></h2>
                <div class="price-box">
                    <span class="regular-price" id="Span4"><span class="price">$50.00</span>
                    </span>
                </div>
                <p>
                    <button type="button" title="Mua hàng" class="button btn-cart">
                        <span><span>Mua hàng</span></span></button></p>
                <div class="desc std"><p class="desc">
                     ewew The name Teddy Bear comes from former United States President Theodore Roosevelt
                    <a href="#"
                        title="Bee Toy" class="link-more">Learn More</a></p>
                </div>
            </div>
            </div>
    </li>
</ol>
                        </div>
                        </div>
						<div class="box jplist-no-results" style="display: none;">
							<p>Không có sản phẩm nào</p>
						</div>
					</div>
            </div>
        </div>
    </div>
</asp:Content>
