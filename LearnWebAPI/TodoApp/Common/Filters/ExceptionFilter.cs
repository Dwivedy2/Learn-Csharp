using Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Common.Filters
{
    public class ExceptionFilter : IExceptionFilter, IOrderedFilter
    {
        private readonly ICustomLogService _logger;

        public ExceptionFilter(ICustomLogService logger)
        {
            this._logger = logger;
        }

        public int Order { get; set; } = 3;

        public void OnException(ExceptionContext context)
        {
            _logger.Log($"Exception occurred: {context.Exception.Message}");

            var errorResponse = new
            {
                Message = "Internal Server Error",
                Detail = context.Exception.Message
            };

            context.Result = new ObjectResult(errorResponse)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}
