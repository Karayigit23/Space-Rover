namespace Space_Rover.Core.Entity;


public class Rover
{
    public int RoverId { get; set; }
    public string RoverName { get; set; }
    public int PlanetSurfaceId { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Direction LookingDirection { get; set; }




    public Rover() 
    {
        X = 0;
        Y = 0;
        LookingDirection = Direction.North;
    }
    
    
    
    public string GetCurrentLocation()
    {
        return $"{X}X{Y} ==> {LookingDirection}";
    }
    
    
   
   
}