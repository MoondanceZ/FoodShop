using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        //用户id
        public string UserId { get; set; }
        //商品编号
        public string PrdNo { get; set; }
        //商品名称
        public string PrdName { get; set; }
        //商品数量
        public int PrdQty { get; set; }
        //是否结算
        public int SettleStt { get; set; }
    }
}
