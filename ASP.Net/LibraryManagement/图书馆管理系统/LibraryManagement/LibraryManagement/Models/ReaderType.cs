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
    public class ReaderType
    {
        [Key]
        public int readertypeid { get; set; }
        [DisplayName("读者类型")]
        [Required(ErrorMessage = "必须填写读者类型名称")]
        //[RegularExpression(@"^[0-9]$",ErrorMessage="请输入中文")]
        public string readertype { get; set; }
        [DisplayName("可借数量")]
        [Required(ErrorMessage = "可借数量不能为空")]

        public int number { get; set; }
    }
}