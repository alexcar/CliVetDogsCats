using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CliVetDogsCats.API.Controllers
{
    [Route("api/scheduleStatus")]
    [ApiController]
    public class ScheduleStatusController : ControllerBase
    {
        private readonly IScheduleStatusService _service;

        public ScheduleStatusController(IScheduleStatusService service)
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
