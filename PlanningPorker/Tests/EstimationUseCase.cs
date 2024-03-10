using Xunit;
using Moq;
using PlanningPorkerCore.Domain.Players;

namespace Tests;

public class EstimationUseCaseTest
{
    [Fact]
    public void ストーリーの見積もりをする()
    {
        // Arrange（準備）
        var mock = new Mock<IEventStore>();

        // Act(実行)
        var useCase = new EstimationUseCase(mock.Object);
        useCase.EstimatedByPlayer(new PlayerId("123"), new PlayerEstimation(3));

        // Assert(検証)
        mock.Verify(x => x.Store(new EstimatedByPlayerEvent(new PlayerId("123"), new PlayerEstimation(3))), Times.AtLeastOnce);
    }
}