using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JD.BookOA.Model.SearchParam
{
    public class OrdersParam:BaseParam
    {
        public string OrderNum { get; set; }
        public string Stat { get; set; }
        public string Createtime1 { get; set; }
        public string Createtime2 { get; set; }
        public string IsDilivery { get; set; }
    }
}
