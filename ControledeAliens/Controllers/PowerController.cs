using ControledeAliens.Models;
using ControledeAliens.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControledeAliens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerController :ControllerBase
    {
        private readonly IPowerService _powerService;

        public PowerController (IPowerService powerService)
        {
            _powerService = powerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPowers()
        {
            var powers = await _powerService.GetAllPowersAsync();
            return Ok(powers);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPowerById(int id)
        {
            var power = await _powerService.GetPowerByIdAsync(id);

            if (power == null) return NotFound();

            return Ok(power);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePower([FromBody] Power power)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); 


            await _powerService.CreatePowerAsync(power);
            return CreatedAtAction("GetPowerById", new { id = power.Id }, power);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePower(int id, [FromBody] Power power)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != power.Id) return BadRequest();

            await _powerService.UpdatePowerAsync(id, power);
            return Ok(power);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePower(int id)
        {
            await _powerService.DeletePowerAsync(id);
            return Ok();
        }
    }
}
