using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UserServices
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool AddUser(MODEL.User user)
        {
            string sql = @"INSERT INTO userInfo( loginId ,passWord ,guid ,telephone ,email,regTime ,uType)
                            VALUES (@loginId,@passWord,@guid,@telephone,@email,@regTime,@utype)";
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("@loginId", user.LoginId);
            parameters[1] = new SqlParameter("@passWord", user.PassWord);
            parameters[2] = new SqlParameter("@guid", user.Guid);
            parameters[3] = new SqlParameter("@telephone", user.Telephone);
            parameters[4] = new SqlParameter("@email", user.Email);
            parameters[5] = new SqlParameter("@regTime", user.RegTime);
            parameters[6] = new SqlParameter("@utype", user.UType.Id);
            return DBHelper.ExecuteNonQuery(sql, CommandType.Text, parameters) > 0 ? true : false;
        }

        /// <summary>
        /// 根据用户名获取用户实体
        /// </summary>
        /// <param name="userName"></param>
        public static MODEL.User GetModel(string userName)
        {
            MODEL.User user = null;
            string sql = @"select * from userInfo join uType on userInfo.uType = uType.id where loginId=@userName";
            using (SqlDataReader sda = DBHelper.ExecuteReader(sql, System.Data.CommandType.Text, new SqlParameter("@userName", userName)))
            {
                if (sda.HasRows)
                    if (sda.Read())
                    {
                        user = new MODEL.User();
                        user.Id = sda.GetInt32(0);
                        user.LoginId = sda.GetString(1);
                        user.PassWord = sda.GetString(2);
                        user.Guid = sda.GetString(3);
                        user.Telephone = sda.GetString(4);
                        user.Email = sda.GetString(5);
                        user.RegTime = sda.GetDateTime(6);
                        MODEL.UType uType = new MODEL.UType();
                        uType.Id = sda.GetInt32(7);
                        uType.Name = sda.GetString(9);
                        user.UType = uType;
                    }
            }
            return user;
        }
    }
}
