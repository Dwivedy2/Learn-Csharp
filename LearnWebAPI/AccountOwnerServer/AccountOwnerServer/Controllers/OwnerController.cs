using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers
{
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private ILoggerManager _logger;
        private IMapper _mapper;

        public OwnerController(IRepositoryWrapper repositoryWrapper, 
            ILoggerManager loggerManager,
            IMapper mapper) 
        {
            _repository = repositoryWrapper;
            _logger = loggerManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllOwners()
        {
            try
            {
                var owners = _repository.Owner.GetAllOwners();
                var ownerResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);

                _logger.LogInfo("Owners Returned Successfully from Database");

                return Ok(ownerResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something wend wrong inside GetAllOwners action, {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOwner(Guid id)
        {
            try
            {
                var owner = _repository.Owner.GetOwner(id);

                if (owner == null)
                {
                    return NoContent();
                }

                var ownerResult = _mapper.Map<OwnerDto>(owner);
                return Ok(ownerResult);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal Server Error on {ex.Message}");
                return StatusCode(500, $"Internal Server Error, {ex.Message}");
            }

        }

        [HttpGet("{id}/detail")]
        public IActionResult GetOwnerDetail(Guid id)
        {
            try
            {
                var owner = _repository.Owner.GetOwnerDetail(id);

                if (owner == null)
                {
                    return NotFound(new { value = $"Owner not found with id : {id}", message = ""});
                }

                var ownerResult = _mapper.Map<OwnerDto>(owner);

                return Ok(ownerResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal Server Error occured, {ex.Message}");
                return StatusCode(500, new { value = "Internal server error", message = ex.Message });
            }
        }
    }
}
