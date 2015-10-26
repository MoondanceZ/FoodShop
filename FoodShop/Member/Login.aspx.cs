using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodShop.Member
{
    public partial class Login : System.Web.UI.Page
    {
        string urlName;
        string url;
        string userName;
        public string msg = string.Empty;
        public string returnUrl = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            url = Request.QueryString["url"] ?? "Index.aspx";
            urlName = Request.QueryString["urlName"] ?? "首页";
            userName = Request.QueryString["userName"];
            if (!string.IsNullOrEmpty(Request.Form["isPostBack"]))
            {
                CheckUserInfo();
            }
            //else//get请求时执行
            //{
            //    if (!string.IsNullOrEmpty(Request.QueryString["returnUrl"]))
            //    {
            //        returnUrl = Request.QueryString["returnUrl"];
            //    }
            //    //CheckUserCookie();
            //}
        }

        private void CheckUserCookie()
        {
            throw new NotImplementedException();
        }

        private void CheckUserInfo()
        {
            string userName = Request.Form["txtLoginId"];
            string userPassword = Request.Form["txtPwd"];
            BLL.UserManager um = new BLL.UserManager();
            msg = string.Empty;
            MODEL.User user = null;
            bool b = um.UserLogin(userName, userPassword, out msg, out user);
            if (b)
            {
                Session["userInfo"] = user;
                //判断有无回传地址
                if (!String.IsNullOrEmpty(Request.QueryString["returnUrl"]))
                {
                    Response.Redirect(Request.QueryString["returnUrl"]);
                }
                Response.Redirect("ShowMsg.aspx?urlName=" + HttpUtility.UrlEncode(urlName) + "&url=" + HttpUtility.UrlEncode(url) + "&userName=" + HttpUtility.UrlEncode(user.LoginId) + "&info=" + HttpUtility.UrlEncode("注册成功"));
            }
        }

        
    }
}