using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class ProductStore
    {
        public int Id { get; set; }
        //商品批次
        public string PrdBatch { get; set; }
        //商品编号
        public string PrdNo { get; set; }
        //商品名称
        public string PrdName { get; set; }
        //入库时间
        public DateTime InstoreTime { get; set; }
        //总数
        public decimal TotalQuantity { get; set; }
        //当前数量
        public decimal NowQuatity { get; set; }
    }
}
