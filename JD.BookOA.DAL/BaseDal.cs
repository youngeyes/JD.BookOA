using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JD.BookOA.Model;

namespace JD.BookOA.DAL
{
    public class BaseDal<T> where T : class,new()//指定泛型类型
    {
        //==========数据层操作方法 Linq ============
        DbContext Db = DbContextFactory.CreateDbContext();//调用模块线程唯一
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEutities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where<T>(whereLambda);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIdex"></param>
        /// <param name="pageSize"></param>
        /// <param name="toalCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderbyLambda"></param>
        /// <param name="isASC"></param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<s>(int pageIdex, int pageSize, out int toalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isASC)
        {
            var temp = Db.Set<T>().Where<T>(whereLambda);
            toalCount = temp.Count();
            if (isASC)
            {
                //升序
                temp = temp.OrderBy<T, s>(orderbyLambda).Skip<T>((pageIdex - 1) * pageSize).Take<T>(pageSize);

            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbyLambda).Skip<T>((pageIdex - 1) * pageSize).Take<T>(pageSize);

            }
            return temp;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.EntityState.Deleted;
            return true;//优化代码，不在重复连接数据库直接返回一个ture的标记
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool EditEnity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.EntityState.Modified;
            return true;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            Db.Set<T>().Add(entity);
            return entity;
        }
    }
}
