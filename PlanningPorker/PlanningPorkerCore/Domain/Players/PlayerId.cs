namespace PlanningPorkerCore.Domain.Players;

[Serializable]
public class PlayerId
{
    public string Value { get; init; }

    public PlayerId(string id) {
        Value = id;
    }
}
