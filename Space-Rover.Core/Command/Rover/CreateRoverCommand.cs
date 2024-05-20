using MediatR;
using Space_Rover.Core.Entity;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Core.Command.Rover;

public class CreateRoverCommand:IRequest<Entity.Rover>
{
   
    
    public string RoverName { get; set; }
    public int PlanetSurfaceId { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Direction LookingDirection { get; set; }

}

public class CreateRoverHandler : IRequestHandler<CreateRoverCommand, Entity.Rover>
{
    private readonly IRoverRepository _roverRepository;

    public CreateRoverHandler(IRoverRepository roverRepository)
    {
        _roverRepository = roverRepository;
    }
    
    public async Task<Entity.Rover> Handle(CreateRoverCommand request, CancellationToken cancellationToken)
    {
        //buraya boş girilme durumda bir hata atmak için exaption koyulabilir
        var rover = new Entity.Rover
        {
            RoverName = request.RoverName,
            PlanetSurfaceId = request.PlanetSurfaceId,
            //X = request.X,
            // Y = request.Y,
            //LookingDirection = request.LookingDirection
        };
       
        await _roverRepository.AddRover(rover);
        return rover;
    }
}