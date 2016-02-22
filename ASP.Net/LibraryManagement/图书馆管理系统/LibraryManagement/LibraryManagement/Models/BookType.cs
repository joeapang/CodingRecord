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
    public class BookType
    {
        [Key]
        public int booktypeid { get; set; }
        [DisplayName("图书类型名称")]
        [Required(ErrorMessage = "必须填写图书类型名称")]
        [RegularExpression(@"^([\u4e00-\u9fa5]+|[a-zA-Z0-9]+)$", ErrorMessage = "图书类型格式错误")]
        public string typename { get; set; }
        [DisplayName("可借天数")]
        [Required(ErrorMessage = "必须填写可借天数")]
        [RegularExpression(@"^[0-9]*$",ErrorMessage="天数为正整数")]
        public int days { get; set; }
    }
}