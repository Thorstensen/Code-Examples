using System;
using System.Threading.Tasks;
using MassTransit;
using MasstransitExample.Host.Events;
using MasstransitExample.Host.Framework;

namespace MasstransitExample.Host
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var bus = BusFactory.CreateForRabbitMq();
            await bus.StartAsync();

            do
            {
                var value = await Task.Run(() =>
                {
                    Console.WriteLine("Enter a message to publish. Enter 'quit' to quit");
                    return Console.ReadLine();
                });

                if (value.Equals("quit"))
                    break;

                await bus.Publish(new SomethingHappendEvent
                {
                    Content = value
                });
            } 
            while (true);

            await bus.StopAsync();
        }
    }
}