using System.Linq.Expressions;

namespace Todo.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public IQueryable<T> GetAll();
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition);
    }
}
