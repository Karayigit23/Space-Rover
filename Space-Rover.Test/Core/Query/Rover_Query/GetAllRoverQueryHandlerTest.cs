using Moq;
using Space_Rover.Core.Query.Rover;
using Space_Rover.Core.InterFaces;
using Microsoft.Extensions.Logging;

namespace Space_Rover.Test.Core.Query.Rover
{
    public class GetAllRoverQueryHandlerTest
    {
        private Mock<IRoverRepository> _roverRepository;
        private GetAllRoverQuery.GetAllRoverQueryHandler _handler;

        [SetUp]
        public void Setup()
        {
            _roverRepository = new Mock<IRoverRepository>();
            _handler = new GetAllRoverQuery.GetAllRoverQueryHandler(_roverRepository.Object, Mock.Of<ILogger<GetAllRoverQuery.GetAllRoverQueryHandler>>());
        }

        [Test]
        public async Task Handle_ReturnsAllRovers()
        {
           
            var expectedRovers = new List<Space_Rover.Core.Entity.Rover>
            {
                new Space_Rover.Core.Entity.Rover { RoverId = 1, RoverName = "Rover 1" },
                new Space_Rover.Core.Entity.Rover { RoverId = 2, RoverName = "Rover 2" },
                new Space_Rover.Core.Entity.Rover { RoverId = 3, RoverName = "Rover 3" }
            };
            _roverRepository.Setup(p => p.GetAllRover()).ReturnsAsync(expectedRovers);

           
            var result = await _handler.Handle(new GetAllRoverQuery(), CancellationToken.None);

            
            Assert.AreEqual(expectedRovers.Count, result.Count);
            for (int i = 0; i < expectedRovers.Count; i++)
            {
                Assert.AreEqual(expectedRovers[i].RoverId, result[i].RoverId);
                Assert.AreEqual(expectedRovers[i].RoverName, result[i].RoverName);
               
            }
        }
    }
}