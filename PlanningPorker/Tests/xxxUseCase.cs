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
        
        // Assert.True(mock.Store<EstimatedByPlayerEvent>(new EstimatedByPlayerEvent(new PlayerId("123"), new PlayerEstimation(3))));

        // Domainのクラスのメソッドが動いたことが検証されて欲しい？
    }
}

internal class EstimatationUseCase
{
    private IEventStore mock;

    internal EstimatationUseCase(IEventStore mock)
    {
        this.mock = mock;
    }

    internal void EstimatedByPlayer(PlayerId playerId, PlayerEstimation playerEstimation)
    {
        throw new NotImplementedException();
    }
}