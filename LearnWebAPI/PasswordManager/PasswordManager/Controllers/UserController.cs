using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Constants;
using PasswordManager.Database;
using PasswordManager.Entities.DTO;
using PasswordManager.Entities.Models;
using PasswordManager.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext context;
        private readonly IPasswordHasher hasher;

        public UserController(ApplicationContext context, IPasswordHasher hasher)
        {
            this.context = context;
            this.hasher = hasher;
        }

        [HttpGet]
        public ActionResult<ICollection<User>> GetUsers()
        {
            return Ok(context.Users.ToList());
        }

        [HttpPost("/Login")]
        public async Task<ActionResult> Login(UserDto userDto)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == userDto.Email);

            if (user == null)
            {
                return BadRequest("You are not registered, please register yourself");
            }

            
            var passwordHash = Rfc2898DeriveBytes.Pbkdf2(userDto.Password,
                                Encoding.UTF8.GetBytes(user.PasswordSalt), 
                                PasswordHash.ITERATIONS, 
                                PasswordHash.ALGORITHM, 
                                PasswordHash.KEY_SIZE);

            bool compareResult = CryptographicOperations.FixedTimeEquals(passwordHash, Convert.FromBase64String(user.PasswordHash));

            if (compareResult)
            {
                return Ok("Login Successful");
            }

            return BadRequest("Invalid Password");
        }

        [HttpPost("/Register")]
        public async Task<ActionResult<UserDto>> Register(UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Not a valid user");
            }

            string salt = hasher.GenerateSalt();
            string passwordHash = hasher.GenerateHash(userDto.Password, salt);

            User user = new User();
            user.Email = userDto.Email;
            user.PasswordSalt = salt;
            user.PasswordHash = passwordHash;

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return Created("/", userDto);
        }


    }
}
