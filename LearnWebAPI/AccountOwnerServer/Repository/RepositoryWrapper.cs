using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _context;
        private OwnerRepository _ownerRepository;
        private AccountRepository _accountRepository;

        public IOwnerRepository Owner
        {
            get
            {
                return _ownerRepository ?? new OwnerRepository(_context);
            }
        }

        public IAccountRepository Account
        {
            get
            {
                return _accountRepository ?? new AccountRepository(_context);
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
