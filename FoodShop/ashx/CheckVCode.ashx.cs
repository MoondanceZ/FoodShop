using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace FoodShop.ashx
{
    /// <summary>
    /// CheckVCode 的摘要说明
    /// </summary>
    public class CheckVCode : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string vCode = context.Request["vCode"] ?? "";
            context.Response.ContentType = "text/plain";
            if (HttpContext.Current.Session["vCode"] != null)
            {
                string sysCode = HttpContext.Current.Session["vCode"].ToString();
                if (sysCode.Equals(vCode, StringComparison.InvariantCultureIgnoreCase))
                {
                    HttpContext.Current.Session["vCode"] = null;
                    context.Response.Write("OK");
                }
                else
                {
                    context.Response.Write("Error");
                }
            }             
            else
            {
                context.Response.Write("Error");
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