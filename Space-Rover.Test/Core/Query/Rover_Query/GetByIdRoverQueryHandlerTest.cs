using Moq;
using Space_Rover.Core.InterFaces;
using Space_Rover.Core.Query.Rover;
using Microsoft.Extensions.Logging;

namespace Space_Rover.Test.Core.Query.Rover
{
    public class GetByIdRoverHandlerTest
    {
        private Mock<IRoverRepository> _roverRepositoryMock;
        private GetByIdRoverHandler _handler;

        [SetUp]
        public void Setup()
        {
            _roverRepositoryMock = new Mock<IRoverRepository>();
            _handler = new GetByIdRoverHandler(_roverRepositoryMock.Object, Mock.Of<ILogger<GetByIdRoverHandler>>());
        }

        [Test]
        public async Task Handle_ValidId_ReturnsRover()
        {
            
            int roverId = 1;
            var expectedRover = new Space_Rover.Core.Entity.Rover { RoverId = roverId };
            
            _roverRepositoryMock.Setup(repo => repo.GetByIdRover(roverId)).ReturnsAsync(expectedRover);
            
            var result = await _handler.Handle(new GetByIdRover { Id = roverId }, CancellationToken.None);

            
            Assert.AreEqual(expectedRover, result);
        }

        [Test]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            int invalidRoverId = 999;
            _roverRepositoryMock.Setup(repo => repo.GetByIdRover(invalidRoverId)).ReturnsAsync((Space_Rover.Core.Entity.Rover)null);

            
            var result = await _handler.Handle(new GetByIdRover { Id = invalidRoverId }, CancellationToken.None);

            
            Assert.IsNull(result);
        }
    }
}