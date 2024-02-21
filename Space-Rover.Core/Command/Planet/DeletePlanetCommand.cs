using MediatR;
using Space_Rover.Core.Command.Rover;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Core.Command.Planet;

public class DeletePlanetCommand:IRequest
{
    public int Id { get; set; }
}

public class DeletePlanetCommandHandler : IRequestHandler<DeletePlanetCommand>
{
    private readonly IPlanetRepository _planetRepository;

    public DeletePlanetCommandHandler(IPlanetRepository planetRepository)
    {
        _planetRepository = planetRepository;
    }
    public async Task Handle(DeletePlanetCommand request, CancellationToken cancellationToken)
    {
        var Planet = await _planetRepository.GetByIdPlanet(request.Id);
        
        /* if (User == null)
         {
             throw new NotFoundException($"User with ID {request.Id} not found.");           //Buraya null gelme durumda atılan bir exception koy
         }*/

        await _planetRepository.DeletePlanet(Planet);


    }
}