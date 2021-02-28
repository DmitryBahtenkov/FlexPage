using System.Collections.Generic;
namespace mvc.Models.DbModels
{
    public class User : BaseModel
    {
        public string Username {get; set;}
        public string Password {get; set;}
        public string Bio {get; set;}
        public List<Project> Projects {get; set;}
    }
}