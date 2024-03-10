using System.Runtime.CompilerServices;
using PlanningPorkerCore.Domain.Players;

public class EstimationUseCase
{
    private IEventStore client;

    public EstimationUseCase(IEventStore client)
    {
        this.client = client;
    }

    public void EstimatedByPlayer(PlayerId playerId, PlayerEstimation playerEstimation)
    {
        var event_ = new EstimatedByPlayerEvent(playerId, playerEstimation);
        this.client.Store(event_);
    }
}