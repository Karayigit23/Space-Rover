using MediatR;
using Space_Rover.Core.Entity;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Core.Command.Rover;

public class UpdateRoverCommand:IRequest<Entity.Rover>
{
    public int ıd { get; set; }
    public string RoverName { get; set; }
    public int PlanetSurfaceId { get; set; }
    

}

public class UpdateRoverCommandHandler : IRequestHandler<UpdateRoverCommand, Entity.Rover>
{
    private readonly IRoverRepository _roverRepository;

    public UpdateRoverCommandHandler(IRoverRepository roverRepository)
    {
        _roverRepository = roverRepository;
    }
    public async Task<Entity.Rover> Handle(UpdateRoverCommand request, CancellationToken cancellationToken)
    {
        var rover = await _roverRepository.GetByIdRover(request.ıd);

        rover.RoverName = request.RoverName;
        rover.PlanetSurfaceId = request.PlanetSurfaceId;
        

        await _roverRepository.UpdateRover(rover);
        return rover;

    }
}