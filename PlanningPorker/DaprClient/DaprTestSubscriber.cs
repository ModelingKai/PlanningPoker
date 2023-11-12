namespace DaprClient;

using Dapr;
using Dapr.Client;

public class DaprTestSubscriber {
    public async Task Subcribe() {
        var builder = WebApplication.CreateBuilder(args);

        var app = builder.Build();

        // Dapr configurations
        app.UseCloudEvents();

        app.MapSubscribeHandler();

        // app
        
        app.MapPost("/A", [Topic("orderpubsub", "eventName")] (ILogger<Program> logger, MessageEvent item) => {
            Console.WriteLine($"{item.MessageType}: {item.Message}");
            return Results.Ok();
        });

        app.Run();
    }
}




// using Dapr;



// internal record MessageEvent(string MessageType, string Message);