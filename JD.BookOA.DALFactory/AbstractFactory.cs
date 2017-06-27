using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JD.BookOA.DALFactory
{
    /// <summary>
    /// 抽象工厂:
    /// </summary>
    public partial class AbstractFactory
    {
        public static object CreateInstance(string DalAssemblyPath, string fullclassName)
        {
            var assembly = Assembly.Load(DalAssemblyPath);//加载程序集 
            return assembly.CreateInstance(fullclassName);//默认区分大小写，true不区分大小写

        }
    }
}
