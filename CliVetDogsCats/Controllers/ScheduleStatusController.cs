using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CliVetDogsCats.API.Controllers
{
    [Route("api/scheduleStatus")]
    [ApiController]
    public class ScheduleStatusController : ControllerBase
    {
        private readonly ScheduleStatusService _service;

        public ScheduleStatusController(ScheduleStatusService service)
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
