using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JD.BookOA.IDAL
{
    /// <summary>
    /// 公共调用方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseDal<T>where T:class,new()
    {
        IQueryable<T> LoadEutities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda);//过滤条件接口
        IQueryable<T> LoadPageEntities<s>(int pageIdex, int pageSize, out int toalCount,
            System.Linq.Expressions.Expression<Func<T, bool>> whereLambda,//先过滤，再取记录数
            System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isASC);//判断升降排序
        bool DeleteEntity(T entity);
        bool EditEnity(T entity);
        T AddEntity(T entity);
    }
}
