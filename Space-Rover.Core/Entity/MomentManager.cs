using Space_Rover.Core.InterFaces;

namespace Space_Rover.Core.Entity;

public class MomentManager : IMomentManager
{
    public void MoveNorth(Rover rover )
    {
        if (rover.LookingDirection==Direction.North)
            
            
        {
           rover.Y += 1;
				
        }
        else
        {
            rover.LookingDirection = Direction.North;
        }
			
    }
    

    public void MoveSouth(Rover rover )
    {
        if (rover.LookingDirection==Direction.South)
        {
          rover.Y -= 1;
        }
        else
        {
          rover.LookingDirection = Direction.South;
        }
    }
    public void MoveEast(Rover rover)
    {
        if (rover.LookingDirection == Direction.East)
        {
            rover.X += 1;

        }
        else
        {
            rover.LookingDirection = Direction.East;
        }
    }
    public void MoveWest(Rover rover)
    {
        if (rover.LookingDirection==Direction.West)
        {
            rover.X -= 1;

        }
        else
        {
            rover.LookingDirection = Direction.West;
        }
    }
    
    public void Move(Rover rover, Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                MoveNorth(rover);
                break;
            case Direction.East:
                MoveEast(rover);
                break;
            case Direction.South:
                MoveSouth(rover);
                break;
            case Direction.West:
                MoveWest(rover);
                break;
            default:
                throw new InvalidOperationException("Invalid direction.");
        }
    }
}