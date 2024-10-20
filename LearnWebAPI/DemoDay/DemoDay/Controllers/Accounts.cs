using DemoDay.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoDay.Controllers
{
    [Route("api/prateek")]
    [ApiController]
    public class Accounts : ControllerBase
    {
        IDb _idb;
        public Accounts(IDb idb)
        {
            _idb = idb;
        }

        [HttpGet]
        public IActionResult GetAccountHolders()
        {
            return Ok(_idb.GetAccountHolders());
        }
    }
}
