using ControledeAliens.Models;

namespace ControledeAliens.Services.Interfaces
{
    public interface IPlanetService
    {
        Task<IEnumerable<Planet>> GetAllPlanetsAsync();
        Task<Planet> GetPlanetByIdAsync(int id);
        Task<Planet> GetPlanetByAlienIdAsync(int alienId);
        Task CreatePlanetAsync(Planet planet);
        Task UpdatePlanetAsync(int id, Power power);
        Task DeletePlanetAsync(int id);
    }
}
