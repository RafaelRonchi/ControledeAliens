namespace ControledeAliens.Services;

using ControledeAliens.Data;
using ControledeAliens.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AlienService : IAlienService
{
    private readonly DataContext _dbContext;

    public AlienService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Alien>> GetAllAliensAsync()
    {
        return await _dbContext.Aliens
            .Include(a => a.Planet)
            .Include(a => a.AlienPowers)
            .ThenInclude(ap => ap.Power)
            .ToListAsync();
    }

    public async Task<Alien> GetAlienByIdAsync(int id)
    {
        return await _dbContext.Aliens
            .Include(a => a.Planet)
            .Include(a => a.AlienPowers)
            .ThenInclude(ap => ap.Power)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Alien>> GetAliensByPlanetAsync(int planetId)
    {
        return await _dbContext.Aliens
            .Where(a => a.PlanetId == planetId)
            .Include(a => a.Planet)
            .Include(a => a.AlienPowers)
            .ThenInclude(ap => ap.Power)
            .ToListAsync();
    }

    public async Task<Alien> CreateAlienAsync(Alien alien)
    {
        if (alien.Planet != null && alien.Planet.Id > 0)
        {
            _dbContext.Entry(alien.Planet).State = EntityState.Unchanged;
        }

        if (alien.AlienPowers != null && alien.AlienPowers.Any())
        {
            foreach (var alienPower in alien.AlienPowers)
            {
                if (alienPower.Power.Id > 0)
                {
                    _dbContext.Powers.Attach(alienPower.Power);
                }
            }
        }

        _dbContext.Aliens.Add(alien);
        await _dbContext.SaveChangesAsync();
        return alien;
    }

    public async Task<Alien> AddSpecialPowerAsync(int alienId, int powerId)
    {
        var alien = await _dbContext.Aliens
            .Include(a => a.AlienPowers)
            .FirstOrDefaultAsync(a => a.Id == alienId);

        if (alien is null)
            throw new ArgumentException("ID do alien não existe.");

        var power = await _dbContext.Powers.FindAsync(powerId);
        if (power is null)
            throw new ArgumentException("ID do poder não existe.");

        var alienPower = new AlienPower
        {
            Alien = alien,
            Power = power
        };

        alien.AlienPowers.Add(alienPower);
        await _dbContext.SaveChangesAsync();

        return alien;
    }

    public async Task UpdateAlienAsync(int id, Alien alien)
    {
        if (id != alien.Id)
            throw new ArgumentException("ID's do alien e do path não correspondem.");

        _dbContext.Entry(alien).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAlienAsync(int id)
    {
        var alienExist = await _dbContext.Aliens.FindAsync(id);
        if (alienExist is null) return;

        _dbContext.Aliens.Remove(alienExist);
        await _dbContext.SaveChangesAsync();
    }
}
