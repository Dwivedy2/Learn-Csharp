namespace Todo.Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepo User { get; }
        ITodoRepo Todos { get; }
        void Save();
    }
}
