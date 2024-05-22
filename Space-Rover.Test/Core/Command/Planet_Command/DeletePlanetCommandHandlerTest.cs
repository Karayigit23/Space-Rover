using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Space_Rover.Core.Command.Planet;
using Space_Rover.Core.InterFaces;


namespace Space_Rover.Test.Core.Command.Planet_Command
{
    public class DeletePlanetCommandHandlerTest
    {
        private Mock<IPlanetRepository> _planetRepository;
        private DeletePlanetCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _planetRepository = new Mock<IPlanetRepository>();
            _handler = new DeletePlanetCommandHandler(_planetRepository.Object, Mock.Of<ILogger<DeletePlanetCommandHandler>>());
        }

        [Test]
        public async Task Handle_ValidRequest_DeletesPlanet()
        {
            // Given
            int planetIdToDelete = 1;
            var planet = new Space_Rover.Core.Entity.Planet { PlanetId = planetIdToDelete };
            _planetRepository.Setup(p => p.GetByIdPlanet(planetIdToDelete)).ReturnsAsync(planet);

            // When
            var result = await _handler.Handle(new DeletePlanetCommand { Id = planetIdToDelete }, CancellationToken.None);

            // Then
            _planetRepository.Verify(p => p.GetByIdPlanet(planetIdToDelete), Times.Once);
            _planetRepository.Verify(p => p.DeletePlanet(planet), Times.Once);
            Assert.AreEqual(Unit.Value, result);
        }

        [Test]
        public async Task Handle_InvalidPlanetId_NoActionTaken()
        {
            // Given
            int invalidPlanetId = 999;
            _planetRepository.Setup(p => p.GetByIdPlanet(invalidPlanetId)).ReturnsAsync((Space_Rover.Core.Entity.Planet)null);

            // When
            var result = await _handler.Handle(new DeletePlanetCommand { Id = invalidPlanetId }, CancellationToken.None);

            // Then
            _planetRepository.Verify(p => p.GetByIdPlanet(invalidPlanetId), Times.Once);
            _planetRepository.Verify(p => p.DeletePlanet(It.IsAny<Space_Rover.Core.Entity.Planet>()), Times.Never);
            Assert.AreEqual(Unit.Value, result);
        }
    }
}
