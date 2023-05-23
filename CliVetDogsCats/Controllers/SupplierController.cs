using Application.Contracts.Request;
using Application.Contracts.Response;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using CliVetDogsCats.API.Log;

namespace CliVetDogsCats.API.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _service;
        private readonly ILoggerManager _logger;
        private readonly IValidator<CreateSupplierRequest> _createValidator;
        private readonly IValidator<UpdateSupplierRequest> _updateValidate;

        public SupplierController(
            ISupplierService service, 
            ILoggerManager logger, 
            IValidator<CreateSupplierRequest> createValidator, 
            IValidator<UpdateSupplierRequest> updateValidate)
        {
            _service = service;
            _logger = logger;
            _createValidator = createValidator;
            _updateValidate = updateValidate;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

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

        [HttpGet("report")]
        public async Task<IActionResult> Report()
        {
            return Ok(await _service.ReportAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSupplierRequest request)
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
        public async Task<IActionResult> Update([FromBody] UpdateSupplierRequest request)
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
