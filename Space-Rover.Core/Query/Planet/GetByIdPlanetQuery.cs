using MediatR;
using Microsoft.Extensions.Logging;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Core.Query.Planet;

public class GetByIdPlanetQuery:IRequest<Entity.Planet>
{
    public int Id { get; set; }
}

public class GetByIdPlanetQueryHandler : IRequestHandler<GetByIdPlanetQuery, Entity.Planet>
{
    private readonly IPlanetRepository _planetRepository;
    private readonly ILogger<GetByIdPlanetQueryHandler> _logger;

    public GetByIdPlanetQueryHandler(IPlanetRepository planetRepository, ILogger<GetByIdPlanetQueryHandler>  logger)
    {
        _logger = logger;
        _planetRepository = planetRepository;
    }
    public async Task<Entity.Planet> Handle(GetByIdPlanetQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(message:$"{request.Id} Planet came");
        var Planet = await _planetRepository.GetByIdPlanet(request.Id);
        /*if (result==null)
       {
  
           throw new NotFoundException($"user not found userId: {request.Id}");   //buraya exaption handler konulabilir
       }*/
        return Planet;
    }
}