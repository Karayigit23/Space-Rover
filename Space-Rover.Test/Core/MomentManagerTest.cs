using Space_Rover.Core.Entity;

namespace Space_Rover.Test.Core.Entity
{
    public class MomentManagerTest
    {
        [Test]
        public void MoveNorth_RoverLookingNorth_IncrementsY()   
        {
           
            var rover = new Rover { LookingDirection = Direction.North, Y = 0 };
            var momentManager = new MomentManager();

           
            momentManager.MoveNorth(rover);

            
            Assert.AreEqual(1, rover.Y);
        }

        [Test]
        public void MoveNorth_RoverNotLookingNorth_ChangesLookingDirectionToNorth()
        {
            
            var rover = new Rover { LookingDirection = Direction.South };
            var momentManager = new MomentManager();

        
            momentManager.MoveNorth(rover);

         
            Assert.AreEqual(Direction.North, rover.LookingDirection);
        }

        [Test]
        public void MoveSouth_RoverLookingSouth_DecrementsY()
        {
           
            var rover = new Rover { LookingDirection = Direction.South, Y = 1 };
            var momentManager = new MomentManager();
            
            momentManager.MoveSouth(rover);
            
            Assert.AreEqual(0, rover.Y);
        }

        [Test]
        public void MoveSouth_RoverNotLookingSouth_ChangesLookingDirectionToSouth()
        {
        
            var rover = new Rover { LookingDirection = Direction.East };
            var momentManager = new MomentManager();

       
            momentManager.MoveSouth(rover);

          
            Assert.AreEqual(Direction.South, rover.LookingDirection);
        }

        [Test]
        public void MoveEast_RoverLookingEast_IncrementsX()
        {
         
            var rover = new Rover { LookingDirection = Direction.East, X = 0 };
            var momentManager = new MomentManager();

          
            momentManager.MoveEast(rover);

           
            Assert.AreEqual(1, rover.X);
        }

        [Test]
        public void MoveEast_RoverNotLookingEast_ChangesLookingDirectionToEast()
        {
           
            var rover = new Rover { LookingDirection = Direction.North };
            var momentManager = new MomentManager();

           
            momentManager.MoveEast(rover);

           
            Assert.AreEqual(Direction.East, rover.LookingDirection);
        }

        [Test]
        public void MoveWest_RoverLookingWest_DecrementsX()
        {
            
            var rover = new Rover { LookingDirection = Direction.West, X = 1 };
            var momentManager = new MomentManager();

           
            momentManager.MoveWest(rover);

           
            Assert.AreEqual(0, rover.X);
        }

        [Test]
        public void MoveWest_RoverNotLookingWest_ChangesLookingDirectionToWest()
        {
          
            var rover = new Rover { LookingDirection = Direction.South };
            var momentManager = new MomentManager();

           
            momentManager.MoveWest(rover);

           
            Assert.AreEqual(Direction.West, rover.LookingDirection);
        }

        [Test]
        public void Move_InvalidDirection_ThrowsException()
        {
           
            var rover = new Rover();
            var momentManager = new MomentManager();

          
            Assert.Throws<InvalidOperationException>(() => momentManager.Move(rover, (Direction)10));
        }
    }
}
