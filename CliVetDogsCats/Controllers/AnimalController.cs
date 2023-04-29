using Application.Contracts.Request;
using Application.Contracts.Response;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CliVetDogsCats.API.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _service;
        private readonly IValidator<CreateAnimalRequest> _createValidator;
        private readonly IValidator<UpdateAnimalRequest> _updateValidate;

        public AnimalController(
            IAnimalService service, 
            IValidator<CreateAnimalRequest> createValidator, 
            IValidator<UpdateAnimalRequest> updateValidate)
        {
            _service = service;
            _createValidator = createValidator;
            _updateValidate = updateValidate;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpGet("getByTutor/{id:guid}")]
        public async Task<IActionResult> GetByTutorId(Guid id)
        {
            return Ok(await _service.GetByTutorIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAnimalRequest request)
        {
            var validationResult = await _createValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(x => new ErrorResponse(x.ErrorCode, x.ErrorMessage)).ToList();
                return BadRequest(errors);
            }

            var result = await _service.CreateAsync(request);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAnimalRequest request)
        {
            var validationResult = await _updateValidate.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(x => new ErrorResponse(x.ErrorCode, x.ErrorMessage));
                return BadRequest(errors);
            }

            var result = await _service.UpdateAsync(request);

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}
