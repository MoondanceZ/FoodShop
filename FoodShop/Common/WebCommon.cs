using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShop.Common
{
    public class WebCommon
    {
        /// <summary>
        /// 判断是否登陆, 返回之前主页
        /// </summary>
        public static void GoIndexPage()
        {
            HttpContext.Current.Response.Redirect("../Member/Login.aspx?returnUrl=" + HttpContext.Current.Request.Url.ToString());
        }

        public static void GoBRegPage()
        {
            HttpContext.Current.Response.Redirect("../Member/Register.aspx?returnUrl=" + HttpContext.Current.Request.Url.ToString());
        }
    }
}