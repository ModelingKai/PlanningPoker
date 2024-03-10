
public interface IEventStore {
    Task Store<T>(T item);
}