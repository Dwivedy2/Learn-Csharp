using Microsoft.AspNetCore.Mvc;
using LoggerService;
using Contracts;

namespace AccountOwnerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        public WeatherForecastController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Logged Info");
            _logger.LogDebug("Logged Info");
            _logger.LogWarning("Logged Info");
            _logger.LogError("Logged Error");

            return new[] { "Climate", "Weather" };
        }
    }
}