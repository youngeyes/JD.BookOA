using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JD.BookOA.IBLL
{
    public interface IBaseService<T> where T:class,new()
    {
        IDAL.IDBSession GetCurrentDbSession { get; }
        IDAL.IBaseDal<T> CurrentDal { get; set; }
        IQueryable<T> LoadEutities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);
        IQueryable<T> LoadPageEntities<s>(int pageIdex, int pageSize, out int toalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isASC);
        bool DeleteEntity(T entity);
        bool EditEnity(T entity);
        T AddEntity(T entity);
        bool DeleteEntites(List<T> Idlist);
        bool DeleteEntitesWhere(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);
    }
}
