using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JD.BookOA.Model.SearchParam
{
    public class ChildClassParam:BaseParam
    {
        public string CName { get; set; }
        public string ParentId { get; set; }
    }
}
