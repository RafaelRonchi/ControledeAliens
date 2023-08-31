using ControledeAliens.Data;
using ControledeAliens.Models;
using ControledeAliens.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControledeAliens.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly DataContext _dbContext;

        public PlanetService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Planet>> GetAllPlanetsAsync()
        {
            return await _dbContext.Planets.ToListAsync();
        }

        public async Task<Planet> GetPlanetByIdAsync(int id)
        {
            return await _dbContext.Planets.FindAsync(id);
        }

        public async Task<Planet> GetPlanetByAlienIdAsync(int alienId)
        {
            var alien = await _dbContext.Aliens
                .Include(a => a.Planet)  // Incluir a propriedade de navegação Planet
                .FirstOrDefaultAsync(a => a.Id == alienId);

            if (alien != null)
            {
                var planet = alien.Planet;
                return planet;
            }

            return null;
        }
        public async Task CreatePlanetAsync(Planet planet)
        {
            _dbContext.Planets.Add(planet);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePlanetAsync(int id, Planet planet)
        {
            var existingPlanet = await _dbContext.Planets.FindAsync(id);
            if (existingPlanet != null)
            {
                existingPlanet.Name = planet.Name;
                existingPlanet.Description = planet.Description;
                existingPlanet.Population = planet.Population;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeletePlanetAsync(int id)
        {
            var planet = await _dbContext.Planets.FindAsync(id);
            if (planet != null)
            {
                _dbContext.Planets.Remove(planet);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

