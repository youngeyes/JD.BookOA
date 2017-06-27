using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JD.BookOA.Model.SearchParam
{
    public class MemberParam:BaseParam
    {
        public string MemberId { get; set; }
        public string EMail { get; set; }
        public string Tell { get; set; }
        public string Sex { get; set; }
        public string Registertime1 { get; set; }
        public string Registertime2 { get; set; }
    }
}
