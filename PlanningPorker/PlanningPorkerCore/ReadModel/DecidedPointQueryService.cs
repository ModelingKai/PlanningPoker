using EventStoreClient;

public class DecidedPointQueryService {
    public DecidedPointQueryService() {

    }

    public DecidedPoints Fetch(int id) {
        var client = new MyEventStore();
        var stream = client.ReadAll("decided-point-stream");


        // var decidedPoint = {};

        // stream.Each(x => x) {
        //     switch (x.event) {
        //         decidedPoint....;
        //     }
        // }

        // return decidedPoint;

        return new DecidedPoints();
    }
}

[Serializable]
public struct DecidedPoints {
    private List<DecidedPoint> _list = new List<DecidedPoint>;

    public DecidedPoints()
    {
    }
}

[Serializable]
public struct DecidedPoint {
    string PlayerName { get; set;}

    string Point { get; set; }
}