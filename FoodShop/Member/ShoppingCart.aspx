<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MainFrame.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="FoodShop.Member.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clear"></div>
    <section id="main" class="entire_width">
        <div class="container_12">
            <div class="grid_12">
                <h1 class="page_title">购物车</h1>

                <table class="cart_product">
                    <tr>
                        <th class="images"></th>
                        <th class="bg name">商品名称</th>
                        <th class="edit"></th>
                        <th class="bg price">单价</th>
                        <th class="qty">数量</th>
                        <th class="bg subtotal">金额</th>
                        <th class="close"></th>
                    </tr>
                    <tr>
                        <td class="images"><a href="product_page.html">
                            <img src="images/product_6.png" alt="Product 6"/></a></td>
                        <td class="bg name">Paddywax Fragrance Diffuser Set, Gardenia Tuberose,<br />
                            Jasmine, 4-Ounces</td>
                        <td class="edit"><a title="Edit" href="#">Edit</a></td>
                        <td class="bg price">$75.00</td>
                        <td class="qty">
                            <input type="text" name="" value="" placeholder="1000" /></td>
                        <td class="bg subtotal">$750.00</td>
                        <td class="close"><a title="close" class="close" href="#"></a></td>
                    </tr>
                    <tr>
                        <td class="images"><a href="product_page.html">
                            <img src="images/produkt_slid1.png" alt="Product Slide 1"/></a></td>
                        <td class="bg name">California Scents Spillproof Organic Air Fresheners,<br />
                            Coronado Cherry, 1.5 Ounce Cannister</td>
                        <td class="edit"><a title="Edit" href="#">Edit</a></td>
                        <td class="bg price">$75.00</td>
                        <td class="qty">
                            <input type="text" name="" value="" placeholder="1000" /></td>
                        <td class="bg subtotal">$750.00</td>
                        <td class="close"><a title="close" class="close" href="#"></a></td>
                    </tr>
                    <tr>
                        <td colspan="7" class="cart_but">
                            <button class="continue"><span>icon</span>继续购物</button>
                            <button class="update"><span>icon</span>刷新购物车</button>
                        </td>
                    </tr>
                </table>
            </div>
            <!-- .grid_12 -->

            <div id="content_bottom">
                <div class="grid_4">
                    <div class="bottom_block estimate">
                        <h3>收货地址</h3>
                        <form>
                            <p>
                                <strong>省/市/自治区:</strong><sup class="surely">*</sup><br />
                                <select>
                                    <option>广西</option>
                                    <option>广东</option>
                                </select>
                            </p>
                            <p>
                                <strong>市/县:</strong><br />
                                <select>
                                    <option>柳州</option>
                                    <option>南宁</option>
                                </select>
                            </p>
                            <p>
                                <strong>街道:</strong><br />
                                <input type="text" name="" value="" />
                            </p>
                            <p>
                                <strong>邮编:</strong><br />
                                <input type="text" name="" value="" />
                            </p>
                            <input type="submit" id="get_estimate" value="检测地址" />
                        </form>

                    </div>
                    <!-- .estimate -->
                </div>
                <!-- .grid_4 -->

                <div class="grid_4">
                    <div class="bottom_block discount">
                        <h3>优惠券</h3>
                        <form>
                            <p>
                                <input type="text" name="" value="" placeholder="" />
                            </p>
                            <input type="submit" id="apply_coupon" value="应用" />
                        </form>
                    </div>
                    <!-- .discount -->
                </div>
                <!-- .grid_4 -->

                <div class="grid_4">
                    <div class="bottom_block total">
                        <table class="subtotal">
                            <tr>
                                <td>合计</td>
                                <td class="price">￥1, 500.00</td>
                            </tr>
                            <tr class="grand_total">
                                <td>折后价</td>
                                <td class="price">￥1, 500.00</td>
                            </tr>
                        </table>
                        <button class="checkout">确认支付</button>
                        <%--<a href="#">选择其他地址</a>--%>
                    </div>
                    <!-- .total -->
                </div>
                <!-- .grid_4 -->
                <div class="clear"></div>
            </div>
            <!-- #content_bottom -->
        </div>
        <!-- .container_12 -->
    </section>
    <!-- #main -->

    <div class="clear"></div>
</asp:Content>
