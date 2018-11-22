using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class LoginModel
    {
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Поле UserName не может быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Не верная длина")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле Password не может быть пустым")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Пароль не может быть длиной менее 6 символов")]
        public string Password { get; set; }
    }
}