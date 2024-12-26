using Todo.Contracts;

namespace Todo.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        RepoContext _context;
        public RepositoryBase(RepoContext context)
        {
            _context = context;
        }

        public void Add(T entity) => _context.Set<T>().Add(entity);
    }
}
