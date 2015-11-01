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
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int pageSize = int.Parse(Request["pageSize"] ?? "6");
            int total = 0;
            if (!IsPostBack)
            {
                //listPrd = BLL.ProductManage.GetAllProduct();
                listPrd = BLL.ProductManage.GetPagingPrd(pageIndex, pageSize, out total);
            }
            this.NavStrHtml.Text = Common.LoadPager.ShowPageNavigate(pageIndex, pageSize, total);
        }
    }
}