using MediatR;
using Microsoft.Extensions.Logging;
using Space_Rover.Core.InterFaces;
using System.Threading;
using System.Threading.Tasks;

namespace Space_Rover.Core.Command.Planet
{
    public class DeletePlanetCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeletePlanetCommandHandler : IRequestHandler<DeletePlanetCommand>
    {
        private readonly IPlanetRepository _planetRepository;
        private readonly ILogger<DeletePlanetCommandHandler> _logger;

        public DeletePlanetCommandHandler(IPlanetRepository planetRepository, ILogger<DeletePlanetCommandHandler> logger)
        {
            _planetRepository = planetRepository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeletePlanetCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleting planet with ID {PlanetId}...", request.Id);
            
            var planet = await _planetRepository.GetByIdPlanet(request.Id);
            if (planet == null)
            {
                _logger.LogWarning("Attempted to delete non-existing planet with ID {PlanetId}.", request.Id);
                return Unit.Value;
            }

            await _planetRepository.DeletePlanet(planet);
            _logger.LogInformation("Planet with ID {PlanetId} deleted successfully.", request.Id);
            
            return Unit.Value;
        }
    }
}