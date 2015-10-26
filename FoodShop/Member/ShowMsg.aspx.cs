using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodShop.Member
{    
    public partial class ShowMsg : System.Web.UI.Page
    {
        public string userName;
        public string urlName;
        public string url;
        protected void Page_Load(object sender, EventArgs e)
        {
            url = Request.QueryString["url"] ?? "Index.aspx";
            urlName = Request.QueryString["urlName"] ?? "首页";
            userName = Request.QueryString["userName"];

        }
    }
}