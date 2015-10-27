using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetStringMd5(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] md5Buffer = md5.ComputeHash(buffer);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in md5Buffer)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();

        }
    }
}