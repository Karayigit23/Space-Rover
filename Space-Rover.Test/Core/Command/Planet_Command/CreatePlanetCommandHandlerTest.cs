using Microsoft.Extensions.Logging;
using Moq;
using Space_Rover.Core.Command.Planet;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Test.Core.Command.Planet
{
    public class CreatePlanetCommandHandlerTest
    {
        private Mock<IPlanetRepository> _planetRepositoryMock;
        private Mock<ILogger<CreatePlanetCommandHandler>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _planetRepositoryMock = new Mock<IPlanetRepository>();
            _loggerMock = new Mock<ILogger<CreatePlanetCommandHandler>>();
        }

        [Test]
        public async Task Handle_WhenCalled_CreatesPlanet()
        {
            // Arrange
            var command = new CreatePlanetCommand { Width = 10, Height = 20 };
            var handler = new CreatePlanetCommandHandler(_planetRepositoryMock.Object, _loggerMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            _planetRepositoryMock.Verify(repo => repo.AddPlanet(It.IsAny<Space_Rover.Core.Entity.Planet>()), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual(command.Width, result.Width);
            Assert.AreEqual(command.Height, result.Height);
        }
    }
}