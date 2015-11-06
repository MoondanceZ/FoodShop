using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace FoodShop.ashx
{
    /// <summary>
    /// AddPrd2Cart 的摘要说明
    /// </summary>
    public class AddPrd2Cart : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string PrdNo = context.Request["PrdNo"];
            if (context.Session["userInfo"] == null)
            {
                context.Response.Write("NoLogin");
            }
            else
            {
                if (!string.IsNullOrEmpty(PrdNo))
                {
                    MODEL.Product product = BLL.ProductManager.GetPrd(PrdNo);
                    if (product != null)
                    {
                        MODEL.User user = context.Session["userInfo"] as MODEL.User;
                        MODEL.ShoppingCart cart = BLL.ShoppingCartManager.GetCart(user.LoginId, PrdNo);
                        if (cart != null)
                        {
                            cart.PrdQty = cart.PrdQty + 1;
                            BLL.ShoppingCartManager.UpdateCart(cart);
                        }
                        else
                        {
                            cart = new MODEL.ShoppingCart();
                            cart.UserId = user.LoginId;
                            cart.PrdName = product.PrdName;
                            cart.PrdNo = product.PrdNo;
                            cart.PrdQty = 1;
                            cart.SettleStt = 0;
                            BLL.ShoppingCartManager.AddCart(cart);
                        }
                        DataTable dtCart = BLL.ShoppingCartManager.GetCartDt(user.LoginId);
                        StringBuilder sb = new StringBuilder();
                        //var sumList = List.sum(a => a.obj);
                        var sumMoney = dtCart.AsEnumerable().Sum(s => s.Field<decimal>("prdPrice"));
                        sb.Append("<ul id='cart_nav'><li>");
                        sb.Append("<li>");
                        sb.AppendFormat("<a class='cart_li' href='../Member/ShoppingCart.aspx'>购物车 <span>￥{0}</span></a>", sumMoney);
                        sb.Append("<ul class='cart_cont'>");
                        sb.Append(@"<li class='no_border'>
                                    <p>Recently added item(s)</p>
                               </li>");
                        for (int i = 0; i < dtCart.Rows.Count; i++)
                        {
                            DataRow dr = dtCart.Rows[i];
                            sb.AppendFormat(
                                @"<li>
                            <a href='product_page.html' class='prev_cart'>
                                <div class='cart_vert'>
                                    <img src='../images/{0}' alt='{1}' title='' />
                                </div>
                            </a>
                            <div class='cont_cart'>
                                <h4>{2}</h4>
                                <div class='price'>{2} x ￥{3}</div>
                            </div>
                            <a title='close' class='close' href='#'></a>
                            <div class='clear'></div>
                            </li>", dr["mainImg"].ToString(), dr["prdName"].ToString(), dr["prdQty"].ToString(), dr["prdPrice"]);
                        }
                        sb.Append(@" <li class='no_border'>
                            <a href='shopping_cart.html' class='view_cart'>View shopping cart</a>
                            <a href='checkout.html' class='checkout'>Procced to Checkout</a>
                        </li>
                    </ul>
                </li>
            </ul>");
                        context.Response.Write(sb);
                    }

                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}