using Xunit;
using Moq;
using PlanningPorkerCore.Domain.Players;

namespace Tests;

public class xxxUseCaseTest
{

    [Fact]
    public void ストーリーの見積もりをする()
    {
        // Arrange（準備）
        var mock = new Mock<IEventStore>();

        // Act(実行)
        var useCase = new EstimatationUseCase(mock.Object);
        useCase.EstimatedByPlayer(new PlayerId("123"), new PlayerEstimation(3));

        // Assert(検証)
        mock.Verify(x => x.Store(new EstimatedByPlayerEvent(new PlayerId("123"), new PlayerEstimation(3))), Times.AtLeastOnce);
        
    }
}

internal class EstimatationUseCase
{
    private IEventStore client;

    internal EstimatationUseCase(IEventStore client)
    {
        this.client = client;
    }

    internal void EstimatedByPlayer(PlayerId playerId, PlayerEstimation playerEstimation)
    {
        var event_ = new EstimatedByPlayerEvent(playerId, playerEstimation);
        this.client.Store(event_);
    }
}