using Microsoft.AspNetCore.Http;

namespace CustomMiddlewares
{
    public class UseShortCircuiting
    {
        private RequestDelegate _next;
        public UseShortCircuiting(RequestDelegate next)
        {
            _next = next;            
        }

        public async Task InvokeAsync(HttpContext http)
        {
            if (http.Request.Headers.ContainsKey("X-Secret-Key"))
            {
                http.Response.StatusCode = 400;
                await http.Response.WriteAsync("Something is missing from Headers");
                return;
            }
            await _next(http);
        }
    }
}
