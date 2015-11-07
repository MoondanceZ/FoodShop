using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShop.ashx
{
    /// <summary>
    /// LoadShoppingCart 的摘要说明
    /// </summary>
    public class LoadShoppingCart : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string strCart = Common.LoadShoppingCart.GetCartByUser();
            context.Response.Write(strCart);
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