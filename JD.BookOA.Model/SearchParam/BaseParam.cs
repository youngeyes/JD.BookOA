using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JD.BookOA.Model.SearchParam
{
    public class BaseParam
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
    }
}
