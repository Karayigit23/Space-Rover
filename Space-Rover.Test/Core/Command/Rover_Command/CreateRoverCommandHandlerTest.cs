using Microsoft.Extensions.Logging;
using Moq;
using Space_Rover.Core.Command.Rover;
using Space_Rover.Core.Entity;
using Space_Rover.Core.InterFaces;

namespace Space_Rover.Test.Core.Command.Rover_Command;

public class CreateRoverCommandHandlerTest
{
    private Mock<IRoverRepository> _roverRepository;
    private Mock<ILogger<CreateRoverHandler>> _logger;
    private CreateRoverHandler _handler;

    [SetUp]
    public void Setup()
    {
        _roverRepository = new Mock<IRoverRepository>();
        _logger = new Mock<ILogger<CreateRoverHandler>>();
        _handler = new CreateRoverHandler(_roverRepository.Object, _logger.Object);
    }

    [Test]
    public async Task Handle_ValidRequest_CreatesRover()
    {
        // Given
        var command = new CreateRoverCommand
        {
            RoverName = "Opportunity",
            PlanetSurfaceId = 1
        };

        // When
        await _handler.Handle(command, CancellationToken.None);

        // Then
        _roverRepository.Verify(p => p.AddRover(It.IsAny<Rover>()), Times.Once);
        _logger.Verify(l => l.LogInformation("Rover created: {RoverName}", command.RoverName), Times.Once);
    }
}



