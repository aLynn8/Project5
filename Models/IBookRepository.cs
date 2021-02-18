using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Aubrey Farnbach Section 2 Group 1

namespace Project5.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
