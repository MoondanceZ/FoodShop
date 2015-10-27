using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserManager
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool AddUser(MODEL.User user)
        {
            return DAL.UserServices.AddUser(user);
        }

        /// <summary>
        /// 登陆校验
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <param name="msg"></param>
        /// <param name="user"></param>
        public bool UserLogin(string userName, string userPassword, out string msg, out MODEL.User user)
        {
            user = DAL.UserServices.GetModel(userName);
            if(user!=null)
            {
                if(user.UType.Id==2)
                {
                    msg="此用户已被禁用!";
                    return false;
                }
                else if(user.UType.Id==0)
                {
                    msg = "此用户已注销!";
                    return false;
                }
                else 
                {
                    if(user.PassWord==userPassword)
                    {
                        msg = "登陆成功!";
                        return true;
                    }
                    else
                    {
                        msg = "密码不正确, 请重新输入!";
                        return false;
                    }
                }
            }
            else
            {
                msg = "此用户不存在!";
                return false;
            }
        }

        public MODEL.User GetModel(string userCookieName)
        {
            MODEL.User user = DAL.UserServices.GetModel(userCookieName);
            return user;
        }
    }
}
