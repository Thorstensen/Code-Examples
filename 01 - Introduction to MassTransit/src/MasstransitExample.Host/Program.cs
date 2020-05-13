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
            
            await bus.Publish(new Message
            {
                Content = "Hello, World"
            });

            await Task.Run(() => Console.ReadKey());
            await bus.StopAsync();
        }
    }
}