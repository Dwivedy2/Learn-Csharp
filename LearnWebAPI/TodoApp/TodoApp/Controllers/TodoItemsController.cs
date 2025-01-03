using Contract;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        IRepositoryWrapper _repoService;
        public TodoItemsController(IRepositoryWrapper repoService)
        {
            _repoService = repoService;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            return await _repoService.TodoItems.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<TodoItem?> GetById(Guid id)
        {
            var item = await _repoService.TodoItems.GetByIdAsync(id);

            return item;
        }
    }
}
