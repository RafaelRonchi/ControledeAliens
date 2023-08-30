using ControledeAliens.Data;
using ControledeAliens.Models;
using ControledeAliens.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControledeAliens.Services
{
    public class PowerService : IPowerService
    {
        private readonly DataContext _dbContext;
        public PowerService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Power>> GetAllPowersAsync()
        {
            return await _dbContext.Powers.ToListAsync();
        }

        public async Task<Power> GetPowerByIdAsync(int id)
        {
            return await _dbContext.Powers.FindAsync(id);
        }

        public async Task CreatePowerAsync(Power power)
        {
            _dbContext.Powers.Add(power);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdatePowerAsync(int id, Power power)
        {
            if (id != power.Id)
            {
                throw new ArgumentException("IDs não correspondem.");
            }

            _dbContext.Entry(power).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePowerAsync(int id)
        {
            var power = await _dbContext.Powers.FindAsync(id);
            if (power == null) return;

            _dbContext.Powers.Remove(power);
            await _dbContext.SaveChangesAsync();
        }
    }
}
