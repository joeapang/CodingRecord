using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace LibraryManagement.Models
{
    public class Book
    {
        [Key]
        [DisplayName("条形码")]
        [RegularExpression(@"[1-9]{13}",ErrorMessage="请输入正确的条形码")]
        [Required(ErrorMessage = "条形码不能为空")]
        public string bookcode { get; set; }
        [DisplayName("图书名称")]
        [Required(ErrorMessage = "必须输入书名")]
        [StringLength(50)]
        [RegularExpression(@"^[.a-zA-Z0-9\u4e00-\u9fa5]{0,25}$", ErrorMessage = "书名格式错误")]
        public string bookname { get; set; }
        [DisplayName("图书类型")]
        public int booktypeid { get; set; }
        [DisplayName("作者")]
        [RegularExpression(@"^([\u4e00-\u9fa5]+|[a-zA-Z0-9]+)$", ErrorMessage = "作者格式错误")]
        public string author { get; set; }
        [DisplayName("译者")]
        [RegularExpression(@"^([\u4e00-\u9fa5]+|[a-zA-Z0-9]+)$", ErrorMessage = "译者格式错误")]
        public string translator { get; set; }
        [DisplayName("出版社")]
        [RegularExpression(@"^([\u4e00-\u9fa5]+|[a-zA-Z0-9]+)$", ErrorMessage = "出版社格式错误")]
        public string pubname { get; set; }
        [Required(ErrorMessage = "必须输入单价")]
        [Range(1, 1000.00, ErrorMessage = "单价必须在1元到1000元之间")]
        [DisplayName("价格")]
        public decimal price { get; set; }
        [DisplayName("页码")]
        public int page { get; set; }
        [DisplayName("书架")]
        public int bookcaseid { get; set; }
        [DisplayName("库存数量")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "库存不能为负数")]
        public int storage { get; set; }
        [DisplayName("入馆时间")]
        [RegularExpression(@"[0-9]{4}-(0[1-9]|1[0-2])-([0-2][0-9]|3[0-1])", ErrorMessage = "时间无效")]

        public string inTime { get; set; }
        [DisplayName("操作员")]
        public string oper { get; set; }
        [DisplayName("被借次数")]
        public int borrownum { get; set; }
        [DisplayName("可借天数")]
        [Required(ErrorMessage = "必须填写可借天数")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "天数为正整数")]
        public int days { get; set; }
        public virtual BookCase BookCases { get; set; }
        public virtual BookType BookTypes { get; set; }
    }
}