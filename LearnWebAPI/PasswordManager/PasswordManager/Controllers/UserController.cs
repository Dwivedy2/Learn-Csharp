using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Database;
using PasswordManager.Entities.Models;

namespace PasswordManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext context;
        private readonly ILogger<UserController> logger;

        public UserController(ApplicationContext context, ILogger<UserController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        [HttpGet("getall")]
        public ActionResult<ICollection<User>> GetAll()
        {
            logger.LogDebug($"Debugger log printed");

            throw new ArgumentException("Throwing error to test middleware");

            return Ok(context.Users.ToList());
        }
    }
}
