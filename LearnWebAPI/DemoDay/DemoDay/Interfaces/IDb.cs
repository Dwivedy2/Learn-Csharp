using DemoDay.Entities;

namespace DemoDay.Interfaces
{
    public interface IDb
    {
        IEnumerable<AccountHolder> GetAccountHolders();
    }
}
