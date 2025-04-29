using Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Common.Filters
{
    public class ValidationFilter : IActionFilter, IOrderedFilter
    {
        private readonly ICustomLogService _logger;
        public ValidationFilter(ICustomLogService logger)
        {
            this._logger = logger;
        }

        public int Order { get; set; } = 2;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.Log($"Validation for {context.ActionDescriptor.DisplayName} is successfull");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                                    .Where(ms => ms.Value.Errors.Count > 0)
                                    .Select(ms => new
                                    {
                                        Field = ms.Key,
                                        Errors = ms.Value.Errors.Select(e => e.ErrorMessage)
                                    });

                context.Result = new BadRequestObjectResult(new
                {
                    Message = "Validation Failed",
                    Errors = errors
                });
            }
        }
    }
}
