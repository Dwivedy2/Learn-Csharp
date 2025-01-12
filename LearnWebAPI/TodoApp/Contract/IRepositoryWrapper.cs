namespace Contract
{
    public interface IRepositoryWrapper
    {
        ITodoItemsRepository TodoItems { get; }
        void SaveChanges();
    }
}
