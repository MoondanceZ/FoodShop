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
        protected void Page_Load(object sender, EventArgs e)
        {
            userName = Request.QueryString["userName"];
        }
    }
}