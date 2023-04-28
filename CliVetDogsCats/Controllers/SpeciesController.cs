using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CliVetDogsCats.API.Controllers
{
    [Route("api/species")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private readonly ISpeciesService _service;

        public SpeciesController(ISpeciesService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}
