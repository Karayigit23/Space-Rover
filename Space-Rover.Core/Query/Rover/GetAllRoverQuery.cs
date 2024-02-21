using MediatR;
using Microsoft.Extensions.Logging;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Core.Query.Rover;

public class GetAllRoverQuery:IRequest<List<Entity.Rover>>
{
    public class GetAllRoverQueryHandler : IRequestHandler<GetAllRoverQuery, List<Entity.Rover>>
    {
        private readonly IRoverRepository _RoverRepository;
        private readonly ILogger<GetAllRoverQueryHandler> _logger;

        public GetAllRoverQueryHandler(IRoverRepository roverRepository, ILogger<GetAllRoverQueryHandler> logger)
        {
            _RoverRepository = roverRepository;
            _logger = logger;
        }



        public async Task<List<Entity.Rover>> Handle(GetAllRoverQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(message: "All the Rover have came");
            return await _RoverRepository.GetAllRover();

        }


    }
}