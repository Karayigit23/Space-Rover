using MediatR;
using Microsoft.Extensions.Logging;
using Space_Rover.Core.Entity;
using Space_Rover.Core.InterFaces;
using System.Threading;
using System.Threading.Tasks;

namespace Space_Rover.Core.Command.Planet
{
    public class UpdatePlanetCommand : IRequest<Entity.Planet>
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class UpdatePlanetCommandHandler : IRequestHandler<UpdatePlanetCommand, Entity.Planet>
    {
        private readonly IPlanetRepository _planetRepository;
        private readonly ILogger<UpdatePlanetCommandHandler> _logger;

        public UpdatePlanetCommandHandler(IPlanetRepository planetRepository, ILogger<UpdatePlanetCommandHandler> logger)
        {
            _planetRepository = planetRepository;
            _logger = logger;
        }
        

        public async Task<Entity.Planet> Handle(UpdatePlanetCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating planet with ID {PlanetId}...", request.Id);
            var planet = await _planetRepository.GetByIdPlanet(request.Id);

            if (planet == null)
            {
                _logger.LogWarning("Attempted to update non-existing planet with ID {PlanetId}.", request.Id);
                return null;
            }

            planet.Height = request.Height;
            planet.Width = request.Width;

            await _planetRepository.UpdatePlanet(planet);
            _logger.LogInformation("Planet with ID {PlanetId} updated successfully.", request.Id);
            return planet;
        }
    }
}