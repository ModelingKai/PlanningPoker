namespace EventStoreClient;

using System.Net.Http;
using System.Text;
using System.Text.Json;
using EventStore.Client;

public class MyEventStore : IEventStore
{
    [Serializable]
	public class TestEvent {
		public string? EntityId      { get; set; }
		public string? ImportantData { get; set; }

        public void ConsoleWriteTestEvent() {
            Console.WriteLine($"EntityId = {EntityId}, ImportantData = {ImportantData}");
        }
	}

    public async Task SubscribeToStream() {
        var settings = EventStoreClientSettings.Create("esdb://127.0.0.1:2113?tls=false&keepAliveTimeout=10000&keepAliveInterval=10000");
        var client = new EventStoreClient(settings);

        await client.SubscribeToStreamAsync("some-stream",
			FromStream.Start,
			async (subscription, evnt, cancellationToken) => {
			    	// Console.WriteLine($"Received event {evnt.OriginalEventNumber}@{evnt.OriginalStreamId} {evnt.Event.EventType} {Encoding.UTF8.GetString(evnt.Event.Data.ToArray())}");

                    switch(evnt.Event.EventType) {
                        case "TestEvent":
                            await HandleEvent(evnt);
                            break;
                       default:
                    		throw new Exception("仮");		
                    }
				});

//        {
//   "EntityId": "880ee532e46a40508f394a18549b932b",
//   "ImportantData": "I wrote my first event!"
// } 
    }
   	private static Task HandleEvent(ResolvedEvent evnt) {
        var json = Encoding.UTF8.GetString(evnt.Event.Data.ToArray());
        var testEvent = JsonSerializer.Deserialize<TestEvent>(json) ?? throw new Exception("UWAAAAAA");
        testEvent.ConsoleWriteTestEvent();

		return Task.CompletedTask;
	}

    public async Task AddEvent() { 

        var settings = EventStoreClientSettings.Create("esdb://127.0.0.1:2113?tls=false&keepAliveTimeout=10000&keepAliveInterval=10000");
        var client = new EventStoreClient(settings);

        var evt = new TestEvent
        {
            EntityId = Guid.NewGuid().ToString("N"),
            ImportantData = "I wrote my first event!"
        };

        var eventData = new EventData(
            Uuid.NewUuid(),
            "TestEvent",
            JsonSerializer.SerializeToUtf8Bytes(evt)
        );


        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken cancellationToken = source.Token;

        await client.AppendToStreamAsync(
            "some-stream",
            StreamState.Any,
            new[] { eventData },
            cancellationToken: cancellationToken
        );

        var result = client.ReadStreamAsync(
            Direction.Forwards,
            "some-stream",
            StreamPosition.Start,
            cancellationToken: cancellationToken);

        var events = await result.ToListAsync(cancellationToken);
        
        foreach (var @event in events) {
            Console.WriteLine(Encoding.UTF8.GetString(@event.Event.Data.ToArray()));
        }
    }

    public async ValueTask<List<string>> ReadAll(string eventStreamName) {
        var settings = EventStoreClientSettings.Create("esdb://127.0.0.1:2113?tls=false&keepAliveTimeout=10000&keepAliveInterval=10000");
        var client = new EventStoreClient(settings);

        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken cancellationToken = source.Token;
        
        var result = client.ReadStreamAsync(
            Direction.Forwards,
            eventStreamName,
            StreamPosition.Start,
            cancellationToken: cancellationToken);

        var events = result.ToListAsync(cancellationToken);

        var results = new List<string>();

        foreach (var @event in await events) {
            results.Add(Encoding.UTF8.GetString(@event.Event.Data.ToArray()));
        }

        return results;
    }

    public async Task Store<T>(T item)
    {
        var settings = EventStoreClientSettings.Create("esdb://127.0.0.1:2113?tls=false&keepAliveTimeout=10000&keepAliveInterval=10000");
        var client = new EventStoreClient(settings);

        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken cancellationToken = source.Token;

        var eventData = new EventData(
            Uuid.NewUuid(),
            "TestEvent",
            JsonSerializer.SerializeToUtf8Bytes(item)
        );

        await client.AppendToStreamAsync(
            "some-stream",
            StreamState.Any,
            new[] { eventData },
            cancellationToken: cancellationToken
        );
    }
}
