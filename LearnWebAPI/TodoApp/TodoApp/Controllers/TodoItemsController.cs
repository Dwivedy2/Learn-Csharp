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
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public TodoItemsController(IRepositoryWrapper repoService, IJwtTokenGenerator jwtTokenGenerator)
        {
            _repoService = repoService;
            this._jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("login")]
        public IActionResult Login(Login login)
        {
            if (login.Username == "admin" &&  login.Password == "password")
            {
                var token = _jwtTokenGenerator.GenerateToken(login.Username, "Admin");
                return Ok(new { Token = token });
            }
            return Unauthorized("Invalid Username or Password");
        }

        [HttpGet("all")]
        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            return await _repoService.TodoItems.GetAllItemsAsync();
        }

        [HttpGet("{id}")]
        public async Task<TodoItem?> GetById(Guid id)
        {
            var item = await _repoService.TodoItems.GetByIdAsync(id);

            return item;
        }

        [HttpPost("add/item")]
        public void AddTodoItem(TodoItem item)
        {
            _repoService.TodoItems.Add(item);
            _repoService.SaveChanges();
        }

        [HttpPut("update/{id}")]
        public async Task UpdateTodoItem(Guid id, TodoItem item)
        {
            var dbItem = await _repoService.TodoItems.GetByIdAsync(id);

            if (dbItem != null)
            {
                dbItem.Title = item.Title;
                dbItem.IsCompleted = item.IsCompleted;
                _repoService.TodoItems.Update(dbItem);
                _repoService.SaveChanges();
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task DeleteTodoItem(Guid id) 
        {
            var dbItem = await _repoService.TodoItems.GetByIdAsync(id);
            
            _repoService.TodoItems.Delete(dbItem);
            _repoService.SaveChanges();
        }
    }
}
