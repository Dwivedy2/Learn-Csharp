using Contract;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Common.Filters
{
    public class LoggingFilter : IActionFilter
    {
        private readonly ICustomLogService _logger;
        public LoggingFilter(ICustomLogService logger)
        {
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.Log(@$"Action Method Executed: {context.ActionDescriptor.DisplayName}
                          Time: {DateTime.Now.ToShortTimeString()}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.Log(@$"Action Method To Execute: {context.ActionDescriptor.DisplayName}
                          Time: {DateTime.Now.ToShortTimeString()}");
        }
    }
}
