using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JD.BookOA.Model;
using JD.BookOA.IBLL;

namespace JD.BookOA.BLL
{
    public partial class ParentClassService:BaseService<ParentClass>,IParentClassService
    {
        public IQueryable<ParentClass> LoadSearchEntities(Model.SearchParam.ParentClassParam ParentClassParam)
        {
            var temp = this.GetCurrentDbSession.ParentClassDal.LoadEutities(c => c.Id > 0);
            if (!string.IsNullOrEmpty(ParentClassParam.PName))
            {
                temp = temp.Where<ParentClass>(c => c.PName.Contains(ParentClassParam.PName));
            }
            ParentClassParam.totalCount = temp.Count();
            return temp.OrderBy<ParentClass, int>(u => u.Id).Skip<ParentClass>((ParentClassParam.pageIndex - 1) * ParentClassParam.pageSize).Take<ParentClass>(ParentClassParam.pageSize);//排序分页
        }
    }
}
