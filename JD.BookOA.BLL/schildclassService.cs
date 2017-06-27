using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JD.BookOA.Model;
using JD.BookOA.IBLL;

namespace JD.BookOA.BLL
{
    public partial class schildclassService:BaseService<schildclass>,IschildclassService
    {
        public IQueryable<schildclass> LoadSearchEntities(Model.SearchParam.schildclassParam schildclassParam)
        {
            var temp = this.GetCurrentDbSession.schildclassDal.LoadEutities(c => c.Id > 0);
            if (!string.IsNullOrEmpty(schildclassParam.SCName))
            {
                temp = temp.Where<schildclass>(c => c.SCName.Contains(schildclassParam.SCName));
            }
            if (!string.IsNullOrEmpty(schildclassParam.ChildId))
            {
                int a = int.Parse(schildclassParam.ChildId);
                temp = temp.Where<schildclass>(c => c.ChildId == a);
            }
            schildclassParam.totalCount = temp.Count();
            return temp.OrderBy<schildclass, int>(u => u.Id).Skip<schildclass>((schildclassParam.pageIndex - 1) * schildclassParam.pageSize).Take<schildclass>(schildclassParam.pageSize);//排序分页
        }
    }
}
