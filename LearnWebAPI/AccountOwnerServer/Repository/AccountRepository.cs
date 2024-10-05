using Contracts;
using Entities;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(RepositoryContext context) : base(context) { }

    }
}
