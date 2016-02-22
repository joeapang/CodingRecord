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
    public class BookCase
    {
        [DisplayName("书架编号")]
        [Key]
        public int bookcaseid { get; set; }
        [DisplayName("书架名称")]
        [Required(ErrorMessage = "必须填写书架名称")]
        [RegularExpression(@"^[.a-zA-Z0-9\u4e00-\u9fa5]{0,25}$")]
        public string bookcasename { get; set; }
    }
}