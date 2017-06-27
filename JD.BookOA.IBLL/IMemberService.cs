using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JD.BookOA.Model;
using JD.BookOA.Model.SearchParam;

namespace JD.BookOA.IBLL
{
    public partial interface IMemberService:IBaseService<Member>
    {
        IQueryable<Member> LoadSearchEntities(MemberParam MemberParam);
    }
}
