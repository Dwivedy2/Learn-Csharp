using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Common.Filters;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LoggingFilter))]
    [ServiceFilter(typeof(ValidationFilter))]
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
