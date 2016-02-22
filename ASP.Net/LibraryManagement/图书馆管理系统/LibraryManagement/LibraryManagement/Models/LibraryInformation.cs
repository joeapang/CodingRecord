using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class LibraryInformation
    {

        [Key]
        public int id { get; set; }
        [StringLength(50)]
        [DisplayName("图书馆名称")]
        [Required(ErrorMessage = "必须填写图书馆名称")]
        [RegularExpression(@"^[\u4e00-\u9fa5]*$", ErrorMessage = "图书馆名称无效")]
        
        public string libraryname { get; set; }
        [StringLength(20)]
        [DisplayName("馆长")]
        public string curator { get; set; }
        [StringLength(50)]
        [DisplayName("电话")]
        [RegularExpression(@"((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)", ErrorMessage = "填写的电话号码无效")]
        public string tel { get; set; }
        [StringLength(50)]
        [DisplayName("地址")]
        [RegularExpression(@"^(?=.*?[\u4E00-\u9FA5])[\d\u4E00-\u9FA5]+", ErrorMessage = "地址无效")]
        public string address { get; set; }
        [Required(ErrorMessage = "必须填写e-mail地址")]
        [DisplayName("e-mail地址")]
        [RegularExpression(@"[A-Za-z0-9_\.\-]+@[A-Za-z0-9\-]+\.[A-Za-z]{2,4}", ErrorMessage = "填写的e-mail地址无效")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [StringLength(50)]
        [DisplayName("网址")]
        [RegularExpression(@"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?", ErrorMessage = "网址无效")]
        public string url { get; set; }
        [StringLength(50)]
        [DisplayName("建馆时间")]
        [RegularExpression(@"[0-9]{4}-(0[1-9]|1[0-2])-([0-2][1-9]|3[0-1])", ErrorMessage = "时间无效")]
        public string createDate { get; set; }
        [DisplayName("简介")]
        public string introduce { get; set; }
    }
}