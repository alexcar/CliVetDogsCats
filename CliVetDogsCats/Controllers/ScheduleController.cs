using Application.Contracts.Request;
using Application.Contracts.Response;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CliVetDogsCats.API.Controllers
{
    [Route("api/schedules")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _service;
        private readonly IValidator<CreateScheduleRequest> _createValidator;
        private readonly IValidator<ScheduleStartRequest> _scheduleStartValidator;
        private readonly IValidator<ScheduleEndRequest> _scheduleEndValidator;
        private readonly IValidator<ScheduleCancellationRequest> _scheduleCancellationValidator;

        public ScheduleController(
            IScheduleService service, 
            IValidator<CreateScheduleRequest> createValidator, 
            IValidator<ScheduleStartRequest> scheduleStartValidator, 
            IValidator<ScheduleEndRequest> scheduleEndValidator, 
            IValidator<ScheduleCancellationRequest> scheduleCancellationValidator)
        {
            _service = service;
            _createValidator = createValidator;
            _scheduleStartValidator = scheduleStartValidator;
            _scheduleEndValidator = scheduleEndValidator;
            _scheduleCancellationValidator = scheduleCancellationValidator;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateScheduleRequest request)
        {
            var validationResult = await _createValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(x => new ErrorResponse(x.ErrorCode, x.ErrorMessage)).ToList();
                return BadRequest(errors);
            }

            await _service.CreateAsync(request);
            
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> ScheduleStart([FromBody] ScheduleStartRequest request)
        {
            var validationResult = await _scheduleStartValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(x => new ErrorResponse(x.ErrorCode, x.ErrorMessage)).ToList();
                return BadRequest(errors);
            }

            await _service.ScheduleStart(request);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> ScheduleEnd([FromBody] ScheduleEndRequest request)
        {
            var validationResult = await _scheduleEndValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(x => new ErrorResponse(x.ErrorCode, x.ErrorMessage)).ToList();
                return BadRequest(errors);
            }

            await _service.ScheduleEnd(request);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> ScheduleCancellation([FromBody] ScheduleCancellationRequest request)
        {
            var validationResult = await _scheduleCancellationValidator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(x => new ErrorResponse(x.ErrorCode, x.ErrorMessage)).ToList();
                return BadRequest(errors);
            }

            await _service.ScheduleCancellation(request);
            
            return NoContent();
        }
    }
}
