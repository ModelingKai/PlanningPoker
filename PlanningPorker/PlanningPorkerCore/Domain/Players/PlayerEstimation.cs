namespace PlanningPorkerCore.Domain.Players;

[Serializable]
public class PlayerEstimation
{
    public int Value { get; init; }

    public PlayerEstimation(int estimation) {
        Value = estimation;
    }
}
