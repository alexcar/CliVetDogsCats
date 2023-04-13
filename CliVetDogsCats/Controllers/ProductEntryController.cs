using Application.Contracts.Request;
using Application.Contracts.Response;
using Application.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CliVetDogsCats.API.Controllers
{
    [Route("api/productEntries")]
    [ApiController]
    public class ProductEntryController : ControllerBase
    {
        private readonly ProductEntryService _service;
        private readonly IValidator<CreateProductEntryHeaderRequest> _createValidator;

        public ProductEntryController(
            ProductEntryService service, 
            IValidator<CreateProductEntryHeaderRequest> createValidator)
        {
            _service = service;
            _createValidator = createValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> ProductEntryAdd(CreateProductEntryHeaderRequest request)
        {
            var validationResult = await _createValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(x => new ErrorResponse(x.ErrorCode, x.ErrorMessage)).ToList();

                return BadRequest(errors);
            }

            await _service.ProductEntryAddAsync(request);

            return NoContent();
        }
    }
}
