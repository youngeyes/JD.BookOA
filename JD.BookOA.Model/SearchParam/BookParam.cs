using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JD.BookOA.Model.SearchParam
{
    public class BookParam:BaseParam
    {
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Press { get; set; }
        public string Presstime1 { get; set; }
        public string Presstime2 { get; set; }
        public string ISBN { get; set; }
        public string NewPrice { get; set; }
        public string ParentId { get; set; }
        public string ChildId { get; set; }
        public string Stock { get; set; }
        public string Reserve11 { get; set; }
        public string Reserve12 { get; set; }
        public string SearchParam { get; set; }
    }
}
