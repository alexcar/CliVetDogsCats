using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CliVetDogsCats.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
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
