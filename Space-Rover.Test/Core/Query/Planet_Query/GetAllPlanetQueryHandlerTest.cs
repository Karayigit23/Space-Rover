using Microsoft.Extensions.Logging;
using Moq;
using Space_Rover.Core.InterFaces;
using Space_Rover.Core.Query.Planet;

namespace Space_Rover.Test.Core.Query.Planet
{
    public class GetAllPlanetQueryHandlerTest
    {
        private Mock<IPlanetRepository> _planetRepositoryMock;
        private Mock<ILogger<GetAllPlanetQuery.GetAllPlanetQueryHandler>> _loggerMock;
        private GetAllPlanetQuery.GetAllPlanetQueryHandler _handler;

        [SetUp]
        public void Setup()
        {
            _planetRepositoryMock = new Mock<IPlanetRepository>();
            _loggerMock = new Mock<ILogger<GetAllPlanetQuery.GetAllPlanetQueryHandler>>();
            _handler = new GetAllPlanetQuery.GetAllPlanetQueryHandler(_planetRepositoryMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task Handle_ReturnsAllPlanets()
        {
            
            var expectedPlanets = new List<Space_Rover.Core.Entity.Planet>
            {
                new Space_Rover.Core.Entity.Planet { PlanetId = 1,  },
                new Space_Rover.Core.Entity.Planet { PlanetId = 2,  },
                new Space_Rover.Core.Entity.Planet { PlanetId = 3,  }
            };

            _planetRepositoryMock.Setup(repo => repo.GetAllPlanet()).ReturnsAsync(expectedPlanets);

        
            var result = await _handler.Handle(new GetAllPlanetQuery(), CancellationToken.None);

       
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedPlanets.Count, result.Count);
            for (int i = 0; i < expectedPlanets.Count; i++)
            {
                Assert.AreEqual(expectedPlanets[i].PlanetId, result[i].PlanetId);
               
            }
        }

    }
}