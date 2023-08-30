using ControledeAliens.Data;
using ControledeAliens.Models;
using ControledeAliens.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControledeAliens.Services
{
    public class EarthService : IEarthService
    {
        private readonly DataContext _dbContext;

        public EarthService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Earth>> GetAllEntriesAsync()
        {
            return await _dbContext.AlienEntriesExits.ToListAsync();
        }

        public async Task<Earth> GetEntryByIdAsync(int id)
        {
            return await _dbContext.AlienEntriesExits.FindAsync(id);
        }

        public async Task<IEnumerable<Earth>> GetEntriesByAlienIdAsync(int alienId)
        {
            return await _dbContext.AlienEntriesExits.Where(e => e.AlienId == alienId).ToListAsync();
        }

        public async Task<IEnumerable<Earth>> GetEntriesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbContext.AlienEntriesExits.Where(e => e.EntryTime >= startDate && e.ExitTime <= endDate).ToListAsync();
        }

        public async Task RegisterAlienEntryAsync(int alienId)
        {
            var entry = new Earth
            {
                AlienId = alienId,
                EntryTime = DateTime.Now
            };

            _dbContext.AlienEntriesExits.Add(entry);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RegisterAlienExitAsync(int alienId)
        {
            var entry = await _dbContext.AlienEntriesExits.FirstOrDefaultAsync(e => e.AlienId == alienId && e.ExitTime.Year == 1);
            if (entry != null)
            {
                entry.ExitTime = DateTime.Now;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
