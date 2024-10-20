using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.Contracts;
using Todo.DTOs;
using Todo.DTOs.Todos;
using Todo.Entities;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        IRepositoryWrapper _repo;
        IMapper _mapper;
        public ToDoController(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            try
            {
                var allTodos = _repo.Todos.GetAllTodos();
                return Ok(new ReturnObject(allTodos, "Data fetched successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnObject(null, $"Internal Server Error, {ex.Message}"));
            }
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0 || id > 10)
            {
                return BadRequest(new ReturnObject(null, "Invalid Id passed"));
            }

            try
            {
                var todoItem = _repo.Todos.GetTodoById(id);

                if (todoItem == null)
                {
                    return NotFound(new ReturnObject(null, $"No TodoItem is present with Id: {id}"));
                }

                return Ok(todoItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnObject(null, $"Internal Server Error, {ex.Message}"));
            }
        }

        [HttpPost("add")]
        public IActionResult Add(AddDto todoDto)
        {
            if (todoDto == null)
            {
                return BadRequest(new ReturnObject(null, "Object cannot be null"));
            }

            try
            {
                var todoItem = _mapper.Map<ToDos>(todoDto);

                todoItem.CreatedDate = DateTime.Now;

                _repo.Todos.AddTodo(todoItem);

                _repo.Save();

                return Created("add", new ReturnObject(todoDto, "Todo created."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnObject(null, $"Internal Server Error, {ex.Message}"));
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, UpdateDto todoDto)
        {
            if (todoDto == null)
            {
                return BadRequest(new ReturnObject(null, "Object cannot be null"));
            }

            try
            {
                var dbTodo = _repo.Todos.GetTodoById(id);

                if (dbTodo == null)
                {
                    return NotFound(new ReturnObject(null, "Invalid id"));
                }

                _mapper.Map(todoDto, dbTodo);

                dbTodo.UpdatedDate = DateTime.Now;

                _repo.Todos.UpdateTodo(dbTodo);

                _repo.Save();

                return Created("updated", new ReturnObject(todoDto, "Todo updated."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnObject(null, $"Internal Server Error, {ex.Message}"));
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var dbTodo = _repo.Todos.GetTodoById(id);

                if (dbTodo == null)
                {
                    return NotFound(new ReturnObject(null, "Invalid id"));
                }

                _repo.Todos.DeleteTodo(dbTodo);

                _repo.Save();

                return Ok(new ReturnObject(null, "Todo Deleted Successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnObject(null, $"Internal Server Error, {ex.Message}"));
            }
        }
    }
}
