using MediatR;
using Microsoft.Extensions.Logging;
using Space_Rover.Core.Entity;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Core.Command.Rover;

public class CreateRoverCommand:IRequest<Entity.Rover>
{
   
    
    public string RoverName { get; set; }
    public int PlanetSurfaceId { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Direction LookingDirection { get; set; }

}

public class CreateRoverHandler : IRequestHandler<CreateRoverCommand, Entity.Rover>
{
    private readonly IRoverRepository _roverRepository;
    private readonly ILogger<CreateRoverHandler> _logger;


    public CreateRoverHandler(IRoverRepository roverRepository,ILogger<CreateRoverHandler> logger)
    {
        _roverRepository = roverRepository;
        _logger = logger;
    }
    
    public async Task<Entity.Rover> Handle(CreateRoverCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating rover with name: {RoverName}, Planet Surface ID: {PlanetSurfaceId}, X: {X}, Y: {Y}, Looking Direction: {LookingDirection}", 
            request.RoverName, request.PlanetSurfaceId, request.X, request.Y, request.LookingDirection);

       
        var rover = new Entity.Rover
        {
            RoverName = request.RoverName,
            PlanetSurfaceId = request.PlanetSurfaceId,
           
        };
       
        await _roverRepository.AddRover(rover);
        _logger.LogInformation("Rover created with ID: {RoverId}", rover.RoverId);

        return rover;
    }
}