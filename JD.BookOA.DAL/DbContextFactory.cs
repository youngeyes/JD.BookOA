using JD.BookOA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace JD.BookOA.DAL
{
    public class DbContextFactory
    {
        /// <summary>
        /// 线程唯一，创建ef下文
        /// </summary>
        /// <returns></returns>
        public static DbContext CreateDbContext()
        {
            DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
            if (dbContext == null)//没有启动线程就new一个
            {
                dbContext = new Online_bookstoreEntities();
                CallContext.SetData("dbContext", dbContext);
            }
            return dbContext;
        }
    }
}
