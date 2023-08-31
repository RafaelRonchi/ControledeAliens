using ControledeAliens.Models;
using ControledeAliens.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControledeAliens.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanetService _planetService;

        public PlanetController(IPlanetService planetService)
        {
            _planetService = planetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlanets()
        {
            var planets = await _planetService.GetAllPlanetsAsync();
            return Ok(planets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanetById(int id)
        {
            var planet = await _planetService.GetPlanetByIdAsync(id);
            if (planet == null)
            {
                return NotFound();
            }
            return Ok(planet);
        }

        [HttpGet("alien/{alienId}")]
        public async Task<IActionResult> GetPlanetByAlienId(int alienId)
        {
            var planet = await _planetService.GetPlanetByAlienIdAsync(alienId);
            if (planet == null)
            {
                return NotFound();
            }
            return Ok(planet);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlanet(Planet planet)
        {
            await _planetService.CreatePlanetAsync(planet);
            return CreatedAtAction(nameof(GetPlanetById), new { id = planet.Id }, planet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlanet(int id, Planet planet)
        {
            if (id != planet.Id)
            {
                return BadRequest();
            }
            await _planetService.UpdatePlanetAsync(id, planet);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanet(int id)
        {
            await _planetService.DeletePlanetAsync(id);
            return NoContent();
        }
    }
}
