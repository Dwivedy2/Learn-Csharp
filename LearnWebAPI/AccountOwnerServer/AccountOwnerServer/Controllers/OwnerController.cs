using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
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

        [HttpGet("{id}", Name = "OwnerById")]
        public IActionResult GetOwner(Guid id)
        {
            try
            {
                var owner = _repository.Owner.GetOwner(id);

                if (owner == null)
                {
                    return NotFound();
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

                return Ok(new { value = ownerResult, message = "Owner found"});
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal Server Error occured, {ex.Message}");
                return StatusCode(500, new { value = "Internal server error", message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CreateOwner([FromBody]OwnerForCreationDto owner)
        {
            try
            {
                if (owner is null)
                {
                    return BadRequest(new { value = owner, message = "owner object is null" });
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(new { value = ModelState, message = "model state is not valid" });
                }

                var mappedOwner = _mapper.Map<Owner>(owner);

                _repository.Owner.CreateOwner(mappedOwner);

                _repository.Save();

                return StatusCode(201, new { value = owner, message = "Owner successfully created" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal server error, {ex.Message}");
                return StatusCode(500, new { value = "", message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody]OwnerForUpdateDto owner)
        {
            try
            {
                if (owner is null)
                {
                    return BadRequest(new { value = owner, message = "owner object can not be null" });
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(new { value = ModelState, message = "model state is not valid" });
                }

                var dbOwner = _repository.Owner.GetOwner(id);

                if (dbOwner is null)
                {
                    return NotFound(new { value = dbOwner, message = "owner is not registered." });
                }

                _mapper.Map(owner, dbOwner);

                _repository.Owner.UpdateOwner(dbOwner);

                _repository.Save();

                return Ok(new { value = owner, message = "Owner is updated successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal Server Error, {ex.Message}");
                return StatusCode(500, new { value = "", message = ex.Message });
            }

        }

        [HttpDelete("{id}/delete")]
        public IActionResult DeleteOwner(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { value = ModelState, message = "model state is not valid" });
                }

                var dbOwner = _repository.Owner.GetOwner(id);

                if (dbOwner is null)
                {
                    return BadRequest(new { value = dbOwner, message = $"Id is invalid, owner do not exists for this id {id}" });
                }

                _repository.Owner.DeleteOwner(dbOwner);

                _repository.Save();

                return Ok(new { value = dbOwner, message = "Owner deleted successfully"});
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal Server Error, {ex.Message}");
                return StatusCode(500, new { value = "", message = ex.Message});
            }
        }
    }
}
