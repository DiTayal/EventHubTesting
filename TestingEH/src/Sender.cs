using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using System;
using System.Threading.Tasks;

public class Sender
{
    public Sender()
    {
    }

    private const string connectionString = "Endpoint=sb://fdass-perf.servicebus.windows.net/;SharedAccessKeyName=ReadWrite;SharedAccessKey=T8SOtgUJOp2rO/G8mYR9VWh5LMA6Zb1u6htOl9CmPKk=";

    private const string eventHubName = "ehperf";
    private byte[] array = new byte[102400]; //100kB=100*1024B


    public async Task send()
    {
        var producerClient = new EventHubProducerClient(connectionString, eventHubName);

        using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();

       
        eventBatch.TryAdd(new EventData(array));
        
        await producerClient.SendAsync(eventBatch);
        Console.WriteLine("A batch  has been published.");

    }
}
