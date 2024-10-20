using DemoDay.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoDay
{
    public class RepoContext : DbContext
    {
        public RepoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AccountHolder> AccountHolder { get; set; }
    }
}
