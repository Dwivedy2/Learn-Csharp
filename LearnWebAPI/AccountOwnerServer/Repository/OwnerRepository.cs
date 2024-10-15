using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext context) : base(context) { }

        public IEnumerable<Owner> GetAllOwners()
        {
            return FindAll()
                    .OrderBy(ow => ow.Name)
                    .ToList();
        }

        public Owner? GetOwner(Guid id)
        {
            return FindByCondition(ow => ow.Id.Equals(id))
                    .FirstOrDefault();
        }

        public Owner? GetOwnerDetail(Guid id)
        {
            return FindByCondition(ow => ow.Id.Equals(id))
                    .Include(ac => ac.Accounts)
                    .FirstOrDefault();
        }
    }
}
