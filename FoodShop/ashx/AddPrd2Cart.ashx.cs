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
                        string strCart = Common.LoadShoppingCart.GetCartByUser();
                        context.Response.Write(strCart);
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