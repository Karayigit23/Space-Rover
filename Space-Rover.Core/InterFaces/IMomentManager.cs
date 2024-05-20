using Space_Rover.Core.Entity;

namespace Space_Rover.Core.InterFaces;

public interface IMomentManager
{
    void Move(Rover rover, Direction direction);
}