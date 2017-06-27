using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JD.BookOA.Model.SearchParam
{
    public class MessageParam:BaseParam
    {
        public string OrderNum { get; set; }
        public string MemberId { get; set; }
        public string Reply { get; set; }
    }
}
