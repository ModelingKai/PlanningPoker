namespace DaprClient;

using System.Text.Json.Serialization;
using Dapr.Client;

public class TestClient {

    public async void Execture() {
        // var order = new Order(100);
        using var client = new DaprClientBuilder().Build();

        var test = 100;
        await client.PublishEventAsync("orderpubsub", "eventName", test);

        Console.WriteLine($"published data: {test}");
    }
}

// public record Order([property: JsonPropertyName("orderId")] int orderId);