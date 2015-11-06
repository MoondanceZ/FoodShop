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
        /// <param name="PrdNo"></param>
        public static List<MODEL.ShoppingCart> ListCart(string UserId)
        {
            string sql = @"SELECT * FROM shoppingCart where userId=@userId settleStt=0 ";
            SqlParameter[] parameter = { new SqlParameter("@userId", UserId) };
            return Common.ConvertHelper<MODEL.ShoppingCart>.ConvertToList(DBHelper.ExecuteDatable(sql, CommandType.Text, parameter));
        }

        /// <summary>
        /// 根据用户名找购物车
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="PrdNo"></param>
        public static DataTable GetCartDt(string UserId)
        {
            string sql = @"SELECT s.*,p.mainImg,p.newPrice AS prdPrice  FROM shoppingCart  s JOIN Product p on s.prdNo=p.prdNo  where userId=@userId and settleStt=0 ";
            SqlParameter[] parameter = { new SqlParameter("@userId", UserId) };
            return DBHelper.ExecuteDatable(sql, CommandType.Text, parameter);
        }
        /// <summary>
        /// 根据用户名和编号查找购物车
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="PrdNo"></param>
        public static MODEL.ShoppingCart GetCart(string UserId, string PrdNo)
        {
            string sql = @"SELECT * FROM shoppingCart where userId=@userId and prdNo=@PrdNo and settleStt=0 ";
            SqlParameter[] parameter = { new SqlParameter("@userId", UserId), new SqlParameter("@PrdNo", PrdNo) };
            SqlDataReader reader = DBHelper.ExecuteReader(sql, CommandType.Text, parameter);
            if (reader.Read())
            {
                return Common.ConvertHelper<MODEL.ShoppingCart>.ConvertToModel(reader);
            }
            else
            {
                return null;
            }
        }

        public static void UpdateCart(MODEL.ShoppingCart cart)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update shoppingCart set ");
            strSql.Append("userId=@userId,");
            strSql.Append("prdNo=@prdNo,");
            strSql.Append("prdName=@prdName,");
            //strSql.Append("prdPrice=@prdPrice,");
            strSql.Append("prdQty=@prdQty, ");
            strSql.Append("settleStt=@settleStt ");

            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int),
                    new SqlParameter("@userId", SqlDbType.VarChar),
					new SqlParameter("@prdNo", SqlDbType.VarChar),
					new SqlParameter("@prdName", SqlDbType.VarChar),
                    //new SqlParameter("@prdPrice", SqlDbType.VarChar),
					new SqlParameter("@prdQty", SqlDbType.VarChar),
					new SqlParameter("@settleStt", SqlDbType.Int)};

            parameters[0].Value = cart.Id;
            parameters[1].Value = cart.UserId;
            parameters[2].Value = cart.PrdNo;
            parameters[3].Value = cart.PrdName;
            //parameters[4].Value = cart.PrdPrice;
            parameters[4].Value = cart.PrdQty;
            parameters[5].Value = cart.SettleStt;

            DBHelper.ExecuteNonQuery(strSql.ToString(), CommandType.Text, parameters);
        }

        public static void AddCart(MODEL.ShoppingCart cart)
        {
            string sql = @"INSERT INTO dbo.shoppingCart
                        ( userId ,
                          prdNo ,
                          prdName ,
                          prdQty ,
                          settleStt
                        )
                VALUES  ( @userId , -- userId - varchar(50)
                          @prdNo , -- prdNo - varchar(50)
                          @prdName , -- prdName - varchar(200)
                          @prdQty , -- prdQty - int
                          0  -- settleStt - int
                        )";
            SqlParameter[] parameter = new SqlParameter[4];
            parameter[0] = new SqlParameter("@userId", cart.UserId);
            parameter[1] = new SqlParameter("@prdNo", cart.PrdNo);
            parameter[2] = new SqlParameter("@prdName", cart.PrdName);
            parameter[3] = new SqlParameter("@prdQty", cart.PrdQty);
            DBHelper.ExecuteNonQuery(sql, CommandType.Text, parameter);
        }
    }
}
