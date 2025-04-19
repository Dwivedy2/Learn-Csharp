using Contract;
using Microsoft.AspNetCore.Http;

namespace CustomMiddlewares
{
    public class UseLogging
    {
        private readonly RequestDelegate _next;
        private readonly ICustomLogService _logger;

        public UseLogging(RequestDelegate next, ICustomLogService logger) 
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext http)
        {
            _logger.Log($"{http.Request.Path}: {DateTime.Now.TimeOfDay}");
            await _next(http);
        }
    }
}
