using Contract;
using Microsoft.AspNetCore.Http;

namespace CustomMiddlewares
{
    public class UseCommonExceptionHandling
    {
        private RequestDelegate _next;
        private ICustomLogService _logger;
        public UseCommonExceptionHandling(RequestDelegate next, ICustomLogService logger) 
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext http)
        {
            try
            {
                await _next(http);
            }
            catch (Exception ex)
            {
                _logger.Log(ex.Message);
                http.Response.StatusCode = 500;
                http.Response.ContentType = "application/json";
                var errorResponse = new { message = "Internal Server Error", detail = ex.Message };
                await http.Response.WriteAsync(errorResponse.ToString());
                throw;
            }
        }

    }
}
