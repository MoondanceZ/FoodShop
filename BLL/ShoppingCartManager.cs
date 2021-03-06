﻿using System;
using System.Collections.Generic;
using System.Data;
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
        /// <param name="PrdNo"></param>
        /// <returns></returns>
        public static MODEL.ShoppingCart GetCart(string UserId, string PrdNo)
        {
            return DAL.ShoppingCartService.GetCart(UserId, PrdNo);
        }

        public static void UpdateCart(MODEL.ShoppingCart cart)
        {
            DAL.ShoppingCartService.UpdateCart(cart);
        }

        /// <summary>
        /// 获取用户购物车
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static List<MODEL.ShoppingCart> GetCart(string UserId)
        {
            return DAL.ShoppingCartService.ListCart(UserId);
        }

        /// <summary>
        /// 获取用户购物车
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public static DataTable GetCartDt(string UserId)
        {
            return DAL.ShoppingCartService.GetCartDt(UserId);
        }

        public static void AddCart(MODEL.ShoppingCart cart)
        {
            DAL.ShoppingCartService.AddCart(cart);
        }
    }
}
