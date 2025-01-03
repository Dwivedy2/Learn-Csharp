using Contract;
using Database;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApplicationContext _context;
        private TodoItemsRepository _todoItems;
        public RepositoryWrapper(ApplicationContext context)
        {
            _context = context;
        }

        public ITodoItemsRepository TodoItems
        {
            get
            {
                if (_todoItems == null)
                {
                    _todoItems = new TodoItemsRepository(_context);
                }
                return _todoItems;
            }
        }
    }
}
