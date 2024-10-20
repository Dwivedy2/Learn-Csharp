using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Constants;
using Todo.Contracts;
using Todo.DTOs;
using Todo.DTOs.Users;
using Todo.Entities;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IRepositoryWrapper _repo;
        IMapper _mapper;
        public UserController(IRepositoryWrapper repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            try
            {
                var users = _repo.User.GetAllUsers();
                return Ok(new ReturnObject(users, CMessages.FETCHED_SUCCESS));
            }
            catch (Exception ex)
            {
                return StatusCode(CValues.INTERNAL_SERVER_ERROR, new ReturnObject(null, $"{ex.Message}\n{ex.StackTrace}"));
            }
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id <= CValues.MIN_ID || id > CValues.MAX_ID)
                {
                    return BadRequest(new ReturnObject(null, CMessages.INVALID_ID));
                }

                var result = _repo.User.GetById(id);

                if (result == null)
                {
                    return NotFound(new ReturnObject(null, CMessages.FETCHED_FAILED));
                }

                return Ok(new ReturnObject(result, CMessages.FETCHED_SUCCESS));
            }
            catch (Exception ex)
            {
                return StatusCode(CValues.INTERNAL_SERVER_ERROR, new ReturnObject(null, $"{ex.Message}\n{ex.StackTrace}"));
            }
        }

        [HttpGet("detail/{id}")]
        public IActionResult GetDetailById(int id)
        {
            try
            {
                if (id <= CValues.MIN_ID || id > CValues.MAX_ID)
                {
                    return BadRequest(new ReturnObject(null, CMessages.INVALID_ID));
                }

                var result = _repo.User.GetDetailById(id);

                if (result == null)
                {
                    return NotFound(new ReturnObject(null, CMessages.FETCHED_FAILED));
                }

                var usr = _mapper.Map<GetUserDetailDto>(result);

                return Ok(new ReturnObject(usr, CMessages.FETCHED_SUCCESS));
            }
            catch (Exception ex)
            {
                return StatusCode(CValues.INTERNAL_SERVER_ERROR, new ReturnObject(null, $"{ex.Message}\n{ex.StackTrace}"));
            }
        }
    }
}
