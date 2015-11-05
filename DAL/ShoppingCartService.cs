using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ShoppingCartService
    {
        /// <summary>
        /// 根据用户名找购物车
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="PrdId"></param>
        public static List<MODEL.ShoppingCart> ListCart(string UserId)
        {
            string sql = "@SELECT * FROM shoppingCart where userId=@userId settleStt=0 ";
            SqlParameter[] parameter = { new SqlParameter("@userId", UserId) };
            return Common.ConvertHelper<MODEL.ShoppingCart>.ConvertToList(DBHelper.ExecuteDatable(sql, CommandType.Text, parameter));
        }
        /// <summary>
        /// 根据用户名和编号查找购物车
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="PrdId"></param>
        public static MODEL.ShoppingCart GetCart(string UserId, string PrdNo)
        {
            string sql = "@SELECT * FROM shoppingCart where userId=@userId and prdNo=@prdNo settleStt=0 ";
            SqlParameter[] parameter = { new SqlParameter("@userId", UserId), new SqlParameter("@prdNo", PrdNo) };
            return Common.ConvertHelper<MODEL.ShoppingCart>.ConvertToModel(DBHelper.ExecuteReader(sql, CommandType.Text, parameter));
        }

        public static void UpdateCart(MODEL.ShoppingCart cart)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update shoppingCart set ");
            strSql.Append("userId=@userId,");
            strSql.Append("prdNo=@prdNo,");
            strSql.Append("prdName=@prdName,");
            strSql.Append("prdQty=@prdQty ");
            strSql.Append("settleStt=@settleStt ");

            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int),
                    new SqlParameter("@userId", SqlDbType.VarChar),
					new SqlParameter("@prdNo", SqlDbType.VarChar),
					new SqlParameter("@prdName", SqlDbType.VarChar),
					new SqlParameter("@prdQty", SqlDbType.VarChar),
					new SqlParameter("@settleStt", SqlDbType.Int)};

            parameters[0].Value = cart.Id;
            parameters[1].Value = cart.UserId;
            parameters[2].Value = cart.PrdNo;
            parameters[3].Value = cart.PrdName;
            parameters[4].Value = cart.PrdQty;
            parameters[5].Value = cart.SettleStt;

            DBHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
        }
    }
}
