using Microsoft.EntityFrameworkCore;
using PasswordManager.Entities.Models;

namespace PasswordManager.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Site> Sites { get; set; }
    }
}
