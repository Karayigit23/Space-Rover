using MediatR;
using Microsoft.Extensions.Logging;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Core.Command.Planet;

public class CreatePlanetCommand:IRequest<Entity.Planet>
{
    public int Width { get; set; }
    public int Height { get; set; }
}

public class CreatePlanetCommandHandler : IRequestHandler<CreatePlanetCommand, Entity.Planet>
{
    private readonly IPlanetRepository _planetRepository;
    private readonly ILogger<CreatePlanetCommandHandler> _logger;

    public CreatePlanetCommandHandler(IPlanetRepository planetRepository,ILogger<CreatePlanetCommandHandler> logger)
    {
        _planetRepository = planetRepository;
        _logger = logger;
    }
    public async Task<Entity.Planet> Handle(CreatePlanetCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating planet with Width: {Width}, Height: {Height}", request.Width, request.Height);
        var planet = new Entity.Planet
        {
            Height = request.Height,
            Width = request.Width
        };
        await _planetRepository.AddPlanet(planet);
        _logger.LogInformation("Planet created with ID: {PlanetId}", planet.PlanetId);
        return planet;
    }

    
}