using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ShoppingCartManager
    {
       /// <summary>
       /// 根据用户名和商品编号查找购物车
       /// </summary>
       /// <param name="p"></param>
       /// <param name="PrdId"></param>
       /// <returns></returns>
        public static MODEL.ShoppingCart GetCart(string UserId, string PrdNo)
        {
            return DAL.ShoppingCartService.GetCart(UserId, PrdNo);
        }

        public static void UpdateCart(MODEL.ShoppingCart cart)
        {
            DAL.ShoppingCartService.UpdateCart(cart);
        }
    }
}
