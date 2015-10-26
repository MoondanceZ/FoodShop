using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodShop.Member
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.QueryString["url"] ?? "Index.aspx";
            string urlName = Request.QueryString["urlName"] ?? "首页";
            if (IsPostBack)
            {
                MODEL.User user = new MODEL.User();
                user.LoginId = Request.Form["txtName"].ToString();
                user.PassWord = Request.Form["txtPwd"].ToString();
                user.Guid = System.Guid.NewGuid().ToString();
                user.Telephone = Request.Form["txtTel"].ToString();
                user.Email = Request.Form["txtEmail"].ToString();
                user.RegTime = DateTime.Now;
                MODEL.UType uType = new MODEL.UType(1);
                user.UType = uType;
                if (BLL.UserManager.AddUser(user))
                {
                    if (!String.IsNullOrEmpty(url))
                    {
                        Response.Redirect("ShowMsg.aspx?uid=" + HttpUtility.UrlEncode(user.LoginId) + "&info" + HttpUtility.UrlEncode("注册成功"));
                    }
                    else
                    {
                        Response.Redirect("ShowMsg.aspx?url=" + HttpUtility.UrlEncode(url) + "&urlName=" + HttpUtility.UrlEncode(urlName) + "&uerName=" + HttpUtility.UrlEncode(user.LoginId) + "&info=" + HttpUtility.UrlEncode("注册成功"));
                    }
                }
            }
        }
    }
}