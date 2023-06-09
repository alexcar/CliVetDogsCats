﻿using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CliVetDogsCats.API.Controllers
{
    [Route("api/races")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly IRaceService _service;

        public RaceController(IRaceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("getRacesBySpecies/{id:guid}")]
        public async Task<IActionResult> GetRaceBySpeciesId(Guid id)
        {
            return Ok(await _service.GetRaceBySpeciesIdAsync(id));
        }

    }
}
