using Microsoft.AspNetCore.Mvc;
using Space_Rover.Core.Entity;
using Space_Rover.Infrastructr.Repositories;

namespace Space_Rover.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MoveController : ControllerBase
{
    private readonly MomentManager _momentManager;
    private readonly RoverRepository _roverRepository;

    public MoveController(MomentManager momentManager, RoverRepository roverRepository)
    {
        _momentManager = momentManager;
        _roverRepository = roverRepository;
    }

    [HttpPut("{id}/{direction}")]
    public async  Task<IActionResult> Put(int id, Direction direction)
    {
        Core.Entity.Rover rover = await _roverRepository.GetByIdRover(id);
      /*  if (rover == null)
        {
            return NotFound("Rover not found");
        }*/
         _momentManager.Move(rover, direction);

        return Ok(new { X = rover.X, Y = rover.Y });
    }
}