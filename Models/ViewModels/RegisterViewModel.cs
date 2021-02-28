using System.ComponentModel.DataAnnotations;

namespace mvc.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Не указано имя пользователя")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.MultilineText)]
        public string Bio { get; set; }
    }
}