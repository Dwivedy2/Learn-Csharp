using Entities.Models;
using Constants.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomMiddlewares
{
    public class RoleAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext http)
        {
            var employee = http.Items["Employee"] as Employee;

            if (employee == null)
            {
                await _next(http);
                return;
            }

            if (employee.Role != Roles.Manager)
            {
                http.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await http.Response.WriteAsync("User doesn't have required permission");
                return;
            }

            await _next(http);
        }
    }
}
