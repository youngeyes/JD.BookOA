using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JD.BookOA.Model;
using JD.BookOA.Model.SearchParam;
using JD.BookOA.IBLL;

namespace JD.BookOA.BLL
{
    public partial class MemberService:BaseService<Member>,IMemberService
    {
        public IQueryable<Member> LoadSearchEntities(MemberParam MemberParam)
        {
            var temp = this.GetCurrentDbSession.MemberDal.LoadEutities(c => c.Id > 0);
            if (!string.IsNullOrEmpty(MemberParam.MemberId))
            {
                temp = temp.Where<Member>(c => c.MemberId.Contains(MemberParam.MemberId));
            }
            if (!string.IsNullOrEmpty(MemberParam.EMail))
            {
                temp = temp.Where<Member>(c => c.EMail.Contains(MemberParam.EMail));
            }
            if (!string.IsNullOrEmpty(MemberParam.Tell))
            {
                long tell = long.Parse(MemberParam.Tell);
                temp = temp.Where<Member>(c => c.Tell == tell);
            }
            if (!string.IsNullOrEmpty(MemberParam.Sex))
            {
                bool sex = bool.Parse(MemberParam.Sex);
                temp = temp.Where<Member>(c => c.Sex == sex);
            }
            if (!string.IsNullOrEmpty(MemberParam.Registertime1))
            {
                DateTime time1 = DateTime.Parse(MemberParam.Registertime1);
                temp = temp.Where<Member>(c => c.Registertime >= time1);
            }
            if (!string.IsNullOrEmpty(MemberParam.Registertime2))
            {
                DateTime time2 = DateTime.Parse(MemberParam.Registertime2);
                temp = temp.Where<Member>(c => c.Registertime <= time2);
            }
            MemberParam.totalCount = temp.Count();
            return temp.OrderBy<Member, int>(u => u.Id).Skip<Member>((MemberParam.pageIndex - 1) * MemberParam.pageSize).Take<Member>(MemberParam.pageSize);//排序分页
        }
    }
}
