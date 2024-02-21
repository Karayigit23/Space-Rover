using MediatR;
using Microsoft.Extensions.Logging;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Core.Query.Rover;

public class GetByIdRover:IRequest<Entity.Rover>
{
    public int Id { get; set; }
}
public class GetByIdRoverHandler : IRequestHandler<GetByIdRover, Entity.Rover>
{
    private readonly IRoverRepository _roverRepository;
    private readonly ILogger<GetByIdRoverHandler> _logger;
    public GetByIdRoverHandler(IRoverRepository roverRepository,ILogger<GetByIdRoverHandler>
        logger)
    {
        _roverRepository = roverRepository;
        _logger = logger;
    }
    public async Task<Entity.Rover> Handle(GetByIdRover request, CancellationToken cancellationToken)
    {
  
        _logger.LogInformation(message:$"{request.Id} Rover came");
        var result = await _roverRepository.GetByIdRover(request.Id);
        /*if (result==null)
        {
   
            throw new NotFoundException($"user not found userId: {request.Id}");   //buraya exaption handler konulabilir
        }*/

        return result;
    }
}

