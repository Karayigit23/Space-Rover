using MediatR;
using Microsoft.Extensions.Logging;
using Space_Rover.Core.Entity;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Core.Command.Rover;

public class UpdateRoverCommand:IRequest<Entity.Rover>
{
    public int ıd { get; set; }
    public string RoverName { get; set; }
    public int PlanetSurfaceId { get; set; }
    

}

public class UpdateRoverCommandHandler : IRequestHandler<UpdateRoverCommand, Entity.Rover>
{
    private readonly IRoverRepository _roverRepository;
    private readonly ILogger<UpdateRoverCommandHandler> _logger;

    public UpdateRoverCommandHandler(IRoverRepository roverRepository,ILogger<UpdateRoverCommandHandler> logger)
    {
        _roverRepository = roverRepository;
        _logger = logger;
    }
    public async Task<Entity.Rover> Handle(UpdateRoverCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating rover with ID {RoverId}...", request.ıd);
        var rover = await _roverRepository.GetByIdRover(request.ıd);

        if (rover == null)
        {
            _logger.LogWarning("Attempted to update non-existing rover with ID {RoverId}.", request.ıd);
            return null;
        }
        
        
        rover.RoverName = request.RoverName;
        rover.PlanetSurfaceId = request.PlanetSurfaceId;
        

        await _roverRepository.UpdateRover(rover);
        _logger.LogInformation("Rover with ID {RoverId} updated successfully.", request.ıd);
        return rover;

    }
}