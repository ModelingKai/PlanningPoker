namespace PlanningPorkerCore.Domain.Players;

[Serializable]
public class Player
{
    public PlayerId Id { get; init; }

    public Player(PlayerId id) {
        Id = id;
    }
}
