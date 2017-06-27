using JD.BookOA.DAL;
using JD.BookOA.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace JD.BookOA.DALFactory
{
    /// <summary>
    /// 工厂类，数据会话，创建数据操作类的实例，将业务层和数据层解耦
    /// </summary>
    public partial class DBSession : IDBSession
    {
        public DbContext Db
        {
            get
            {
                return DbContextFactory.CreateDbContext();

            }
        }

        public bool SaveChanges()
        {

            return Db.SaveChanges() > 0;
        }
    }
}
