namespace PlanningPorkerCore.Domain.Players;

[Serializable]
public record PlayerEstimation
{
    public int Value { get; init; }

    public PlayerEstimation(int estimation) {
        Value = estimation;
    }
}
