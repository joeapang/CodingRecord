using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class BorrowBackBook
    {

        public IEnumerable<BorrowBook> IEBorrowBook { get; set; }
        public virtual Reader Readers { get; set; }
        public virtual IEnumerable<Book> Books { get; set; }
    }
}