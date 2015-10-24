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
        public bool login;
        protected void Page_Load(object sender, EventArgs e)
        {
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
                login = BLL.UserManager.AddUser(user);
                if (login)
                {
                    //Thread.Sleep(5000);
                    Response.Redirect("Index.aspx");
                }
            }
        }
    }
}