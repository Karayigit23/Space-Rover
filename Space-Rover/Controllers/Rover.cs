using MediatR;
using Microsoft.AspNetCore.Mvc;

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
   
   public async Task<List<Rover>> GetAllRover()
   {
      var Rover = await _mediator.Send(new GetAllUserQuery());
      return Rover;
   }

}