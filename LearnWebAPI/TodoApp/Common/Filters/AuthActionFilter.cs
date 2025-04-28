using Constants.Enums;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Common.Filters
{
    public class AuthActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Executed");
        }

        // this is better, as it will execute before post action,
        // till then model binding is done
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var employee = context.ActionArguments["Employee"] as Employee;

            if (employee == null || employee.Role != Roles.Manager)
            {
                context.Result = new ObjectResult(new { Message = "Only Managers can add employees" })
                {
                    StatusCode = (int)HttpStatusCode.Forbidden,
                };
            }
        }
    }
}
