using ControledeAliens.Models;

namespace ControledeAliens.Services.Interfaces
{
    public interface IAlienService
    {
        Task<IEnumerable<Alien>> GetAllAliensAsync();
        Task<Alien> GetAlienByIdAsync(int id);
        Task<IEnumerable<Alien>> GetAliensByPlanetAsync(int planetId);
        Task<Alien> CreateAlienAsync(Alien alien);
        Task<Alien> AddSpecialPowerAsync(int alienId, int powerId);
        Task UpdateAlienAsync(int id, Alien alien);
        Task DeleteAlienAsync(int id);
    }
}
