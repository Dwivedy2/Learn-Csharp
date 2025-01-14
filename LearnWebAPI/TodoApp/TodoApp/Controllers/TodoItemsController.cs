using Common;
using Contract;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
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

        //[Authorize]
        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<TodoItem>>>> GetAll()
        {
            var response = new ServiceResponse<IEnumerable<TodoItem>>();
            var allItems = await _repoService.TodoItems.GetAllItemsAsync();
            var serviceResponse = response.GetResponse(allItems, "Success", true);
            return serviceResponse.IsSuccessful ? Ok(serviceResponse) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<TodoItem?>>> GetById(Guid id)
        {
            var response = new ServiceResponse<TodoItem>();
            
            if (Guid.Empty == id)
            {
                return BadRequest(response.GetResponse(null, "Id is not in the correct format of Guid"));
            }
            
            var item = await _repoService.TodoItems.GetItemByIdAsync(id);

            if (item == null)
            {
                return NotFound(response.GetResponse(item, $"No item exist for the id {id}"));
            }

            return Ok(response.GetResponse(item, "Success", true)); 
        }

        [HttpPost("add/item")]
        public async Task<ActionResult<ServiceResponse<TodoItem>>> AddTodoItem(TodoItem item)
        {
            var response = new ServiceResponse<TodoItem>();
            
            if (item == null || string.IsNullOrEmpty(item.Title))
            {
                return BadRequest(response.GetResponse(null, "Item or Title cannot be left empty"));
            }
            
            var addedItem = await _repoService.TodoItems.AddItemAsync(item);

            await _repoService.SaveChangesAsync();

            return Ok(response.GetResponse(addedItem, "Item added successfully", true));
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<ServiceResponse<TodoItem>>> UpdateTodoItem(Guid id, TodoItem item)
        {
            var response = new ServiceResponse<TodoItem>();

            if (Guid.Empty == id || item == null || string.IsNullOrEmpty(item.Title))
            {
                return BadRequest(response.GetResponse(null, "Item or Title cannot be left empty"));
            }

            var itemFromDb = await _repoService.TodoItems.GetByIdAsync(id);

            if (itemFromDb == null)
            {
                return BadRequest(response.GetResponse(null, $"Id is not registered {id}"));
            }

            var updatedItem = _repoService.TodoItems.UpdateItem(item);

            await _repoService.SaveChangesAsync();

            return Ok(response.GetResponse(updatedItem, "Item updated successfully", true));
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ServiceResponse<TodoItem>>> DeleteTodoItem(Guid id) 
        {
            var response = new ServiceResponse<TodoItem>();

            if (Guid.Empty == id)
            {
                return BadRequest(response.GetResponse(null, "Id is not in the correct format of Guid"));
            }

            var itemFromDb = await _repoService.TodoItems.GetItemByIdAsync(id);

            if (itemFromDb == null)
            {
                return BadRequest(response.GetResponse(null, $"Id is not registered {id}"));
            }

            var deletedItem = _repoService.TodoItems.DeleteItem(itemFromDb);
            
            await _repoService.SaveChangesAsync();

            return Ok(response.GetResponse(deletedItem, "Item deleted successfully", true));
        }
    }
}
