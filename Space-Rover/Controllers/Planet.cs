using MediatR;
using Microsoft.AspNetCore.Mvc;
using Space_Rover.Core.Command.Planet;
using Space_Rover.Core.Query.Planet;

namespace Space_Rover.Controllers;
[ApiController]
[Route("api/[controller]")]
public class Planet : ControllerBase
{
    private readonly IMediator _mediator;

    public Planet(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
   
    public async Task<List<Core.Entity.Planet>> GetAllPlanet()
    {
        var Planet = await _mediator.Send(new GetAllPlanetQuery());
        return Planet;
    }
    [HttpGet("{planetId}")]
    public async Task<Core.Entity.Planet> GetByIdPlanet(int planetId)
    {
        var Planet= await _mediator.Send(request: new GetByIdPlanetQuery() { Id = planetId });
        return Planet;
    }
    [HttpPost]
    public async Task AddPlanet ([FromBody] CreatePlanetCommand planet)
    {
        await _mediator.Send(planet);
    }
    
    [HttpPut("{Id}")]
    
    public async Task UpdatePlanet(int Id, [FromBody] UpdatePlanetCommand planet)
    {
        planet.Id= Id;
        await _mediator.Send(planet);
    }

    [HttpDelete("{Id}")]
    public async Task DeletePlanet(int Id)
    {
        await _mediator.Send(new DeletePlanetCommand() { Id = Id });
            
    }


}