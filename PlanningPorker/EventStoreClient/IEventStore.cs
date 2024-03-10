
public interface IEventStore {
    void Store<T>(T item);

}