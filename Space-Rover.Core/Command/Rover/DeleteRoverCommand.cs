using MediatR;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Core.Command.Rover;

public class DeleteRoverCommand:IRequest
{
    public int Id { get; set; }
}
public class DeleteRoverCommandHandler : IRequestHandler<DeleteRoverCommand>
{
    private readonly IRoverRepository _roverRepository;

    public DeleteRoverCommandHandler(IRoverRepository roverRepository)
    {
        _roverRepository = roverRepository;
    }
    public async Task Handle(DeleteRoverCommand request, CancellationToken cancellationToken)
    {
        var Rover = await _roverRepository.GetByIdRover(request.Id);
       
       /* if (User == null)
        {
            throw new NotFoundException($"User with ID {request.Id} not found.");           //Buraya null gelme durumda atılan bir exception koy
        }*/
       
        await _roverRepository.DeleteRover(Rover);
    }
}