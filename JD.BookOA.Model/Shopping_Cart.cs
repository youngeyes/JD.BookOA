//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace JD.BookOA.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shopping_Cart
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Ammount { get; set; }
        public Nullable<int> MemberId { get; set; }
    
        public virtual Member Member { get; set; }
    }
}