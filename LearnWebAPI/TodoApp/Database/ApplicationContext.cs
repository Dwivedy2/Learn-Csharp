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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
                    new TodoItem { Id = Guid.NewGuid(), Title = "Configure EF seed data", IsCompleted = false, DateCreated = DateTime.Now },
                    new TodoItem { Id = Guid.NewGuid(), Title = "Make your first GET request", IsCompleted = false, DateCreated = DateTime.Now },
                    new TodoItem { Id = Guid.NewGuid(), Title = "Test your first GET request", IsCompleted = false, DateCreated = DateTime.Now }
                );
        }
    }
}
