using Space_Rover.Core.Entity;

namespace Space_Rover.Core.InterFaces;

public interface IRoverRepository
{
    Task<Rover> GetByIdRover(int id);
    Task<List<Rover>> GetAllRover();
    Task AddRover(Rover rover);
    Task UpdateRover(Rover rover);
    Task DeleteRover(int id);
}