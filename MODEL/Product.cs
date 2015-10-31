using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Product
    {
        public int Id { get; set; }
        //商品编号
        public string PrdNo { get; set; }
        //商品名称
        public string PrdName { get; set; }
        //商品介绍
        public string Introduction { get; set; }
        //商品详细介绍
        public string ProductDetail { get; set; }
        //商品状态
        public int PrdStation { get; set; }
        //商品图片
        public string PrdImg { get; set; }
        //主要图片
        public string MainImg { get; set; }
        //旧价格
        public decimal? OldPrice { get; set; }
        //最新价格
        public decimal NewPrice { get; set; }
        //商品总类
        public int PrdType { get; set; }
        //商品评价
        public decimal AssignMark { get; set; }
        //是否被收藏        
    }
}
