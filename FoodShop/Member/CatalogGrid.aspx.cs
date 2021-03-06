﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodShop.Member
{
    public partial class CatalogGrid : System.Web.UI.Page
    {
        protected List<MODEL.Product> ListPrd;
        protected void Page_Load(object sender, EventArgs e)
        {
            int pageIndex = int.Parse(Request["pageIndex"] ?? "1");
            int pageSize = int.Parse(Request["pageSize"] ?? "6");
            string prdType = Request["prdType"] ?? "0";
            string AscOrDesc = Request["AscOrDesc"] ?? "ASC";
            string orderBy = Request["orderBy"] ?? "prdName";

            int total = 0;
            if (!IsPostBack)
            {
                ListPrd = BLL.ProductManager.GetPrdList(prdType, orderBy, AscOrDesc, pageIndex, pageSize, out total);
            }
            //this.NavStrHtml.Text = Common.LoadPager.ShowPageNavigate(pageIndex, pageSize, total);
            this.NavStrHtml.Text = Common.PageBar.ShowPageNavigate(prdType, orderBy, AscOrDesc, pageIndex, pageSize, total);
        }         
    }
}