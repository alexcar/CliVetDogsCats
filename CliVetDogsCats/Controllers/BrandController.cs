using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CliVetDogsCats.API.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _service;

        public BrandController(IBrandService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{categoryId:guid}")]
        public async Task<IActionResult> GetByCategoryId(Guid categoryId)
        {
            return Ok(await _service.GetByCategoryIdAsync(categoryId));
        }
    }
}
