using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JD.BookOA.IDAL
{
    public partial interface IDBSession
    {
        bool SaveChanges();
    }
}
