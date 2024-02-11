namespace PlanningPorkerCore.Domain.Players;

[Serializable]
public class PlayerId
{
    public int Value { get; init; }

    public PlayerId(int id) {
        Value = id;
    }
}
