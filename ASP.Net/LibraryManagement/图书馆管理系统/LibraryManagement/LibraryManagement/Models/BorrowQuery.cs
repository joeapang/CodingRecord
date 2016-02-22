using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class BorrowQuery
    {
        public string queryconditions { get; set; }
        public string importqueryconditions { get; set; }
        public virtual IEnumerable<BorrowBook> BorrowBooks { get; set; }
    }
}