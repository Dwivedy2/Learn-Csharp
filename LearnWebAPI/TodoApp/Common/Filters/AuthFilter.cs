using Entities.Models;
using Constants.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Common.Filters
{
    // Not using as employee is coming as null, it is not set
    // executing before the model is binded,
    // instead perform this in actionfilter
    public class AuthFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var employee = context.HttpContext.Items["Employee"] as Employee;

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
