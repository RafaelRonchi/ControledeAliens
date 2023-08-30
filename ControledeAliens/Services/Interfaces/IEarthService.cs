using ControledeAliens.Models;

namespace ControledeAliens.Services.Interfaces
{
    public interface IEarthService
    {
        Task<IEnumerable<Earth>> GetAllEntriesAsync();
        Task<Earth> GetEntryByIdAsync(int id);
        Task<IEnumerable<Earth>> GetEntriesByAlienIdAsync(int alienId);
        Task<IEnumerable<Earth>> GetEntriesByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task RegisterAlienEntryAsync(int alienId);
        Task RegisterAlienExitAsync(int alienId);
    }
}
