using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JD.BookOA.Model;
using JD.BookOA.Model.SearchParam;
using JD.BookOA.IBLL;

namespace JD.BookOA.BLL
{
    public partial class MessageService:BaseService<Message>,IMessageService
    {
        public IQueryable<Message> LoadSearchEntities(MessageParam MessageParam)
        {
            var temp = this.GetCurrentDbSession.MessageDal.LoadEutities(c => c.Id > 0);
            if (!string.IsNullOrEmpty(MessageParam.OrderNum))
            {
                temp = temp.Where<Message>(c => c.OrderNum.Contains(MessageParam.OrderNum));
            }
            if (!string.IsNullOrEmpty(MessageParam.MemberId))
            {
                temp = temp.Where<Message>(c => c.MemberId.Contains(MessageParam.MemberId));
            }
            if (!string.IsNullOrEmpty(MessageParam.Reply))
            {
                bool a = bool.Parse(MessageParam.Reply);
                temp = temp.Where<Message>(c => c.Reply == a);
            }
            MessageParam.totalCount = temp.Count();
            return temp.OrderBy<Message, int>(u => u.Id).Skip<Message>((MessageParam.pageIndex - 1) * MessageParam.pageSize).Take<Message>(MessageParam.pageSize);//排序分页
        }
    }
}
