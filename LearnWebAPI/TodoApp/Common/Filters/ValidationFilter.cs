using Contract;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Common.Filters
{
    public class ValidationFilter : IActionFilter
    {
        private readonly ICustomLogService _logger;
        public ValidationFilter(ICustomLogService logger)
        {
            this._logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.Log($"Validation for {context.ActionDescriptor.DisplayName} is successfull");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.Log($"Validating {context.ActionDescriptor.DisplayName}");
        }
    }
}
