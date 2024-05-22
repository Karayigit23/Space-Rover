using Moq;
using Space_Rover.Core.InterFaces;
using Space_Rover.Core.Query.Planet;
using Microsoft.Extensions.Logging;

namespace Space_Rover.Test.Core.Query.Planet
{
    public class GetByIdPlanetQueryHandlerTest
    {
        private Mock<IPlanetRepository> _planetRepositoryMock;
        private GetByIdPlanetQueryHandler _handler;

        [SetUp]
        public void Setup()
        {
            _planetRepositoryMock = new Mock<IPlanetRepository>();
            _handler = new GetByIdPlanetQueryHandler(_planetRepositoryMock.Object, Mock.Of<ILogger<GetByIdPlanetQueryHandler>>());
        }

        [Test]
        public async Task Handle_ValidId_ReturnsPlanet()
        {
          
            int planetId = 1;
            var expectedPlanet = new Space_Rover.Core.Entity.Planet { PlanetId = planetId };
            _planetRepositoryMock.Setup(repo => repo.GetByIdPlanet(planetId)).ReturnsAsync(expectedPlanet);

       
            var result = await _handler.Handle(new GetByIdPlanetQuery { Id = planetId }, CancellationToken.None);

           
            Assert.AreEqual(expectedPlanet, result);
        }

        [Test]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            
            int invalidPlanetId = 999;
            _planetRepositoryMock.Setup(repo => repo.GetByIdPlanet(invalidPlanetId)).ReturnsAsync((Space_Rover.Core.Entity.Planet)null);

           
            var result = await _handler.Handle(new GetByIdPlanetQuery { Id = invalidPlanetId }, CancellationToken.None);

          
            Assert.IsNull(result);
        }
    }
}