using Microsoft.AspNetCore.Mvc;

namespace FirstDotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessage() 
        {
            return Ok("Hello world api working");
        }
    }
}