<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainFrame.Master" AutoEventWireup="true" CodeBehind="CatalogGrid.aspx.cs" Inherits="FoodShop.Member.CatalogGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript">
        $(function () {            
            $("a[class='bay']").click(function () {
                if (confirm("添加到购物车?")) {
                    var PrdId = $(this).attr("PrdId");
                    $.post("/ashx/AddPrd2Cart.ashx", { PrdId: PrdId }, function (data) {
                        if (data == "NoLogin") {
                            location.href = "Login.aspx";
                        }
                    })
                }                
            });
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clear"></div>

    <div class="container_12">
        <div class="grid_12">
            <div class="breadcrumbs">
                <a href="Index.aspx">Home</a><span>&#8250;</span><a href="#">Category</a><span>&#8250;</span><span class="current">This page</span>
            </div>
            <!-- .breadcrumbs -->
        </div>
        <!-- .grid_12 -->
    </div>
    <!-- .container_12 -->

    <div class="clear"></div>

    <section id="main">
        <div class="container_12">
            <div id="sidebar" class="grid_3">
                <aside id="categories_nav">
                    <h3>分类</h3>

                    <nav class="left_menu">
                        <ul>
                            <li><a href="#">Solids <span>(21)</span></a></li>
                            <li><a href="#">Liquids <span>(27)</span></a></li>
                            <li><a href="#">Spray <span>(33)</span></a></li>
                            <li><a href="#">Electric <span>(17)</span></a></li>
                            <li><a href="#">For Cars <span>(23)</span></a></li>
                            <li><a href="#">For Room <span>(7)</span></a></li>
                            <li class="last"><a href="#">Other <span>(135)</span></a></li>
                        </ul>
                    </nav>
                    <!-- .left_menu -->
                </aside>
                <!-- #categories_nav -->

                <aside id="shop_by">
                    <h3>Shop By</h3>

                    <div class="currently_shopping">
                        <p>Currently Shopping by:</p>
                        <ul>
                            <li><a title="close" class="close" href="#"></a>Price: <span>$0.00 - $999.99</span></li>
                            <li><a title="close" class="close" href="#"></a>Manufacturer: <span>Apple</span></li>
                        </ul>

                        <a class="clear_all" href="#">Clear All</a>

                        <div class="clear"></div>
                    </div>
                    <!-- .currently_shopping -->

                    <h4>Category</h4>

                    <form action="#" class="check_opt">
                        <p>
                            <input class="niceCheck" type="checkbox" />For Home (23)</p>
                        <p>
                            <input class="niceCheck" type="checkbox" name="" value="" />For Car (27)</p>
                        <p>
                            <input class="niceCheck" type="checkbox" name="" value="" />For Office (9)</p>
                    </form>

                    <h4>Price</h4>

                    <form action="#" class="check_opt">
                        <p>
                            <input class="niceCheck" type="checkbox" name="" value="" />0.00 - $49.99 (21)</p>
                        <p>
                            <input class="niceCheck" type="checkbox" name="" value="" />$50.00 - $99.99 (7)</p>
                        <p>
                            <input class="niceCheck" type="checkbox" name="" value="" />0$100.00 and above (15)</p>
                    </form>
                </aside>
                <!-- #shop_by -->

                <aside id="specials" class="specials">
                    <h3>Specials</h3>

                    <ul>
                        <li>
                            <div class="prev">
                                <a href="product_page.html">
                                    <img src="../images/special1.png" alt="" title="" /></a>
                            </div>

                            <div class="cont">
                                <a href="product_page.html">Honeysuckle Flameless Luminary Refill</a>
                                <div class="prise"><span class="old">$177.00</span>$75.00</div>
                            </div>
                        </li>

                        <li>
                            <div class="prev">
                                <a href="product_page.html">
                                    <img src="../images/special2.png" alt="" title="" /></a>
                            </div>

                            <div class="cont">
                                <a href="product_page.html">Honeysuckle Flameless Luminary Refill</a>
                                <div class="prise"><span class="old">$177.00</span>$75.00</div>
                            </div>
                        </li>
                    </ul>
                </aside>
                <!-- #specials -->

                <aside id="newsletter_signup">
                    <h3>Newsletter Signup</h3>
                    <p>
                        Phasellus vel ultricies felis. Duis 
		     rhoncus risus eu urna pretium.
                    </p>

                    <form class="newsletter">
                        <input type="email" name="newsletter" class="your_email" value="" placeholder="Enter your email address..." />
                        <input type="submit" id="submit" value="Subscribe" />
                    </form>
                </aside>
                <!-- #newsletter_signup -->
            </div>
            <!-- .sidebar -->

            <div id="content" class="grid_9">
                <h1 class="page_title">商品列表</h1>

                <div class="options">
                    <div class="grid-list">
                        <a class="grid curent" href="index.html"><span>img</span></a>
                        <a class="list" href="catalog_list.html"><span>img</span></a>
                    </div>
                    <!-- .grid-list -->

                    <div class="show">
                        显示
			    <select>                    
                    <option value="3">3</option>                   
                    <option value="6">6</option>                    
                    <option value="9">9</option>                    
                    <option value="12">12</option>
                    <option value="16">16</option>
                </select>
                        每页                       
                    </div>
                    <!-- .show -->

                    <div class="sort">
                        排序:
			    <select>
                    <option value="1">价格</option>
                    <option value="2">种类</option>
                    <option value="3">评价</option>
                    <option value="4">名称</option>
                </select>

                        <a class="sort_up" href="#">&#8593;</a>
                    </div>
                    <!-- .sort -->
                </div>
                <!-- .options -->

                <%if (ListPrd.Count > 0)
                  {%>
                <div class="grid_product">
                    <%  for (int i = 0; i < ListPrd.Count; i++)
                        {%>
                    <div class="grid_3 product">
                        <div class="prev">
                            <a href="product_page.html">
                                <img src="../images/<%=ListPrd[i].MainImg %>" alt="" title="" /></a>
                        </div>
                        <!-- .prev -->
                        <h3 class="title"><%= ListPrd[i].PrdName %></h3>
                        <div class="cart">
                            <div class="price">
                                <div class="vert">
                                    <div class="price_new">￥<%=ListPrd[i].NewPrice %></div>
                                    <div class="price_old">￥<%=ListPrd[i].OldPrice %></div>
                                </div>
                            </div>
                            <a href="#" class="obn"></a>
                            <a href="#" class="like"></a>
                            <a href="javascript:void(0)" PrdNo="<%=ListPrd[i].PrdNo %>" class="bay"></a>
                        </div>
                        <!-- .cart -->
                    </div>
                    <!-- .grid_3 -->
                    <% }
             } %>
                    <div class="clear"></div>
                </div>
                <!-- .grid_product -->

                <div class="clear"></div>
                <asp:Literal ID="NavStrHtml" runat="server"></asp:Literal>
                <%--<p class="pagination_info">Displaying 1 to 12 (of 100 products)</p>--%>
            </div>
            <!-- #content -->

            <div class="clear"></div>

        </div>
        <!-- .container_12 -->
    </section>
    <!-- #main -->

    <div class="clear"></div>
</asp:Content>
