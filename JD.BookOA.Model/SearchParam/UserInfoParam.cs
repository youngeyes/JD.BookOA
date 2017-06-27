using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JD.BookOA.Model.SearchParam
{
    public class UserInfoParam:BaseParam
    {
        public string UserId { get; set; }
        public string Createtime1 { get; set; }
        public string Createtime2 { get; set; }
    }
}
