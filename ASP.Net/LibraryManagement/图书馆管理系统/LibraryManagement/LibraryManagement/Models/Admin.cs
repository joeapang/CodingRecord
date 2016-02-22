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
    public class Admin
    {
        [Key]
        public int id { get; set; }
         [DisplayName("管理员用户名")]
         [Required(ErrorMessage = "必须输入管理员用户名")]
         [StringLength(50)]
         [RegularExpression(@"^[a-zA-z][a-zA-Z0-9_]{2,9}$",ErrorMessage="用户名格式错误")]
        public string adminname { get; set; }
         [Required]
         [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
         [DataType(DataType.Password)]
         [Display(Name = "管理员密码")]
        public string passward { get; set; }
         [Display(Name="确认密码")]
         [Required]
         [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
         [DataType(DataType.Password)]
         public string ConfirmPassword { get; set; }
         [Required]

         public bool sysset { get; set; }
         [Required]
         public bool readset { get; set; }
         [Required]
         public bool bookset { get; set; }
         [Required]
         public bool borrowback { get; set; }
         [Required]
         public bool sysquery { get; set; }

    }
}