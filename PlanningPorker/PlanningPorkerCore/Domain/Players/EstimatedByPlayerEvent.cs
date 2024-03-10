namespace PlanningPorkerCore.Domain.Players;

[Serializable]
public record EstimatedByPlayerEvent {

    public PlayerId Id { get; init; }

    public PlayerEstimation Estimation { get; init; }


    public EstimatedByPlayerEvent(PlayerId id, PlayerEstimation estimation) {
        Id = id;
        Estimation = estimation;
    }
}
