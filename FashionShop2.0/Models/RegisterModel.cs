using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FashionShop2._0.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { set; get; }
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage="Nhập tên đăng nhập")]
        public string UserName { set; get; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Nhập mật khẩu")]
        [StringLength(32, MinimumLength = 6, ErrorMessage = "Độ dài ít nhất 6 ký tự")]
        public string Password { set; get; }
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp!")]
        public string ConfirmPassword { set; get; }
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Nhập họ tên")]
        public string Name { set; get; }
        [Display(Name = "Địa chỉ")]
        public string Address { set; get; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Nhập Email")]
        public string Email { set; get; }
        [Display(Name = "Số điện thoại")]
        public string Phone { set; get; }

    }
}