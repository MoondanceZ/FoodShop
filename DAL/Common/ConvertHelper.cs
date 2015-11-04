using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Common
{
    public class ConvertHelper<T> where T : new()
    {
        /// <summary>
        /// 利用反射和泛型  dt转换为list
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ConvertToList(DataTable dt)
        {

            // 定义集合
            List<T> ts = new List<T>();

            // 获得此模型的类型
            Type type = typeof(T);
            //定义一个临时变量
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//将属性名称赋值给临时变量
                    //检查DataTable是否包含此列（列名==对象的属性名）  
                    if (dt.Columns.Contains(tempName))
                    {
                        // 判断此属性是否有Setter
                        if (!pi.CanWrite) continue;//该属性不可写，直接跳出
                        //取值
                        object value = dr[tempName];
                        //如果非空，则赋给对象的属性
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
                //对象添加到泛型集合中
                ts.Add(t);
            }

            return ts;
        }

        /// <summary>
        /// DataReader转化为实体
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T ConvertToModel(IDataReader dr)
        {
            T model = new T();
            int count = dr.FieldCount;

            PropertyInfo[] property_lst = model.GetType().GetProperties();
            foreach (PropertyInfo property in property_lst)
            {
                for (int i = 0; i < count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))//判断值是否为空
                    {
                        string name = dr.GetName(i).ToUpper();//字段名
                        if (name.Equals(property.Name.ToUpper()))//判断字段名是否和model里的相等
                        {
                            try
                            {
                                property.SetValue(model, dr.GetValue(i), null);//为model赋值
                                break;
                            }
                            catch { }
                        }
                    }
                }
            }
            return model;
        }
    }
}
