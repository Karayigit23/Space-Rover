using Moq;
using NUnit.Framework;
using Space_Rover.Core.Command.Planet;
using Space_Rover.Core.Entity;
using Space_Rover.Core.InterFaces;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Space_Rover.Core.Command.Rover;

namespace Space_Rover.Test.Core.Command.Planet
{
    public class UpdatePlanetCommandHandlerTest
    {
        private Mock<IPlanetRepository> _planetRepository;
        private UpdatePlanetCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _planetRepository = new Mock<IPlanetRepository>();
            _handler = new UpdatePlanetCommandHandler(_planetRepository.Object,Mock.Of<ILogger<UpdatePlanetCommandHandler>>());
        }

        [Test]
        public async Task Handle_UpdatesPlanet()
        {
            // Given
            int planetId = 1;
            var command = new UpdatePlanetCommand
            {
                Id = planetId,
                Width = 100,
                Height = 100
            };
            var planet = new Space_Rover.Core.Entity.Planet { PlanetId = planetId, Width = 50, Height = 50 };
            _planetRepository.Setup(p => p.GetByIdPlanet(planetId)).ReturnsAsync(planet);

            // When
            var result = await _handler.Handle(command, CancellationToken.None);

            // Then
            _planetRepository.Verify(p => p.GetByIdPlanet(planetId), Times.Once);
            _planetRepository.Verify(p => p.UpdatePlanet(planet), Times.Once);
            Assert.AreEqual(command.Width, result.Width);
            Assert.AreEqual(command.Height, result.Height);
        }

        [Test]
        public async Task Handle_InvalidPlanetId_ReturnsNull()
        {
            // Given
            int invalidPlanetId = 999;
            var command = new UpdatePlanetCommand
            {
                Id = invalidPlanetId,
                Width = 100,
                Height = 100
            };
            _planetRepository.Setup(p => p.GetByIdPlanet(invalidPlanetId)).ReturnsAsync((Space_Rover.Core.Entity.Planet)null);

            // When
            var result = await _handler.Handle(command, CancellationToken.None);

            // Then
            _planetRepository.Verify(p => p.GetByIdPlanet(invalidPlanetId), Times.Once);
            _planetRepository.Verify(p => p.UpdatePlanet(It.IsAny<Space_Rover.Core.Entity.Planet>()), Times.Never);
            Assert.IsNull(result);
        }
    }
}
