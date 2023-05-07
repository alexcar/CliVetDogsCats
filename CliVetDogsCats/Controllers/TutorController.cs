using Application.Contracts.Request;
using Application.Contracts.Response;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CliVetDogsCats.API.Controllers
{
    [Route("api/tutors")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly ITutorService _service;
        private readonly IValidator<CreateTutorRequest> _createValidator;
        private readonly IValidator<UpdateTutorRequest> _updateValidator;

        public TutorController(
            ITutorService service, 
            IValidator<CreateTutorRequest> createValidator, 
            IValidator<UpdateTutorRequest> updateValidator)
        {
            _service = service;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
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

        [HttpGet("getAllTutorsHaveAnimal")]
        public async Task<IActionResult> GetAllTutorsHaveAnimal()
        {
            return Ok(await _service.GetAllTutorsHaveAnimalAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTutorRequest request)
        {
            var validationResult = await _createValidator.ValidateAsync(request);

            if (!validationResult.IsValid) 
            {
                var errors = validationResult.Errors
                    .Select(x => new ErrorResponse(x.ErrorCode, x.ErrorMessage)).ToList();
                return BadRequest(errors);
            }

            return Ok(await _service.CreateAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTutorRequest request)
        {
            var validationResult = await _updateValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(x => new ErrorResponse(x.ErrorCode, x.ErrorMessage)).ToList();
                return BadRequest(errors);
            }

            return Ok(await _service.UpdateAsync(request));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}
