using Microsoft.EntityFrameworkCore;
using Space_Rover.Core.Entity;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Infrastructr.Repositories;

public class RoverRepository:IRoverRepository
{
    private readonly AppDbContext _dbContex;

    public RoverRepository(AppDbContext dbContext)
    {
        _dbContex = dbContext;

    }
    
    
    
    public async Task<Rover> GetByIdRover(int id)
    {
        return await _dbContex.Rovers.FindAsync(id);
    }

    public async Task<List<Rover>> GetAllRover()
    {
        return await _dbContex.Rovers.ToListAsync();
    }

    public async Task AddRover(Rover rover)
    { 
        _dbContex.Rovers.AddAsync(rover);
        await _dbContex.SaveChangesAsync();
    }

    public async Task UpdateRover(Rover rover)
    {
        _dbContex.Rovers.Update(rover);
        await _dbContex.SaveChangesAsync();
    }

    public async Task DeleteRover(Rover id)
    {
        _dbContex.Rovers.Remove(id);
        await _dbContex.SaveChangesAsync();
    }

  
}