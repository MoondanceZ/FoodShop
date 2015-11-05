using System;
using System.Collections.Generic;
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
            string PrdNo = context.Request.QueryString["PrdNo"];
            if (context.Session["UserInfo"] == null)
            {
                context.Response.Write("NoLogin");
            }
            if (!string.IsNullOrEmpty(PrdNo))
            {
                MODEL.Product product = BLL.ProductManager.GetPrd(PrdNo);
                if (product != null)
                {
                    MODEL.User user=context.Session["UserInfo"] as MODEL.User;
                    MODEL.ShoppingCart cart = BLL.ShoppingCartManager.GetCart(user.LoginId, PrdNo);
                    if(cart!=null)
                    {
                        cart.PrdQty = cart.PrdQty + 1;
                        BLL.ShoppingCartManager.UpdateCart(cart);
                    }
                    else
                    {
                        MODEL.ShoppingCart addCartPrd = new MODEL.ShoppingCart();
                        addCartPrd.PrdName = product.PrdName;
                        addCartPrd.PrdNo = product.PrdNo;
                        addCartPrd.PrdQty = 1;
                        addCartPrd.SettleStt = 0;
                    }
                    List<MODEL.ShoppingCart> ListCart=BLL.ShoppingCartManager.GetCart(user.LoginId);
                    StringBuilder sb = new StringBuilder();
                    //var sum
                    sb.Append("<ul id='cart_nav'><li>");
                    sb.Append("<li>");
                    sb.AppendFormat("<a class='cart_li' href='../Member/ShoppingCart.aspx'>购物车 <span>${0}</span></a>",);
                    for (int i = 0; i < ListCart.Count; i++)
                    {
                        
                    }


                    //context.Response.Write("OK");
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