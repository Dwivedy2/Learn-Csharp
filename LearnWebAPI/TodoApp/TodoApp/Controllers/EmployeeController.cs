using Microsoft.AspNetCore.Mvc;
using Entities.Models;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees;

        public EmployeeController()
        {
            if (_employees is null)
            {
                _employees = new List<Employee>();
            }
        }

        [HttpPost("add")]
        public ActionResult<List<Employee>> AddEmployee([FromBody] Employee employee)
        {
            _employees.Add(employee);

            return Ok(_employees);
        }
    }
}
