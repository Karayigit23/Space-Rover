using Microsoft.EntityFrameworkCore;
using Space_Rover.Core.Entity;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Infrastructr.Repositories;

public class PlanetRepository:IPlanetRepository
{
    private readonly AppDbContext _dbContext;

    public PlanetRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Planet> GetByIdPlanet(int id)
    {
        return await _dbContext.Planet.FindAsync(id);
    }

    public async Task<List<Planet>> GetAllPlanet()
    {
        return await _dbContext.Planet.ToListAsync();
    }

    public async Task AddAsync(Planet planet)
    {
        _dbContext.Planet.AddAsync(planet);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdatePlanet(Planet planet)
    {
        _dbContext.Planet.Update(planet);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeletePlanet(Planet id)
    {
        _dbContext.Planet.Remove(id);
        await _dbContext.SaveChangesAsync();
    }
}