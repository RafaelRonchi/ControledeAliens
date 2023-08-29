using ControledeAliens.Models;

namespace ControledeAliens.Services.Interfaces
{
    public interface IPowerService
    {
        Task<IEnumerable<Power>> GetAllPowersAsync();
        Task<Power> GetPowerByIdAsync(int id);
        Task CreatePowerAsync(Power power);
        Task UpdatePowerAsync(int id, Power power);
        Task DeletePowerAsync(int id);
    }
}
