using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CliVetDogsCats.API.Controllers
{
    [Route("api/animalsizes")]
    [ApiController]
    public class AnimalSizeController : ControllerBase
    {
        private readonly IAnimalSizeService _service;

        public AnimalSizeController(IAnimalSizeService service)
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
