using MediatR;
using Microsoft.AspNetCore.Mvc;
using Space_Rover.Core.Command.Rover;
using Space_Rover.Core.Query.Rover;

namespace Space_Rover.Controllers;
[ApiController]
[Route("api/[controller]")]
public class Rover : ControllerBase
{
   private readonly IMediator _mediator;

   public Rover(IMediator mediator)
   {
      _mediator = mediator;
   }
   
   [HttpGet]
   
   public async Task<List<Core.Entity.Rover>> GetAllRover()
   {
      var Rover = await _mediator.Send(new GetAllRoverQuery());
      return Rover;
   }
   
   [HttpGet("{roverId}")]
   public async Task<Core.Entity.Rover> GetByIdRover(int Id)
   {
      var rover= await _mediator.Send(request: new GetByIdRover { Id = Id });
      return rover;
   }

   
   [HttpPost]
   public async Task AddRover ([FromBody] CreateRoverCommand rover)
   {
      await _mediator.Send(rover);
   }

   [HttpPut("{Id}")]
   public async Task UpdateRover(int Id, [FromBody] UpdateRoverCommand rover)
   {
      
      rover.ıd = Id;
      await _mediator.Send(rover);
   }

   [HttpDelete("{Id}")]
   public async Task DeleteRover(int Id)
   {
      await _mediator.Send(new DeleteRoverCommand { Id = Id });
            
   }

}