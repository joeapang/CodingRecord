using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Login
    {
        [Required]
        [Display(Name="用户名")]
        public string username { get; set; }
        [Required]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name="输入验证码")]
        public string sryzm { get; set; }
        public string yzm { get; set; }

    }
}