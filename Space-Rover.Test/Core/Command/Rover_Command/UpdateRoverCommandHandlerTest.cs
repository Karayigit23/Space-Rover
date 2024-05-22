using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Space_Rover.Core.Command.Rover;
using Space_Rover.Core.Entity;
using Space_Rover.Core.InterFaces;
using System.Threading;
using System.Threading.Tasks;

namespace Space_Rover.Test.Core.Command.Rover_Command
{
    public class UpdateRoverCommandHandlerTest
    {
        private Mock<IRoverRepository> _roverRepositoryMock;
        private UpdateRoverCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _roverRepositoryMock = new Mock<IRoverRepository>();
            _handler = new UpdateRoverCommandHandler(_roverRepositoryMock.Object, Mock.Of<ILogger<UpdateRoverCommandHandler>>());
        }

        [Test]
        public async Task Handle_WhenRoverExists_UpdatesRover()
        {
            // Arrange
            var request = new UpdateRoverCommand
            {
                ıd = 1,
                RoverName = "New Rover Name",
                PlanetSurfaceId = 2
            };

            var existingRover = new Rover
            {
                RoverId = request.ıd,
                RoverName = "Old Rover Name",
                PlanetSurfaceId = 1
            };

            _roverRepositoryMock.Setup(repo => repo.GetByIdRover(request.ıd)).ReturnsAsync(existingRover);

            
            var updatedRover = await _handler.Handle(request, CancellationToken.None);

           
            Assert.NotNull(updatedRover);
            Assert.AreEqual(request.RoverName, updatedRover.RoverName);
            Assert.AreEqual(request.PlanetSurfaceId, updatedRover.PlanetSurfaceId);

           
            _roverRepositoryMock.Verify(repo => repo.UpdateRover(existingRover), Times.Once);
        }

        [Test]
        public async Task Handle_WhenRoverDoesNotExist_ReturnsNull()
        {
           
            var request = new UpdateRoverCommand
            {
                ıd = 1,
                RoverName = "New Rover Name",
                PlanetSurfaceId = 2
            };

            _roverRepositoryMock.Setup(repo => repo.GetByIdRover(request.ıd)).ReturnsAsync((Rover)null);

           
            var updatedRover = await _handler.Handle(request, CancellationToken.None);

           
            Assert.Null(updatedRover);

           
            _roverRepositoryMock.Verify(repo => repo.UpdateRover(It.IsAny<Rover>()), Times.Never);
        }
    }
}
