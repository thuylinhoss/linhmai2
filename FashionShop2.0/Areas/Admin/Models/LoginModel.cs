using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FashionShop2._0.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Hãy nhập username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Hãy nhập password")]
        public string PassWord { get; set; }
        public bool RememberMe { get; set; }
    }
}