using AutoMapper;
using Common;
using Contract;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoService;
        private readonly IMapper _mapper;

        public TodoItemsController(IRepositoryWrapper repoService,
            IMapper mapper)
        {
            _repoService = repoService;
            _mapper = mapper;
        }

        //[Authorize]
        [HttpGet("all")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<GetTodoItemDto>>>> GetAll()
        {
            var response = new ServiceResponse<IEnumerable<GetTodoItemDto>>();

            var allItems = await _repoService.TodoItems.GetAllItemsAsync();

            var itemToReturn = allItems.Select(item => _mapper.Map<GetTodoItemDto>(item));

            var serviceResponse = itemToReturn.Count() > 0 ? 
                response.GetResponse(itemToReturn, "Success", true) : 
                response.GetResponse(null, "No items in database");

            return serviceResponse.IsSuccessful ? Ok(serviceResponse) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTodoItemDto?>>> GetByIdAsync(Guid id)
        {
            var response = new ServiceResponse<GetTodoItemDto>();
            
            if (Guid.Empty == id)
            {
                return BadRequest(response.GetResponse(null, "Id is not in the correct format of Guid"));
            }
            
            var item = await _repoService.TodoItems.GetItemByIdAsync(id);

            var itemToReturn = _mapper.Map<GetTodoItemDto>(item);

            if (item == null)
            {
                return NotFound(response.GetResponse(null, $"No item exist for the id {id}"));
            }

            return Ok(response.GetResponse(itemToReturn, "Success", true)); 
        }

        [HttpPost("add/item")]
        public async Task<ActionResult<ServiceResponse<GetTodoItemDto>>> AddTodoItemAsync(TodoItemDto itemDto)
        {
            var response = new ServiceResponse<GetTodoItemDto>();
            
            if (itemDto == null || string.IsNullOrEmpty(itemDto.Title))
            {
                return BadRequest(response.GetResponse(null, "Item or Title cannot be left empty"));
            }
            
            var mappedItem = _mapper.Map<TodoItem>(itemDto);

            var addedItem = await _repoService.TodoItems.AddItemAsync(mappedItem);

            await _repoService.SaveChangesAsync();

            var itemToReturn = _mapper.Map<GetTodoItemDto>(addedItem);

            return Ok(response.GetResponse(itemToReturn, "Item added successfully", true));
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<ServiceResponse<GetTodoItemDto>>> UpdateTodoItemAsync(Guid id, TodoItemDto itemDto)
        {
            var response = new ServiceResponse<GetTodoItemDto>();

            if (Guid.Empty == id || itemDto == null || string.IsNullOrEmpty(itemDto.Title))
            {
                return BadRequest(response.GetResponse(null, "Item or Title cannot be left empty"));
            }

            var itemFromDb = await _repoService.TodoItems.GetByIdAsync(id);

            if (itemFromDb == null)
            {
                return BadRequest(response.GetResponse(null, $"Id is not registered {id}"));
            }

            itemFromDb.Title = itemDto.Title;
            itemFromDb.IsCompleted = itemFromDb.IsCompleted;

            var updatedItem = _repoService.TodoItems.UpdateItem(itemFromDb);

            await _repoService.SaveChangesAsync();

            var itemToReturn = _mapper.Map<GetTodoItemDto>(updatedItem);

            return Ok(response.GetResponse(itemToReturn, "Item updated successfully", true));
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<ServiceResponse<GetTodoItemDto>>> DeleteTodoItemAsync(Guid id) 
        {
            var response = new ServiceResponse<GetTodoItemDto>();

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

            var itemToReturn = _mapper.Map<GetTodoItemDto>(deletedItem);

            return Ok(response.GetResponse(itemToReturn, "Item deleted successfully", true));
        }
    }
}
