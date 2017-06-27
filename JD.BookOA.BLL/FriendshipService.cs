using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JD.BookOA.Model;
using JD.BookOA.IBLL;

namespace JD.BookOA.BLL
{
    public partial class FriendshipService:BaseService<Friendship>,IFriendshipService
    {
        public IQueryable<Friendship> LoadSearchEntities(Model.SearchParam.FriendshipParam FriendshipParam)
        {
            var temp = this.GetCurrentDbSession.FriendshipDal.LoadEutities(c => c.Id > 0);
            if (!string.IsNullOrEmpty(FriendshipParam.FriendshipMsg))
            {
                temp = temp.Where<Friendship>(c => c.FriendshipMsg.Contains(FriendshipParam.FriendshipMsg));
            }
            if (!string.IsNullOrEmpty(FriendshipParam.FriendshipClass))
            {
                int a = int.Parse(FriendshipParam.FriendshipClass);
                temp = temp.Where<Friendship>(c => c.FriendshipClass == a);
            }
            FriendshipParam.totalCount = temp.Count();
            return temp.OrderBy<Friendship, int>(u => u.Id).Skip<Friendship>((FriendshipParam.pageIndex - 1) * FriendshipParam.pageSize).Take<Friendship>(FriendshipParam.pageSize);//排序分页
        }
    }
}
