
using Microsoft.AspNetCore.Mvc;
using Space_Rover.Core.Entity;
using Space_Rover.Core.InterFaces;
using Space_Rover.Infrastructr;
using Space_Rover.Infrastructr.Repositories;

namespace Space_Rover.Controllers;
[Route("api/[controller]")]
[ApiController]

public class MoveController : ControllerBase
{
    private AppDbContext _dbContext;
    private readonly IMomentManager _momentManager;
    private readonly IRoverRepository _roverRepository;

    public MoveController(IMomentManager momentManager, IRoverRepository roverRepository,AppDbContext dbContext)
    {
        _momentManager = momentManager;
        _roverRepository = roverRepository;
        _dbContext = dbContext;
    }

    [HttpPut("{id}/{direction}")]
    public async Task<IActionResult> Put(int id, Direction direction)
    {
        Core.Entity.Rover rover = await _roverRepository.GetByIdRover(id);
        if (rover == null)
        {
            return NotFound("Rover not found");
        }

        _momentManager.Move(rover, direction);
        
        _dbContext.SaveChanges();

        return Ok(new { X = rover.X, Y = rover.Y });
    }
}
