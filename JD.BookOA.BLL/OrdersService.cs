using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JD.BookOA.Model;
using JD.BookOA.IBLL;

namespace JD.BookOA.BLL
{
    public partial class OrdersService:BaseService<Orders>,IOrdersService
    {
        public IQueryable<Orders> LoadSearchEntities(Model.SearchParam.OrdersParam OrdersParam)
        {
            var temp = this.GetCurrentDbSession.OrdersDal.LoadEutities(c => c.Id > 0);
            if (!string.IsNullOrEmpty(OrdersParam.OrderNum))
            {
                temp = temp.Where<Orders>(c => c.OrderNum.Contains(OrdersParam.OrderNum));
            }
            if (!string.IsNullOrEmpty(OrdersParam.Createtime1))
            {
                DateTime a = DateTime.Parse(OrdersParam.Createtime1);
                temp = temp.Where<Orders>(c => c.Createtime >= a);
            }
            if (!string.IsNullOrEmpty(OrdersParam.Createtime2))
            {
                DateTime a = DateTime.Parse(OrdersParam.Createtime2);
                temp = temp.Where<Orders>(c => c.Createtime <= a);
            }
            if (!string.IsNullOrEmpty(OrdersParam.Stat))
            {
                int a = int.Parse(OrdersParam.Stat);
                temp = temp.Where<Orders>(c => c.Stat == a);
            }
            if (!string.IsNullOrEmpty(OrdersParam.IsDilivery))
            {
                bool a = bool.Parse(OrdersParam.IsDilivery);
                temp = temp.Where<Orders>(c => c.IsDilivery == a);
            }
            OrdersParam.totalCount = temp.Count();
            return temp.OrderBy<Orders, int>(u => u.Id).Skip<Orders>((OrdersParam.pageIndex - 1) * OrdersParam.pageSize).Take<Orders>(OrdersParam.pageSize);//排序分页
        }
    }
}
