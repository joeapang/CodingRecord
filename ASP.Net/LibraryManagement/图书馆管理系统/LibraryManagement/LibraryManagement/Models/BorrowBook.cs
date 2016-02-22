using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    [Bind(Exclude = "id")]
    public class BorrowBook
    {
        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }

        public string bookcode{get;set;}

        public string readerid{get;set;}
        [DisplayName("借阅时间")]
        public string borrowTime { get; set; }
         [DisplayName("应还时间")]
        public string ygbackTime { get; set; }
         [DisplayName("实际归还时间")]
         public string sjbackTime { get; set; }
         [DisplayName("借阅操作员")]
        public string borrowoper{get;set;}
         [DisplayName("归还操作员")]
        public string backoper { get; set; }
         [DisplayName("是否归还")]
        public bool isback { get; set; }
        public virtual Book Books { get; set; }
        public virtual Reader Readers { get; set; }
    }
}