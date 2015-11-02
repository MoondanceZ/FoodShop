using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FoodShop.Common
{
    public class PageBar
    {
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
                int startPage = pageIndex - 4;
                if (startPage < 1)
                {
                    startPage = 1;
                }
                else if (startPage > 1)
                {
                    output.AppendFormat("<li><a href='{0}?pageIndex=1&pageSize={1}'>首页</a></li> ", redirectTo, pageSize);
                    output.Append(" ");
                }
                int endPage = startPage + 7;
                if (endPage > totalPages)
                {
                    endPage = totalPages;
                    startPage = endPage - 7 > 0 ? endPage - 7 : 1;
                }

                for (int i = startPage; i <= endPage; i++)
                {
                    if (i == pageIndex)  //如果是当前页码
                    {
                        output.AppendFormat("<li class='curent'><a href='{0}?pageIndex={1}&pageSize={2}'>{3}</a></li> ", redirectTo, pageIndex, pageSize, pageIndex);
                    }                   
                    else
                    {
                        output.AppendFormat("<li><a href='{0}?pageIndex={1}&pageSize={2}'>{3}</a></li> ", redirectTo, i, pageSize, i);
                    }
                    output.Append(" ");
                }
  
                if (endPage < totalPages)
                {
                    output.AppendFormat("<li><a href='{0}?pageIndex={1}&pageSize={2}'>尾页</a></li> ", redirectTo, totalPages, pageSize, totalPages);
                }               
                output.Append(" ");
            }            
            output.AppendFormat(" <li class='next'><a href='{0}?pageIndex={1}&pageSize={2}'>&#8594;</a></li> ", redirectTo, pageIndex + 1, pageSize);
            output.Append(" </ul> ");
            output.Append(" </div> ");
            return output.ToString();
        }
    }
}