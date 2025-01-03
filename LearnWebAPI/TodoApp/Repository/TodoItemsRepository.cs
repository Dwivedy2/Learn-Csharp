using Contract;
using Database;
using Entities.Models;

namespace Repository
{
    public class TodoItemsRepository : RepositoryBase<TodoItem>, ITodoItemsRepository
    {
        public TodoItemsRepository(ApplicationContext context) : base(context)
        {     
        }
    }
}
