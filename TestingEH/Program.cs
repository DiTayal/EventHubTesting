using DaaSEventListener.Infra.Messages;
using System;
using System.Threading.Tasks;
using TestingEH.src;

namespace TestingEH
{
    class Program
    {

        static async Task Main()
        {
            Console.WriteLine("Hello");

            Sender sender = new Sender();
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


            Consumer consumer = new Consumer();
            await consumer.consume();
            Console.WriteLine("Bye");
        }

    }
}
