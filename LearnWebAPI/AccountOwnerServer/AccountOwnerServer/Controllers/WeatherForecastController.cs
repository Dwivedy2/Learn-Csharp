using Microsoft.AspNetCore.Mvc;
using LoggerService;
using Contracts;

namespace AccountOwnerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        public WeatherForecastController(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var domesticAccounts = _repository.Account.FindByCondition(x => x.AccountType == "Domestic");
            var owner = _repository.Owner.FindAll();

            return new[] { "Value1", "Value2" };
        }
    }
}