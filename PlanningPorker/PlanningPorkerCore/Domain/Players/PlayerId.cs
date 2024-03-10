namespace PlanningPorkerCore.Domain.Players;

[Serializable]
public record PlayerId
{
    public string Value { get; init; }

    public PlayerId(string id) {
        Value = id;
    }
}
