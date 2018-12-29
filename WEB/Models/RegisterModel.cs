using System.ComponentModel.DataAnnotations;

namespace WEB.Models
{
    public class RegisterModel
    {
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Поле UserName не может быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Не верная длина")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Поле Email не может быть пустым")]
        [EmailAddress(ErrorMessage = "Неверно введен Email")]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле Password не может быть пустым")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Пароль не может быть длиной менее 6 символов")]
        public string Password { get; set; }

        [Display(Name = "Подтверждение пароля")]
        [Required(ErrorMessage = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле FirstName не может быть пустым")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Не верная длина")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле LastName не может быть пустым")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Не верная длина")]
        public string LastName { get; set; }
    }
}