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
        return await _dbContext.Planets.FindAsync(id);
    }

    public async Task<List<Planet>> GetAllPlanet()
    {
        return await _dbContext.Planets.ToListAsync();
    }

    public async Task AddPlanet(Planet planet)
    {
        _dbContext.Planets.AddAsync(planet);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdatePlanet(Planet planet)
    {
        _dbContext.Planets.Update(planet);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeletePlanet(Planet id)
    {
        _dbContext.Planets.Remove(id);
        await _dbContext.SaveChangesAsync();
    }
}