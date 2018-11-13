using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndProd.Web.Models
{
    public class LoginModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Поле Email не может быть пустым")]
        [EmailAddress(ErrorMessage = "Неверно введен Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле Password не может быть пустым")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Пароль не может быть длиной менее 6 символов")]
        public string Password { get; set; }
    }
}