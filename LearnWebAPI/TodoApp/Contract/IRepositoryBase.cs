using System.Linq.Expressions;

namespace Contract
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
