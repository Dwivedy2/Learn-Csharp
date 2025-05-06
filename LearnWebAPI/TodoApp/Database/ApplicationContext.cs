using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
                    new TodoItem { Id = Guid.NewGuid(), Title = "Configure EF seed data", IsCompleted = false, DateCreated = DateTime.Now },
                    new TodoItem { Id = Guid.NewGuid(), Title = "Make your first GET request", IsCompleted = false, DateCreated = DateTime.Now },
                    new TodoItem { Id = Guid.NewGuid(), Title = "Test your first GET request", IsCompleted = false, DateCreated = DateTime.Now }
                );

            modelBuilder.Entity<Employee>().HasData(
                    new Employee { Id = Guid.NewGuid(), Age = 25, Email = "omdwivedy@business.com", 
                        Name = "Omkareshwar Dwivedy", Role = Constants.Enums.Roles.Developer}
                );
        }
    }
}
