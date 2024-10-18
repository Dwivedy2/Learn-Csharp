using Microsoft.EntityFrameworkCore;
using Todo.Entities;

namespace Todo
{
    public class RepoContext : DbContext
    {
        public RepoContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<ToDos> ToDos { get; set; }
    }
}
