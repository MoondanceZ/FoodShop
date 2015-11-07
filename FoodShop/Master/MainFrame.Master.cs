using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodShop.Master
{
    public partial class MainFrame : System.Web.UI.MasterPage
    {
        public string StrCart = string.Empty;
        public MODEL.User user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["userInfo"]!=null)
            {
                user = Session["userInfo"] as MODEL.User;
            }
            StrCart = Common.LoadShoppingCart.GetCartByUser();
        }        
    }
}