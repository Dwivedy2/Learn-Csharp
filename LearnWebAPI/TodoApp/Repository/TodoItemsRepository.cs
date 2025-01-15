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

        public async Task<TodoItem> AddItemAsync(TodoItem item)
        {
            item.DateCreated = DateTime.Now;

            await AddAsync(item);
            
            return item;
        }

        public TodoItem DeleteItem(TodoItem item)
        {
            Delete(item);

            return item;
        }

        public async Task<IEnumerable<TodoItem>> GetAllItemsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<TodoItem> GetItemByIdAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public TodoItem UpdateItem(TodoItem item)
        {
            Update(item);

            return item;
        }
    }
}
