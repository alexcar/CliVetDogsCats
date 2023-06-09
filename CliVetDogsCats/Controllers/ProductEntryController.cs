﻿using Application.Contracts.Request;
using Application.Contracts.Response;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CliVetDogsCats.API.Controllers
{
    [Route("api/productEntries")]
    [ApiController]
    public class ProductEntryController : ControllerBase
    {
        private readonly IProductEntryService _service;
        private readonly IValidator<CreateProductEntryHeaderRequest> _createValidator;

        public ProductEntryController(
            IProductEntryService service,
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

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpGet("getProductByCode/{code}")]
        public async Task<IActionResult> GetProductByCode(string code)
        {
            return Ok(await _service.GetProductByCodeAsync(code));
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
