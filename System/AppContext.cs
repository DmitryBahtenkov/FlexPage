

using Microsoft.EntityFrameworkCore;
using mvc.Models.DbModels;

namespace mvc.System
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Project { get; set; }
 
        public AppContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=1111;database=flexpages;"
            );

        }
    }
}