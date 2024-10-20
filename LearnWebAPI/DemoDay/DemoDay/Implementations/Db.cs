using DemoDay.Entities;
using DemoDay.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoDay.Implementations
{
    public class Db : IDb
    {
        RepoContext _context;
        public Db(RepoContext context)
        {
            _context = context;
        }

        public IEnumerable<AccountHolder> GetAccountHolders()
        {
            if (this.CheckIfDataIsPresent())
            {
                return _context.AccountHolder.AsNoTracking().ToList();
            }

            return Enumerable.Empty<AccountHolder>();
        }

        public bool CheckIfDataIsPresent()
        {
            if (_context.AccountHolder.AsNoTracking().ToList().Count() == 0) 
                return false;
            return true;
        }
    }
}
