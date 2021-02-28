using System.ComponentModel.DataAnnotations;
using mvc.Models.DbModels;

namespace mvc.Models.ViewModels
{
    public class ProjectViewModel
    {
        [Required(ErrorMessage = "Назваине проекта обязательно!")]
        [DataType(DataType.Text)]
        public string Name {get; set;}

        [Required(ErrorMessage = "Описание проекта обязательно!")]
        [DataType(DataType.MultilineText)]
        public string Description {get; set;}
        [UIHint("Boolean")]
        public bool IsPrivate {get; set; }
    }
}