using Space_Rover.Core.Entity;

namespace Space_Rover.Core.InterFaces;

public interface IPlanetRepository
{
    Task<Planet> GetByIdPlanet(int id);
    Task<List<Planet>> GetAllPlanet();
    Task AddAsync(Planet planet);
    Task UpdatePlanet(Planet planet);
    Task DeletePlanet(Planet id);
}