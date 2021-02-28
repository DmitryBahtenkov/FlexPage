using System;
namespace mvc.Models.DbModels
{
    public class Project : BaseModel
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public ProjectState State {get ;set;}
        public bool? IsPrivate {get; set;}
        public Guid UserId {get; set;}
        public virtual User User {get; set;}
    }
}