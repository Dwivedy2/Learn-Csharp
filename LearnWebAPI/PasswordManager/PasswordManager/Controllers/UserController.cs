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

        public UserController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet("getall")]
        public ActionResult<ICollection<User>> GetAll()
        {
            return context.Users.ToList();
        }
    }
}
