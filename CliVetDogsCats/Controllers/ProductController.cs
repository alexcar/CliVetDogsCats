using Application.Contracts.Request;
using Application.Contracts.Response;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CliVetDogsCats.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IValidator<CreateProductRequest> _createValidator;
        private readonly IValidator<UpdateProductRequest> _updateValidate;

        public ProductController(
            IProductService service, 
            IValidator<CreateProductRequest> createValidator, 
            IValidator<UpdateProductRequest> updateValidate)
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

        [HttpGet("getByCode/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            return Ok(await _service.GetByCodeAsync(code));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request) 
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
        public async Task<IActionResult> Update([FromBody] UpdateProductRequest request)
        {
            var validationRequest = await _updateValidate.ValidateAsync(request);

            if (!validationRequest.IsValid)
            {
                var errors = validationRequest.Errors
                    .Select(x => new ErrorResponse(x.ErrorCode, x.ErrorMessage)).ToList();
                
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
