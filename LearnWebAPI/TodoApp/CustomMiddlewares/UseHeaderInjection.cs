using Microsoft.AspNetCore.Http;

namespace CustomMiddlewares
{
    public class UseHeaderInjection
    {
        private readonly RequestDelegate _next;

        public UseHeaderInjection(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext http)
        {
            Console.WriteLine($"Request recieved at: {DateTime.Now.ToShortTimeString()}");
            
            http.Response.Headers.Add("X-Processed-By", "CustomMiddleware");
            await _next(http);

        }
    }
}