// using DaprClient;

using EventStoreClient;

// var client = new DaprClient.TestClient();
// client.Execture();

var client = new MyEventStore();
// await client.AddEvent();

await client.SubscribeToStream();



while(true) {
    await Task.Delay(1000);
}