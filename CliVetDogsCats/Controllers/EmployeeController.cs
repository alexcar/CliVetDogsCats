using Application.Contracts.Request;
using Application.Contracts.Response;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using CliVetDogsCats.API.Log;

namespace CliVetDogsCats.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly ILoggerManager _logger;
        private readonly IValidator<CreateEmployeeRequest> _createValidator;
        private readonly IValidator<UpdateEmployeeRequest> _updateValidate;

        public EmployeeController(
            IEmployeeService service, 
            ILoggerManager logger,
            IValidator<CreateEmployeeRequest> validator,
            IValidator<UpdateEmployeeRequest> updateValidate)    
        {
            _service = service;
            _logger = logger;
            _createValidator = validator;
            _updateValidate = updateValidate;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var result = await _service.GetAllAsync();
            // _logger.LogInfo("End GetAll");

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpGet("{term}")]
        public async Task<IActionResult> GetByTerm(string term)
        {
            var result = await _service.GetByTermAsync(term);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest request)
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
        public async Task<IActionResult> Update([FromBody] UpdateEmployeeRequest request)
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
