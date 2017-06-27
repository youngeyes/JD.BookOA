using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JD.BookOA.Model;
using JD.BookOA.IBLL;

namespace JD.BookOA.BLL
{
    public partial class ChildClassService:BaseService<ChildClass>,IChildClassService
    {

        public IQueryable<ChildClass> LoadSearchEntities(Model.SearchParam.ChildClassParam ChildClassParam)
        {
            var temp = this.GetCurrentDbSession.ChildClassDal.LoadEutities(c => c.Id > 0);
            if (!string.IsNullOrEmpty(ChildClassParam.CName))
            {
                temp = temp.Where<ChildClass>(c => c.CName.Contains(ChildClassParam.CName));
            }
            if (!string.IsNullOrEmpty(ChildClassParam.ParentId))
            {
                int a=int.Parse(ChildClassParam.ParentId);
                temp = temp.Where<ChildClass>(c => c.ParentId == a);
            }
            ChildClassParam.totalCount = temp.Count();
            return temp.OrderBy<ChildClass, int>(u => u.Id).Skip<ChildClass>((ChildClassParam.pageIndex - 1) * ChildClassParam.pageSize).Take<ChildClass>(ChildClassParam.pageSize);//排序分页
        }
    }
}
