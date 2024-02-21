using MediatR;
using Microsoft.Extensions.Logging;
using Space_Rover.Core.InterFaces;
using Space_Rover.Core.Query.Rover;

namespace Space_Rover.Core.Query.Planet;

public class GetAllPlanetQuery:IRequest<List<Entity.Planet>>
{
  public class GetAllPlanetQueryHandler:IRequestHandler<GetAllPlanetQuery,List<Entity.Planet>>
  {
    private readonly IPlanetRepository _planetRepository;
    private readonly ILogger<GetAllPlanetQueryHandler> _logger;

    public GetAllPlanetQueryHandler(IPlanetRepository planetRepository, ILogger<GetAllPlanetQueryHandler> logger)
    {
      _logger = logger;
      _planetRepository = planetRepository;
    }
    public async Task<List<Entity.Planet>> Handle(GetAllPlanetQuery request, CancellationToken cancellationToken)
    {
      _logger.LogInformation(message: "All the Planet have came");
      return await _planetRepository.GetAllPlanet();
    }
  }
}