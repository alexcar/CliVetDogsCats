using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CliVetDogsCats.API.Controllers
{
    [Route("api/scheduleService")]
    [ApiController]
    public class ScheduleServiceController : ControllerBase
    {
        private readonly IScheduleServiceService _service;

        public ScheduleServiceController(IScheduleServiceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
    }
}
