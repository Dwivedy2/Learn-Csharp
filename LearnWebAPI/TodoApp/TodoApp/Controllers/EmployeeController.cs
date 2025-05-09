using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Common.Filters;
using Database;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ServiceFilter(typeof(AuthFilter))]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public EmployeeController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public ActionResult<List<Employee>> GetAll()
        {
            var employees = _context.Employees.Select(e => e).ToList();

            return Ok(employees);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<Employee>> GetAll([FromRoute] Guid id)
        {
            if (Guid.Empty == id)
            {
                return BadRequest("Id cannot be null");
            }

            var emp = await _context.Employees.FindAsync(id);

            if (emp == null)
            {
                return BadRequest("Id is invalid");
            }

            return Ok(emp);
        }

        [HttpGet("employee/{skillId}")]
        public IActionResult GetEmployeeBySkillId(int skillId) 
        {
            if (skillId <= 0)
            {
                return BadRequest("Invalid skill id");
            }

            var employees = _context.EmployeeSkills
                .Where(es => es.SkillId == skillId)
                .Select(e => e.Employee)
                .ToList();

            return Ok(employees);
        }

        //[ServiceFilter(typeof(AuthActionFilter))]
        [HttpPost("add")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("employee cannot be null");
            }

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("modify/{id}")] 
        public async Task<IActionResult> ModifyEmployee([FromBody] Employee employee, [FromRoute] Guid id)
        {
            if (Guid.Empty == id)
            {
                return BadRequest("Id cannot be null");
            }

            if (employee == null)
            {
                return BadRequest("employee cannot be null");
            }

            var emp = await _context.Employees.FindAsync(id);

            if (emp == null)
            {
                return BadRequest("Id is invalid");
            }

            emp.Age = employee.Age;
            emp.Role = employee.Role;
            emp.Email = employee.Email;
            emp.Name = employee.Name;

            _context.Employees.Update(emp);
            await _context.SaveChangesAsync();

            return Ok("Employee data updated successfuly");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            if (Guid.Empty == id)
            {
                return BadRequest("Id cannot be null");
            }

            var emp = await _context.Employees.FindAsync(id);

            if (emp == null)
            {
                return BadRequest("Id is invalid");
            }

            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();

            return Ok("Employee deleted successfully");
        }
    }
}
