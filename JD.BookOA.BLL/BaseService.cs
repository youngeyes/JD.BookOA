using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JD.BookOA.BLL
{
    public abstract class BaseService<T> where T:class,new()
    {
        public IDAL.IDBSession GetCurrentDbSession
        {
            get
            {
                return DALFactory.DBSessionFactory.CreateDbSession();
            }
        }
        public IDAL.IBaseDal<T> CurrentDal { get; set; }
        public abstract void SetCurretenDal();
        public BaseService()
        {
            SetCurretenDal();
        }
        //============表现层控制器调用以下操作数据方法==============//
        public IQueryable<T> LoadEutities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            return CurrentDal.LoadEutities(whereLambda);

        }
        public IQueryable<T> LoadPageEntities<s>(int pageIdex, int pageSize, out int toalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isASC)
        {
            return CurrentDal.LoadPageEntities<s>(pageIdex, pageSize, out toalCount, whereLambda, orderbyLambda, isASC);
        }
        public bool DeleteEntity(T entity)
        {
            CurrentDal.DeleteEntity(entity);
            return this.GetCurrentDbSession.SaveChanges();
        }
        public bool EditEnity(T entity)
        {
            CurrentDal.EditEnity(entity);
            return this.GetCurrentDbSession.SaveChanges();
        }
        public T AddEntity(T entity)
        {
            CurrentDal.AddEntity(entity);
            this.GetCurrentDbSession.SaveChanges();
            return entity;

        }
        public bool DeleteEntites(List<T> Idlist)
        {
            foreach (var item in Idlist)
            {
                CurrentDal.DeleteEntity(item);
            }
            return this.GetCurrentDbSession.SaveChanges();
        }
        public bool DeleteEntitesWhere(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
        {
            var temp = CurrentDal.LoadEutities(whereLambda);
            foreach (var item in temp)
            {

                CurrentDal.DeleteEntity(item);
            }
            return this.GetCurrentDbSession.SaveChanges();
        }
    }
}
