﻿using CVGeneratorApp.Api.Services.Abstactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVGeneratorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorsController : ControllerBase
    {
        private readonly ISectorService _sectorService;

        public SectorsController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _sectorService.GetAllAsync());
        }
    }
}