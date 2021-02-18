﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project5.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
