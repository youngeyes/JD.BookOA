using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JD.BookOA.Model.Enum
{
    public enum DEFEnum //枚举,规定删除标记
    {
        Normal = 0,
        LDel = 1,
        PDel = 2
    }
    public enum SexEnum//性别枚举
    {
        male = 0,
        female = 1
    }
    public enum UidcEnum
    {
        st = 0,
        tech = 1,
        admin = 2,
        sh = 3

    }
    public enum LendingEnum
    {
        Lengding = 0,
        Reserve = 1,
        Return = 2
    }
}
