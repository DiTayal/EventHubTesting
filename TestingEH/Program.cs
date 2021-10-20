using DaaSEventListener.Infra.Messages;
using System;
using System.Threading.Tasks;
using TestingEH.src;

namespace TestingEH
{
    class Program
    {
        private static  string connectionString = "";
        private static string eventHubName = "";
        private static string storageconn = "";
        private static string blobname = "";


        static async Task Main()
        {
            Console.WriteLine("Hello");

            Sender sender = new Sender(connectionString, eventHubName);
            var senderThreads = 32;
            while (true)
            {
                Parallel.For(0, senderThreads, async i =>
                {
                    try
                    {
                        await sender.send();
                    }
                    catch (Exception e)
                    {
                        Console.Write("ignoring..............");
                    }
                });

            }


            Consumer consumer = new Consumer(connectionString, eventHubName, storageconn, blobname);
            await consumer.consume();
            Console.WriteLine("Bye");
        }

    }
}
