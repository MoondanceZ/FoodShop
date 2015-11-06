using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;

namespace BLL
{
    public class ProductManager
    {
        //获取商品分页数据
        public  static List<Product> GetPagingPrd(int pageIndex, int pageSize, out int total)
        {
            return ProductService.GetPagingPrd(pageIndex, pageSize, out total);
        }

        /// <summary>
        /// 获取所有商品
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetAllProduct()
        {
            return ProductService.GetAllProduct();
        }

        /// <summary>
        /// 根据商品名称或编号获取商品
        /// </summary>
        /// <param name="prd"></param>
        /// <returns></returns>
        public static List<Product> GetPrdList(string prd)
        {
            return ProductService.GetPrdByNameOrNo(prd);
        }

        /// <summary>
        /// 根据商品名称或编号获取商品
        /// </summary>
        /// <param name="PrdNo"></param>
        /// <returns></returns>
        public static Product GetPrd(string PrdNo)
        {
            return ProductService.GetPrd(PrdNo);
        }
    }
}
