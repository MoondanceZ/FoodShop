using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace FoodShop.Common
{
    public class LoadShoppingCart : System.Web.UI.Page
    {        
        public static string GetCartByUser()
        {
            StringBuilder sb = new StringBuilder();
            MODEL.User user = new MODEL.User();
            if (System.Web.HttpContext.Current.Session["userInfo"] != null)
            {
                user = System.Web.HttpContext.Current.Session["userInfo"] as MODEL.User;                
                //var sumList = List.sum(a => a.obj);            
                DataTable dtCart = BLL.ShoppingCartManager.GetCartDt(user.LoginId);
                if (dtCart.Rows.Count > 0)
                {
                    var sumMoney = dtCart.AsEnumerable().Sum(s => s.Field<decimal>("prdPrice"));
                    sb.Append("<ul id='cart_nav'><li>");
                    sb.Append("<li>");
                    sb.AppendFormat("<a class='cart_li' href='../Member/ShoppingCart.aspx'>购物车 <span>￥{0}</span></a>", sumMoney);
                    sb.Append("<ul class='cart_cont'>");
                    sb.Append(@"<li class='no_border'>
                                    <p>最近添加</p>
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
                            <a href='shopping_cart.html' class='view_cart'>查看购物车</a>
                            <a href='checkout.html' class='checkout'>结算</a>
                        </li>
                    </ul>
                </li>
            </ul>");
                }
            }
            else
            {
                sb.Append("<ul id='cart_nav'><li>");
                sb.Append("<li>");
                sb.Append("<a class='cart_li' href='../Member/ShoppingCart.aspx'>购物车 <span>￥0.00</span></a>");
                sb.Append("<ul class='cart_cont'>");
                sb.Append(@"<li class='no_border'>
                                    <p>购物车是空的~</p>
                               </li>");
                sb.Append(@" <li class='no_border'>
                            <a href='shopping_cart.html' class='view_cart'>查看购物车</a>
                            <a href='checkout.html' class='checkout'>结算</a>
                        </li>
                    </ul>
                </li>
            </ul>");
            }
            return sb.ToString();

        }
    }
}