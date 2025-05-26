using Newtonsoft.Json;
using System.Net;

namespace PasswordManager.Custom.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleException(ex, context);
            }
        }

        private async Task HandleException(Exception ex, HttpContext context)
        {
            logger.LogError($"Exception Stack Trace: \n{ex.StackTrace}");

            var errorObject = new
            {
                Error = ex.Message,
                Message = "Internal Server Error"
            };

            var errorMessage = JsonConvert.SerializeObject(errorObject);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(errorMessage);
        }
    }
}
