using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace JD.BookOA.DALFactory
{
    public class DBSessionFactory
    {
        /// <summary>
        /// 线程唯一，new一个dbsession
        /// </summary>
        /// <returns></returns>
        public static IDAL.IDBSession CreateDbSession()
        {
            IDAL.IDBSession DbSession = (IDAL.IDBSession)CallContext.GetData("dbSession");
            if (DbSession == null)
            {
                DbSession = new DALFactory.DBSession();
                CallContext.SetData("dbSession", DbSession);

            }
            return DbSession;
        }
    }
}
