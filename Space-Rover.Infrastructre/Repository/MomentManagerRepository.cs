using Space_Rover.Core.Entity;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Infrastructr.Repositories;

public class MomentManagerRepository:IMomentManager
{
    private readonly AppDbContext _dbContext;

    public MomentManagerRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async void Move(Rover rover, Direction direction)
    {
        _dbContext.Rovers.Update(rover); 
        await _dbContext.SaveChangesAsync();
        
    }
}