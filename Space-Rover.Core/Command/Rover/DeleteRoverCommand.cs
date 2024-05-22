using MediatR;
using Microsoft.Extensions.Logging;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Core.Command.Rover;

public class DeleteRoverCommand:IRequest
{
    public int Id { get; set; }
}
public class DeleteRoverCommandHandler : IRequestHandler<DeleteRoverCommand>
{
    private readonly IRoverRepository _roverRepository;
    private readonly ILogger<DeleteRoverCommandHandler> _logger;


    public DeleteRoverCommandHandler(IRoverRepository roverRepository, ILogger<DeleteRoverCommandHandler> logger)
    {
        _roverRepository = roverRepository;
        _logger = logger;
    }
    public async Task<Unit> Handle(DeleteRoverCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation(message:"Rover Deleted");
        var Rover = await _roverRepository.GetByIdRover(request.Id);
       
        if (Rover == null)
        {
            _logger.LogWarning("Attempted to delete non-existing rover: {RoverId}", request.Id);
            return Unit.Value;
        }
       
        await _roverRepository.DeleteRover(Rover);
        _logger.LogInformation("Rover deleted: {RoverId}", request.Id);
        return Unit.Value;
    }
}