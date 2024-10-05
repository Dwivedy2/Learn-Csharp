using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        DbSet<Owner> Owners { get; set; }
        DbSet<Account> Accounts { get; set; }

    }
}
