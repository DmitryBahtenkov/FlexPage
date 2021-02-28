using System.ComponentModel.DataAnnotations;

namespace mvc.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        public string Username { get; set; }
         
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}