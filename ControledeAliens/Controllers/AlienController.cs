using ControledeAliens.Models;
using ControledeAliens.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControledeAliens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlienController : ControllerBase
    {
        private readonly IAlienService _alienService;

        public AlienController(IAlienService alienService)
        {
            _alienService = alienService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alien>>> GetAllGetAllAliensAsync()
        {
            var aliens = await _alienService.GetAllAliensAsync();
            return Ok(aliens);
        }
        [HttpGet]
        [Route("Alien/{id}")]
        public async Task<ActionResult<Alien>> GetAlienByIdAsync(int id)
        {
            var alien = await _alienService.GetAlienByIdAsync(id);
            if (alien == null) return NotFound();
            return Ok(alien);
        }
        [HttpGet]
        [Route("{planet}")]
        public async Task<ActionResult<IEnumerable<Alien>>> GetAliensByPlanetAsync(int planetId)
        {
            var alienPlanet = await _alienService.GetAliensByPlanetAsync(planetId);
            if (alienPlanet == null) return NotFound();
            return Ok(alienPlanet);
        }
        [HttpPost]
        [Route("{id}")]
        public async Task<ActionResult<Alien>> AddSpecialPowerAsync(int id, int powerId)
        {
            var alienpower = await _alienService.AddSpecialPowerAsync(id, powerId);
            return Ok(alienpower);
        }
        [HttpPost]
        public async Task<ActionResult<Alien>> CreateAlienAsync(Alien alien)
        {
            await _alienService.CreateAlienAsync(alien);
            return Ok(alien);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Alien>> DeleteAlienAsync(int id)
        {
            await _alienService.DeleteAlienAsync(id);
            return Ok();
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Alien>> UpdateAlienAsync(int id, Alien alien)
        {
            await _alienService.UpdateAlienAsync(id, alien);
            return Ok();

        }
    }
}
