namespace Space_Rover.Core.Entity;

//önce rover oluştur luşturduğun rovera Id ile Moment controllera eriş 
public class Rover
{
    public int RoverId { get; set; }
    public string RoverName { get; set; }
    public int PlanetSurfaceId { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Direction LookingDirection { get; set; }




    public Rover() //arac her zaman 0,0 ve kuzeye bakarak oluşmalı
    {
        X = 0;
        Y = 0;
        LookingDirection = Direction.North;
    }
    
    public void Move(Direction direction)
    {
        var momentManager = new MomentManager();
        momentManager.Move(this, direction);
    }

    
    
    
    public string GetCurrentLocation()
    {
        return $"{X}X{Y} ==> {LookingDirection}";
    }
    
    
   
   
}