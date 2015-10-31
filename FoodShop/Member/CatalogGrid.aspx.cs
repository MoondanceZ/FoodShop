using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodShop.Member
{
    public partial class CatalogGrid : System.Web.UI.Page
    {
        protected List<MODEL.Product> listPrd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listPrd = BLL.ProductManage.GetAllProduct();
            }
        }
    }
}