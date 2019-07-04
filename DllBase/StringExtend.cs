using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DllBase
{
 /// <summary>
 /// 提供string的扩展
 /// </summary>
    public static class StringExtend
    {
        //
        // 摘要:
        //     指示指定的字符串是 null 还是 System.String.Empty 字符串。
        //
        // 参数:
        //   value:
        //     要测试的字符串。
        //
        // 返回结果:
        //     如果 value 参数为 null 或空字符串 ("")，则为 true；否则为 false。
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        //
        // 摘要:
        //     指示指定的字符串是 null、空还是仅由空白字符组成。
        //
        // 参数:
        //   value:
        //     要测试的字符串。
        //
        // 返回结果:
        //     如果 value 参数为 null 或 System.String.Empty，或者如果 value 仅由空白字符组成，则为 true。
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static Int32 ToInt32(this string str)
        {
            try
            {
                //存在小数点,则去小数
                if (str.Contains('.'))
                {
                    var temp = Convert.ToDouble(str);
                    return Convert.ToInt32(temp);
                }
                else
                {
                    return Convert.ToInt32(str);
                }
            }
            catch (Exception)
            {
                return 0; 
            }                
        }

        public static short? ToInt16(this string str)
        {
            try
            {
                //存在小数点,则去小数
                if (str.Contains('.'))
                {
                    var temp = Convert.ToDouble(str);
                    return Convert.ToInt16(temp);
                }
                else
                {
                    return Convert.ToInt16(str);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static Int16 Toshort(this string str)
        {
            try
            {
                //存在小数点,则去小数
                if (str.Contains('.'))
                {
                    var temp = Convert.ToUInt32(str);
                    return Convert.ToInt16(temp);
                }
                else
                {
                    return  Convert.ToInt16(str);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static Double ToDouble(this string str)
        {
            try
            {
                return Convert.ToDouble(str);
            }
            catch (Exception)
            {

                return 0;
            }
            
        }

        public static Single ToSingle(this string str)
        {
            try
            {
                return Convert.ToSingle(str);
            }
            catch (Exception)
            {
                return 0;
            }
           
        }
        public static Boolean ToBool(this string str)
        {
            try
            {
                return Convert.ToBoolean(str);
            }
            catch (Exception)
            {

                return false;
            }
           
        } 
    }

    public static class ObjectExtend
    {
        public static string ToLog(this object o)
        {
            var temp = "                                                                       \r\n";
            try
            {
                Type t = o.GetType();//获得该类的Type
                                     //再用Type.GetProperties获得PropertyInfo[],然后就可以用foreach 遍历了
                temp += string.Format($"                                                                       Class Name:{ t.Name}\r\n");
                foreach (PropertyInfo pi in t.GetProperties())
                {
                    object value1 = pi.GetValue(o);//用pi.GetValue获得值
                    if (value1 != null)
                    {
                        string name = pi.Name;//获得属性的名字,后面就可以根据名字判断来进行些自己想要的操作
                                              //获得属性的类型,进行判断然后进行以后的操作,例如判断获得的属性是整数
                                              //if (value1.GetType() == typeof(int))
                                              //{
                                              //    //进行你想要的操作
                                              //}
                        temp += string.Format("                                                                       Property Name:{0}    Value:{1} \r\n", name, value1);
                    }                 
                }


              
                return temp;
            }
            catch (Exception e)
            {
                return "";
            }

        }
        /// <summary>
        /// 将对象属性赋值到指定类型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static T Transfer<T>(this object o) where T:new()
        {
            Type before = o.GetType();//获得该类的Type
                                 //再用Type.GetProperties获得PropertyInfo[],然后就可以用foreach 遍历了 
            T after = new T();
            foreach (PropertyInfo pi in before.GetProperties())
            {
                
                object value1 = pi.GetValue(o);//用pi.GetValue获得值
                if (value1 != null)
                {
                    string name = pi.Name;//获得属性的名字,后面就可以根据名字判断来进行些自己想要的操作
                                          //获得属性的类型,进行判断然后进行以后的操作,例如判断获得的属性是整数
                                          //if (value1.GetType() == typeof(int))
                                          //{
                                          //    //进行你想要的操作
                                          //}
                    foreach (PropertyInfo hi in typeof(T).GetProperties())
                    {
                        if (hi.Name == name)
                        {
                            hi.SetValue(after, value1, null);
                        }
                    }
                }
            }
            return after;
        }
    }
}
