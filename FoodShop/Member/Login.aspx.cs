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
            else//get请求时执行
            {
                if (!string.IsNullOrEmpty(Request.QueryString["returnUrl"]))
                {
                    returnUrl = Request.QueryString["returnUrl"];
                }
                CheckUserCookie();
            }
        }

        private void CheckUserCookie()
        {
            if(Request.Cookies["cp1"]!=null&&Request.Cookies["cp2"]!=null)
            {
                string userCookieName = Request.Cookies["cp1"].Value;
                string userCookiePass = Request.Cookies["cp2"].Value;
                BLL.UserManager um = new BLL.UserManager();
                MODEL.User user = um.GetModel(userCookieName);
                if(user!=null)
                {
                    string pwd = Common.WebCommon.GetStringMd5(user.PassWord);
                    if(pwd==userCookiePass)
                    {
                        Session["userInfo"] = user;
                        GoToPage(user);
                    }
                }
                else 
                { 
                    //TODO:情况cookie
                }
            }
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
                if (!string.IsNullOrEmpty(Request.Form["Remember_password"]))
                {
                    HttpCookie cookie1 = new HttpCookie("cp1", user.LoginId);
                    HttpCookie cookie2 = new HttpCookie("cp2", Common.WebCommon.GetStringMd5(user.PassWord));
                    cookie1.Expires = DateTime.Now.AddDays(3);
                    cookie2.Expires = DateTime.Now.AddDays(3);
                    Response.Cookies.Add(cookie1);
                    Response.Cookies.Add(cookie2);
                }
                GoToPage(user);
            }
        }

        private void GoToPage(MODEL.User user)
        {
            //判断有无回传地址
            if (!String.IsNullOrEmpty(Request.QueryString["returnUrl"]))
            {
                Response.Redirect(Request.QueryString["returnUrl"]);
            }
            Response.Redirect("ShowMsg.aspx?urlName=" + HttpUtility.UrlEncode(urlName) + "&url=" + HttpUtility.UrlEncode(url) + "&userName=" + HttpUtility.UrlEncode(user.LoginId) + "&info=" + HttpUtility.UrlEncode("注册成功"));
        }

        
    }
}