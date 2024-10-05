using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext context) : base(context) { }
    }
}
