using mvc.Models.DbModels;

namespace mvc.System
{
    public static class TechnicalUsers
    {
        public static User GuestUser => new User
        {
            Username = "Guest",
            Bio = "Гостевой пользователь"
        };
    }
}