using ControledeAliens.Models;
using ControledeAliens.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControledeAliens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlienEntriesExitsController : Controller
    {
        private readonly IEarthService _earthService;

        public AlienEntriesExitsController(IEarthService earthService)
        {
            _earthService = earthService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Earth>>> GetAllEntries()
        {
            var entries = await _earthService.GetAllEntriesAsync();
            return Ok(entries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Earth>> GetEntryById(int id)
        {
            var entry = await _earthService.GetEntryByIdAsync(id);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        [HttpGet("alien/{alienId}")]
        public async Task<ActionResult<IEnumerable<Earth>>> GetEntriesByAlienId(int alienId)
        {
            var entries = await _earthService.GetEntriesByAlienIdAsync(alienId);
            return Ok(entries);
        }

        [HttpGet("daterange")]
        public async Task<ActionResult<IEnumerable<Earth>>> GetEntriesByDateRange(DateTime startDate, DateTime endDate)
        {
            var entries = await _earthService.GetEntriesByDateRangeAsync(startDate, endDate);
            return Ok(entries);
        }

        [HttpPost("entry/{alienId}")]
        public async Task<ActionResult> RegisterAlienEntry(int alienId)
        {
            await _earthService.RegisterAlienEntryAsync(alienId);
            return Ok();
        }

        [HttpPost("exit/{alienId}")]
        public async Task<ActionResult> RegisterAlienExit(int alienId)
        {
            await _earthService.RegisterAlienExitAsync(alienId);
            return Ok();
        }
    }
}
