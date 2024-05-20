using MediatR;
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

    public CreatePlanetCommandHandler(IPlanetRepository planetRepository)
    {
        _planetRepository = planetRepository;
    }
    public async Task<Entity.Planet> Handle(CreatePlanetCommand request, CancellationToken cancellationToken)
    {
        //buraya boş girildiğinde bir hata atmak için exaption koy
        var planet = new Entity.Planet
        {
            Height = request.Height,
            Width = request.Width
        };
        await _planetRepository.AddPlanet(planet);
        return planet;
    }

    
}