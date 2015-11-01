using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FoodShop.Common
{
    public class LoadPager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageSize">一页多少条</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="totalCount">总条数</param>
        /// <returns></returns>
        public static string ShowPageNavigate(int pageIndex, int pageSize, int totalCount)
        {
            string redirectTo = "";
            pageSize = pageSize == 0 ? 6 : pageSize;
            var totalPages = Math.Max((totalCount + pageSize - 1) / pageSize, 1); //总页数
            var output = new StringBuilder();
            output.Append(" <div class='pagination'> ");
            output.Append(" <ul> ");
            output.AppendFormat(" <li class='prev'><a href='{0}?pageIndex={1}&pageSize={2}'>&#8592;</a></li> ", redirectTo, pageIndex - 1, pageSize);
            if (totalPages > 1)
            {
                //if (pageIndex != 1)
                //{//处理首页连接
                //    output.AppendFormat("<li><a href='{0}?pageIndex=1&pageSize={1}'>首页</a></li> ", redirectTo, pageSize);
                //}
                output.AppendFormat("<li><a href='{0}?pageIndex=1&pageSize={1}'>首页</a></li> ", redirectTo, pageSize);
                //if (pageIndex > 1)
                //{//处理上一页的连接
                //    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>上一页</a> ", redirectTo, pageIndex - 1, pageSize);
                //}
                //else
                //{
                //    // output.Append("<span class='pageLink'>上一页</span>");
                //}

                output.Append(" ");
                int currint = 4;
                for (int i = 0; i <= 8; i++)
                {//一共最多显示8个页码，前面4个，后面4个
                    if ((pageIndex + i - currint) >= 1 && (pageIndex + i - currint) <= totalPages)
                    {
                        if (currint == i)
                        {//当前页处理
                            //output.Append(string.Format("[{0}]", currentPage));
                            output.AppendFormat("<li class='curent'><a href='{0}?pageIndex={1}&pageSize={2}'>{3}</a></li> ", redirectTo, pageIndex, pageSize, pageIndex);
                        }
                        else if (pageIndex + i - currint != totalPages)
                        {//一般页处理
                            output.AppendFormat("<li><a href='{0}?pageIndex={1}&pageSize={2}'>{3}</a></li> ", redirectTo, pageIndex + i - currint, pageSize, pageIndex + i - currint);
                        }
                    }
                    output.Append(" ");
                }
                //if (pageIndex < totalPages)
                //{//处理下一页的链接
                //    output.AppendFormat("<li><a href='{0}?pageIndex={1}&pageSize={2}'>下一页</a><li> ", redirectTo, pageIndex + 1, pageSize);
                //}
                //else
                //{
                //    //output.Append("<span class='pageLink'>下一页</span>");
                //}
                //output.Append(" ");
                if (pageIndex + currint < totalPages)
                {
                    output.Append(" <li><span>...</span></li> ");
                }
                if (pageIndex != totalPages)
                {
                    output.AppendFormat("<li><a href='{0}?pageIndex={1}&pageSize={2}'>{1}</a></li> ", redirectTo, totalPages, pageSize, totalPages);
                }
                output.Append(" ");
            }
            //output.AppendFormat("{0}", totalPages);//这个统计加不加都行
            output.AppendFormat(" <li class='next'><a href='{0}?pageIndex={1}&pageSize={2}'>&#8594;</a></li> ", redirectTo, pageIndex + 1, pageSize);
            output.Append(" </ul> ");
            output.Append(" </div> ");
            return output.ToString();
        }
    }
}