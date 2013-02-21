<%@ Page Title="" Language="C#" MasterPageFile="~/pages/common/customer.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="MiBo.pages.cln.products" %>
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
<div id="demo" class="box jplist">
					
						<!-- panel -->
						<div class="panel box">						
													
							<div class="drop-down" data-control-type="drop-down" data-control-name="paging" data-control-action="paging"><div class="panel"> 10 per page </div>
								
								<ul style="display: none;">
									<li class=""><span data-number="3"> 3 per page </span></li>
									<li><span data-number="5"> 5 per page </span></li>
									<li class="active"><span data-number="10" data-default="true"> 10 per page </span></li>
									<li><span data-number="all"> view all </span></li>
								</ul>
							</div>
							
							<div class="drop-down" data-control-type="drop-down" data-control-name="sort" data-control-action="sort" data-datetime-format="{month}/{day}/{year}"><div class="panel">Likes asc</div> <!-- {year}, {month}, {day}, {hour}, {min}, {sec} -->
								
								<ul style="display: none;">
									<li class=""><span data-path="default">Sort by</span></li>
									<li><span data-path=".title" data-order="asc" data-type="text">Title A-Z</span></li>
									<li><span data-path=".title" data-order="desc" data-type="text">Title Z-A</span></li>
									<li><span data-path=".desc" data-order="asc" data-type="text">Description A-Z</span></li>
									<li><span data-path=".desc" data-order="desc" data-type="text">Description Z-A</span></li>
									<li class="active"><span data-path=".like" data-order="asc" data-type="number" data-default="true">Likes asc</span></li>
									<li><span data-path=".like" data-order="desc" data-type="number">Likes desc</span></li>
									<li><span data-path=".date" data-order="asc" data-type="datetime">Date asc</span></li>
									<li><span data-path=".date" data-order="desc" data-type="datetime">Date desc</span></li>
								</ul>
							</div>
							
							<!-- filter -->
							<div class="filter">	
							
								<div class="search-title">Filter by title</div>
								<input data-path=".title" type="text" value="" placeholder="Filter by title" data-control-type="textbox" data-control-name="title-filter" data-control-action="filter">
								
							<div class="search-title">description</div>
								<input data-path=".desc" type="text" value="" placeholder="Filter by description" data-control-type="textbox" data-control-name="desc-filter" data-control-action="filter">	
							</div>
							
			<div class="clear"></div>
							
							<!-- paging -->
							<div class="paging-results" data-type="Page {current} of {pages}" data-control-type="label" data-control-name="paging" data-control-action="paging">Page 1 of 4</div>
								
							<div class="paging" data-control-type="placeholder" data-control-name="paging" data-control-action="paging"><div class="pagingprev hidden"><span class="first" data-number="0">&lt;&lt;</span><span class="prev" data-number="0">&lt;</span></div><div class="pagingmid"><div class="pagesbox"><span class="current" data-active="true" data-number="0">1</span> <span data-number="1">2</span> <span data-number="2">3</span> <span data-number="3">4</span> </div></div><div class="pagingnext"><span class="next" data-number="1">&gt;</span><span class="last" data-number="3">&gt;&gt;</span></div></div>					
						</div>
						
						<!-- data -->   
						<div class="category-products" >
                        <div class="list-view" >
                        <ol class="products-list" id="products-list">
                        
    <li class="item odd">
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
                    <button type="button" title="Add to Cart" class="button btn-cart" onclick="setLocation('http://www.magento-themes.jextn.com/demo/mageno_blue_toys_theme_demo/index.php/checkout/cart/add/uenc/aHR0cDovL3d3dy5tYWdlbnRvLXRoZW1lcy5qZXh0bi5jb20vZGVtby9tYWdlbm9fYmx1ZV90b3lzX3RoZW1lX2RlbW8vaW5kZXgucGhwL2dpZnRzaG9wLmh0bWw_X19fU0lEPVUmZGlyPWFzYyZtb2RlPWxpc3Qmb3JkZXI9bmFtZQ,,/product/175/')">
                        <span><span>Add to Cart</span></span></button></p>
                <div class="desc std"><p class="desc">
                    The name Teddy Bear comes from former United States President Theodore Roosevelt
                    <a href="#"
                        title="Bee Toy" class="link-more">Learn More</a></p>
                </div>
            </div>
        </div>
    </li>
    <li class="item even">
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
                    <button type="button" title="Add to Cart" class="button btn-cart">
                        <span><span>Add to Cart</span></span></button></p>
                <div class="desc std"><p class="desc">
                    The name Teddy Bear comes from former United States President Theodore Roosevelt
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
							<p>No results found</p>
						</div>
						
						<!-- panel -->
						<div class="panel box">						
													
							<div class="drop-down" data-control-type="drop-down" data-control-name="paging" data-control-action="paging"><div class="panel"> 10 per page </div>
								
								<ul style="display: none;">
									<li class=""><span data-number="3"> 3 per page </span></li>
									<li><span data-number="5"> 5 per page </span></li>
									<li class="active"><span data-number="10" data-default="true"> 10 per page </span></li>
									<li><span data-number="all"> view all </span></li>
								</ul>
							</div>
							<div class="drop-down" data-control-type="drop-down" data-control-name="sort" data-control-action="sort" data-datetime-format="{month}/{day}/{year}"><div class="panel">Likes asc</div> <!-- {year}, {month}, {day}, {hour}, {min}, {sec} -->
								
								<ul style="display: none;">
									<li class=""><span data-path="default">Sort by</span></li>
									<li><span data-path=".title" data-order="asc" data-type="text">Title A-Z</span></li>
									<li><span data-path=".title" data-order="desc" data-type="text">Title Z-A</span></li>
									<li><span data-path=".desc" data-order="asc" data-type="text">Description A-Z</span></li>
									<li><span data-path=".desc" data-order="desc" data-type="text">Description Z-A</span></li>
									<li class="active"><span data-path=".like" data-order="asc" data-type="number">Likes asc</span></li>
									<li><span data-path=".like" data-order="desc" data-type="number">Likes desc</span></li>
									<li><span data-path=".date" data-order="asc" data-type="datetime">Date asc</span></li>
									<li><span data-path=".date" data-order="desc" data-type="datetime">Date desc</span></li>
								</ul>
							</div>
							
							<!-- paging -->
							<div class="paging-results" data-type="{start} - {end} of {all}" data-control-type="label" data-control-name="paging" data-control-action="paging">1 - 10 of 33</div>
								
							<div class="paging" data-control-type="placeholder" data-control-name="paging" data-control-action="paging"><div class="pagingprev hidden"><span class="first" data-number="0">&lt;&lt;</span><span class="prev" data-number="0">&lt;</span></div><div class="pagingmid"><div class="pagesbox"><span class="current" data-active="true" data-number="0">1</span> <span data-number="1">2</span> <span data-number="2">3</span> <span data-number="3">4</span> </div></div><div class="pagingnext"><span class="next" data-number="1">&gt;</span><span class="last" data-number="3">&gt;&gt;</span></div></div>							
						</div>
					</div>
</asp:Content>
