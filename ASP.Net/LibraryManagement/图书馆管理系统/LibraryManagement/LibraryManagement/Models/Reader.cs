using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LibraryManagement.Models
{
    [Bind(Exclude = "id")]
    public class Reader
    {
        [Key]
        [RegularExpression(@"^[a-zA-z][a-zA-Z0-9_]{2,9}$", ErrorMessage = "用户名格式错误")]
        [Required(ErrorMessage = "用户名为空")]
        public string readerid { get; set; }
        [Required(ErrorMessage = "必须填写姓名")]
        [DisplayName("姓名")]
        [StringLength(160)]
        [RegularExpression(@"^[\u4e00-\u9fa5]*$", ErrorMessage = "名字为汉字")]
        public string readername { get; set; }
        [DisplayName("性别")]
        public virtual bool sex { get; set; }
        public int readertypeid { get; set; }
        [DisplayName("出生年月")]
        [RegularExpression(@"[0-9]{4}-(0[1-9]|1[0-2])-([0-2][0-9]|3[0-1])", ErrorMessage = "时间无效")]
        public string birthday { get; set; }
        [DisplayName("证件类型")]
        public string paperType { get; set; }
        [DisplayName("证件号码")]
        public string paperNum { get; set; }
        [StringLength(24)]
        [DisplayName("电话号码")]
        public string tel { get; set; }
        [Required(ErrorMessage = "必须填写e-mail地址")]
        [DisplayName("e-mail地址")]
        [RegularExpression(@"[A-Za-z0-9_\.\-]+@[A-Za-z0-9\-]+\.[A-Za-z]{2,4}", ErrorMessage = "填写的e-mail地址无效")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [DisplayName("注册时间")]
        [RegularExpression(@"[0-9]{4}-(0[1-9]|1[0-2])-([0-2][1-9]|3[0-1])", ErrorMessage = "时间无效")]

        public string createDate { get; set; }
        [DisplayName("操作员")]
        public string oper { get; set; }
        [DisplayName("备注")]
        public string remark { get; set; }
        [DisplayName("借书次数")]
        public int borrownum { get; set; }
        [DisplayName("可借数量")]
        public int number { get; set; }
        [DisplayName("已借数量")]
        public int yjnumber { get; set; }
        public virtual ReaderType ReaderTypes { get; set; }
    }
}