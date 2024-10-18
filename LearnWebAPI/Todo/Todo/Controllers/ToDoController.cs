using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.Contracts;
using Todo.DTOs;
using Todo.Entities;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        ITodoRepo _todoRepo;
        IMapper _mapper;
        public ToDoController(ITodoRepo todoRepo, IMapper mapper)
        {
            _todoRepo = todoRepo;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            try
            {
                var allTodos = _todoRepo.GetAllTodos();
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
                var todoItem = _todoRepo.GetTodoById(id);

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

                _todoRepo.AddTodo(todoItem);

                _todoRepo.Save();

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
                var dbTodo = _todoRepo.GetTodoById(id);

                if (dbTodo == null)
                {
                    return NotFound(new ReturnObject(null, "Invalid id"));
                }

                _mapper.Map(todoDto, dbTodo);

                _todoRepo.UpdateTodo(dbTodo);

                _todoRepo.Save();

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
                var dbTodo = _todoRepo.GetTodoById(id);

                if (dbTodo == null)
                {
                    return NotFound(new ReturnObject(null, "Invalid id"));
                }

                _todoRepo.DeleteTodo(dbTodo);

                _todoRepo.Save();

                return Ok(new ReturnObject(null, "Todo Deleted Successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ReturnObject(null, $"Internal Server Error, {ex.Message}"));
            }
        }
    }
}
