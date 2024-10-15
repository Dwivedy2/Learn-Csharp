using Entities.Models;


namespace Contracts
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        IEnumerable<Owner> GetAllOwners();
        Owner? GetOwner(Guid id);
        Owner? GetOwnerDetail(Guid id);
    }
}
