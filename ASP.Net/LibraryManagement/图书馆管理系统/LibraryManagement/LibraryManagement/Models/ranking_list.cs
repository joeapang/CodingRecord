using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class ranking_list
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Reader> Readers { get; set; }
    }
}