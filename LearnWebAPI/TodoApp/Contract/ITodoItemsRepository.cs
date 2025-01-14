using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contract
{
    public interface ITodoItemsRepository : IRepositoryBase<TodoItem>
    {
        Task<IEnumerable<TodoItem>> GetAllItemsAsync();
        Task<TodoItem> GetItemByIdAsync(Guid id);
        Task<TodoItem> AddItemAsync(TodoItem item);
        TodoItem UpdateItem(TodoItem item);
        TodoItem DeleteItem(TodoItem item);
    }
}
