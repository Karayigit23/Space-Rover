using MediatR;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Core.Command.Planet;

public class UpdatePlanetCommand:IRequest<Entity.Planet>
{
    public int Id { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    
    public class UpdatePlanetCommandHandler : IRequestHandler<UpdatePlanetCommand, Entity.Planet>
    {
        private readonly IPlanetRepository _planetRepository;

        public UpdatePlanetCommandHandler(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
        }
        public async Task<Entity.Planet> Handle(UpdatePlanetCommand request, CancellationToken cancellationToken)
        {
            var planet = await _planetRepository.GetByIdPlanet(request.Id);

            planet.Height = request.Height;
            planet.Width = request.Width;

            await _planetRepository.UpdatePlanet(planet);
            return planet;
        }
    }

}

