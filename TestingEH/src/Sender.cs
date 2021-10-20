using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using System;
using System.Threading.Tasks;

public class Sender
{
    private string connectionString;
    private string eventHubName;


    public Sender(string connectionString,string eventHubName)
    {
        this.connectionString = connectionString;
        this.eventHubName = eventHubName;
    }

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
