using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ProductService
    {
        /// <summary>
        /// 获取商品分页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public static List<Product> GetPagingPrd(int pageIndex, int pageSize, out int total)
        {
            DataTable dt = new DataTable();
            SqlParameter[] parameter = new SqlParameter[3];
            parameter[0] = new SqlParameter("@pageIndex", pageIndex);
            parameter[1] = new SqlParameter("@pageSize", pageSize);
            SqlParameter totalParameter = new SqlParameter("@total", SqlDbType.Int);
            totalParameter.Direction = ParameterDirection.Output;
            parameter[2] = totalParameter;
            dt = DBHelper.ExecuteDatable("P_loadPrdPageData", CommandType.StoredProcedure, parameter);
            total = (int)totalParameter.Value;
            List<Product> pagePrd = Common.ConvertHelper<Product>.ConvertToList(dt);
            return pagePrd;
        }

        /// <summary>
        /// 根据编号和名称获取商品
        /// </summary>
        /// <param name="prd"></param>
        /// <returns></returns>
        public static List<Product> GetPrdByNameOrNo(string prd)
        {
            string sql = @"select * from PRODUCT WHERE PRDNO LIKE '%@prd%' ORD PRDNAME like '%@prd%' and prdStation=1 ";
            DataTable dt = DBHelper.ExecuteDatable(sql, CommandType.Text, new SqlParameter("@prd", prd));            
            if (dt.Rows.Count > 0)
            {
                return Common.ConvertHelper<Product>.ConvertToList(dt);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据编号和名称获取商品
        /// </summary>
        /// <param name="PrdNo"></param>
        /// <returns></returns>
        public static Product GetPrd(string PrdNo)
        {
            string sql = @"select * from PRODUCT WHERE prdNo = @PrdNo and prdStation=1 ";
            SqlDataReader dr = DBHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter("@PrdNo",PrdNo));
            if (dr.Read())  //读取下一条数据
            {
                Product product = Common.ConvertHelper<Product>.ConvertToModel(dr);
                return product;
            }
            else
                return null;
        }

        /// <summary>
        /// 查询所以商品
        /// </summary>
        /// <returns></returns>
        public static List<Product> GetAllProduct()
        {
            string sql = @"select * from PRODUCT WHERE prdStation=1 ";
            DataTable dt = DBHelper.ExecuteDatable(sql, CommandType.Text);
            if (dt.Rows.Count > 0)
            {
                return Common.ConvertHelper<Product>.ConvertToList(dt);
            }
            else
            {
                return null;
            }
        }
    }
}
