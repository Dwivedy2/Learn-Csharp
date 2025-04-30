using Contract;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService)
        {
            this._jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult LoginUser([FromBody]Login loginDetails)
        {
            if (loginDetails == null)
            {
                return BadRequest("login details are neccessary");
            }

            // getting data from db
            var dbEmployee = new Employee()
            {
                Name = "Om",
                Age = 25,
                Email = "Om@outlook.com",
                Id = 1,
                Role = Constants.Enums.Roles.Developer
            };

            if (loginDetails.Username == dbEmployee.Name && loginDetails.Password == "123")
            {
                var employee = new Employee()
                {
                    Name = dbEmployee.Name,
                    Age = dbEmployee.Age,
                    Email = dbEmployee.Email,
                    Id = dbEmployee.Id,
                    Role = dbEmployee.Role
                };

                var token = _jwtService.GenerateToken(employee);

                return Ok(new { Token = token });
            }

            return Unauthorized(new { Message = "Invalid Credentials"});
        }
    }
}
