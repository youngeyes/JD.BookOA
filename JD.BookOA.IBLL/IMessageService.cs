﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JD.BookOA.Model;
using JD.BookOA.Model.SearchParam;

namespace JD.BookOA.IBLL
{
    public partial interface IMessageService:IBaseService<Message>
    {
        IQueryable<Message> LoadSearchEntities(MessageParam MessageParam);
    }
}
