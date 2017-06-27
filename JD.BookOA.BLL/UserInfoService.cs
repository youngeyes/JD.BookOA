using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JD.BookOA.Model;
using JD.BookOA.IBLL;
namespace JD.BookOA.BLL
{
    public partial class UserInfoService:BaseService<UserInfo>,IUserInfoService
    {
        public IQueryable<UserInfo> LoadSearchEntities(Model.SearchParam.UserInfoParam UserInfoParam)
        {
            var temp = this.GetCurrentDbSession.UserInfoDal.LoadEutities(c => c.Id > 0);
            if (!string.IsNullOrEmpty(UserInfoParam.UserId))
            {
                temp = temp.Where<UserInfo>(c => c.UserId.Contains(UserInfoParam.UserId));
            }
            if (!string.IsNullOrEmpty(UserInfoParam.Createtime1))
            {
                DateTime time1 = DateTime.Parse(UserInfoParam.Createtime1);
                temp = temp.Where<UserInfo>(c => c.Createtime >= time1);
            }
            if (!string.IsNullOrEmpty(UserInfoParam.Createtime2))
            {
                DateTime time2 = DateTime.Parse(UserInfoParam.Createtime2);
                temp = temp.Where<UserInfo>(c => c.Createtime <= time2);
            }
            UserInfoParam.totalCount = temp.Count();
            return temp.OrderBy<UserInfo, int>(u => u.Id).Skip<UserInfo>((UserInfoParam.pageIndex - 1) * UserInfoParam.pageSize).Take<UserInfo>(UserInfoParam.pageSize);//排序分页
        }
    }
}
