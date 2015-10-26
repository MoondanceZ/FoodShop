using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShop.Common
{
    public class BaseCheckSession:System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if(Session["userInfo"]==null)
            {
                WebCommon.GoIndexPage();
            }
            base.OnInit(e);
        }
    }
}