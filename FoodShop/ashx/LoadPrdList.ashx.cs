using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FoodShop.ashx
{
    /// <summary>
    /// LoadPrdList 的摘要说明
    /// </summary>
    public class LoadPrdList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string prdType = context.Request["prdType"];
            string orderBy = context.Request["orderBy"];
            string AscOrDesc = context.Request["AscOrDesc"];
            int pageSize = int.Parse(context.Request["pageSize"]);
            int pageIndex = 1;
            int total = 0;

            List<MODEL.Product> ListPrd = BLL.ProductManager.GetPrdList(prdType, orderBy, AscOrDesc, pageIndex, pageSize, out total);
            context.Response.ContentType = "text/plain";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListPrd.Count; i++)
            {
                sb.Append(@"<div class='grid_3 product'>
                                <div class='prev'>
                                    <a href='product_page.html'>");
                sb.AppendFormat(@"<img src='../images/{0}' alt='' title='' /></a>", ListPrd[i].MainImg);
                sb.Append(@" </div>
                         <!-- .prev -->");
                sb.AppendFormat(@"<h3 class='title'>{0}</h3>", ListPrd[i].PrdName);
                sb.Append(@" <div class='cart'>
                                <div class='price'>
                                    <div class='vert'>");
                sb.AppendFormat(@"<div class='price_new'>￥{0}</div>", ListPrd[i].NewPrice);
                if (ListPrd[i].OldPrice != 0 || ListPrd[i].OldPrice > ListPrd[i].NewPrice)
                {
                    sb.AppendFormat(@"<div class='price_old'>￥{0}</div>", ListPrd[i].OldPrice);
                }

                sb.AppendFormat(@"</div>
                                </div>
                                <a href='#' class='obn'></a>
                                <a href='#' class='like'></a>
                                <a href='javascript:void(0)' prdno='{0}' class='bay'></a>
                              </div>
                                <!-- .cart -->
                        </div>
                        <!--grid_3_product-->", ListPrd[i].PrdNo);                
            }
            context.Response.Write(sb.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}