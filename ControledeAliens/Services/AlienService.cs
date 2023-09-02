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
    // Retorna todos os aliens
    public async Task<IEnumerable<Alien>> GetAllAliensAsync()
    {
        return await _dbContext.Aliens
        .Include(a => a.Planet) 
        .Include(a => a.Powers) 
        .ToListAsync();
    }

    // Retorna um alien por id
    public async Task<Alien> GetAlienByIdAsync(int id)
    {
        return await _dbContext.Aliens
         .Include(a => a.Planet)
         .Include(a => a.Powers)
         .FirstOrDefaultAsync(a => a.Id == id);
    }

    // Retorna todos os aliens por planeta
    public async Task<IEnumerable<Alien>> GetAliensByPlanetAsync(int planetId)
    {
        return await _dbContext.Aliens
            .Where(a => a.PlanetId == planetId)
            .Include(a => a.Planet)
        .Include(a => a.Powers).ToListAsync();
    }

    // Add poder
    public async Task<Alien> AddSpecialPowerAsync(int id, Power power)
    {
        var alienExist = await _dbContext.Aliens.FindAsync(id);
        if (alienExist is null)  throw new ArgumentException("ID do alien não existe.");

        var powerExist = await _dbContext.Powers.FindAsync(power);
        if (powerExist is null)  throw new ArgumentException("ID do poder não existe.");

        alienExist.Powers.Add(powerExist); // Adicione o poder existente ao alien
        await _dbContext.SaveChangesAsync();
        return alienExist;
    }




    // Criar alien
    public async Task<Alien> CreateAlienAsync(Alien alien)
    {
        
        if (alien.Planet != null && alien.Planet.Id > 0)
        {
            _dbContext.Entry(alien.Planet).State = EntityState.Unchanged;
        }

        
        if (alien.Powers != null && alien.Powers.Any())
        {
            foreach (var power in alien.Powers)
            {
                if (power.Id > 0)
                {
                    _dbContext.Entry(power).State = EntityState.Unchanged;
                }
            }
        }

        _dbContext.Aliens.Add(alien);
        await _dbContext.SaveChangesAsync();
        return alien;
    }


    // Del alien
    public async Task DeleteAlienAsync(int id)
    {
        var alienExist = await _dbContext.Aliens.FindAsync(id);
        if (alienExist is null) return;

        _dbContext.Aliens.Remove(alienExist);
        await _dbContext.SaveChangesAsync();
    }

    // Atualiza alien
    public async Task UpdateAlienAsync(int id, Alien alien)
    {
        if (id != alien.Id) throw new ArgumentException("ID's do alien e do path não correspondem.");

        _dbContext.Entry(alien).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
