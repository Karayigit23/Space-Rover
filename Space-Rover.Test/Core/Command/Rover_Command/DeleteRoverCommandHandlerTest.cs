using Space_Rover.Core.Entity;
using Space_Rover.Core.Command.Rover;
using Microsoft.Extensions.Logging;
using Moq;
using MediatR;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Test.Core.Command.Rover_Command
{
    public class DeleteRoverCommandHandlerTest
    {
        private Mock<IRoverRepository> _roverRepository;
        private DeleteRoverCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _roverRepository = new Mock<IRoverRepository>();
            _handler = new DeleteRoverCommandHandler(_roverRepository.Object, Mock.Of<ILogger<DeleteRoverCommandHandler>>());
        }

        [Test]
        public async Task Handle_ValidRequest_DeletesRover()
        {
            // Given
            int roverIdToDelete = 1;
            var rover = new Rover { RoverId = roverIdToDelete };
            _roverRepository.Setup(p => p.GetByIdRover(roverIdToDelete)).ReturnsAsync(rover);

            // When
            var result = await _handler.Handle(new DeleteRoverCommand { Id = roverIdToDelete }, CancellationToken.None);

            // Then
            _roverRepository.Verify(p => p.GetByIdRover(roverIdToDelete), Times.Once);
            _roverRepository.Verify(p => p.DeleteRover(rover), Times.Once);
            Assert.AreEqual(Unit.Value, result);
        }

        [Test]
        public async Task Handle_InvalidRoverId_NoActionTaken()
        {
            // Given
            int invalidRoverId = 999;
            _roverRepository.Setup(p => p.GetByIdRover(invalidRoverId)).ReturnsAsync((Rover)null);

            // When
            var result = await _handler.Handle(new DeleteRoverCommand { Id = invalidRoverId }, CancellationToken.None);

            // Then
            _roverRepository.Verify(p => p.GetByIdRover(invalidRoverId), Times.Once);
            _roverRepository.Verify(p => p.DeleteRover(It.IsAny<Rover>()), Times.Never);
            Assert.AreEqual(Unit.Value, result);
        }
    }
}
