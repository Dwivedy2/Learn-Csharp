using Contract;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace CustomMiddlewares
{
    public class UseCommonExceptionHandling
    {
        private readonly RequestDelegate _next;
        private readonly ICustomLogService _logger;

        public UseCommonExceptionHandling(RequestDelegate next, ICustomLogService logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.Log($"Exception occured: {ex.StackTrace}");

                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext http, Exception ex)
        {
            var response = new
            {
                Message = "Something went wrong",
                Detail = ex.Message,
            };

            http.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            http.Response.ContentType = "application/json";

            await http.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
