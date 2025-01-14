using Contract;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public IdentityController(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("login")]
        public IActionResult Login(Login login)
        {
            if (login.Username == "admin" && login.Password == "password")
            {
                var token = _jwtTokenGenerator.GenerateToken(login.Username, "Admin");
                return Ok(new { Token = token });
            }
            return Unauthorized("Invalid Username or Password");
        }
    }
}
