// using DaprClient;

using EventStoreClient;
using PlanningPorkerCore.Domain.Players;

// var client = new DaprClient.TestClient();
// client.Execture();

var client = new MyEventStore();
// await client.AddEvent();

// await client.SubscribeToStream();

var useCase = new EstimationUseCase(client);
useCase.EstimatedByPlayer(new PlayerId("123"), new PlayerEstimation(3));



while(true) {
    await Task.Delay(1000);
}