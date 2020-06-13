using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Autofac;
using GreenPipes;
using MassTransit;
using MasstransitExample.Autofac.Host.Events;

namespace MasstransitExample.Autofac.Host
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<ThreadGreeter>().As<IThreadGreeter>();
            
            containerBuilder.ConfigureMasstransit();
            var container = containerBuilder.Build();

            var busControl = container.Resolve<IBusControl>();
            await busControl.StartAsync();
            
            do
            {
                var value = await Task.Run(() =>
                {
                    Console.WriteLine("Enter a message to publish. Enter 'quit' to quit");
                    return Console.ReadLine();
                });

                if (value.Equals("q"))
                    break;

                await busControl.Publish(new SomethingCrazyHappendEvent
                {
                    What = value
                });
                
            } while (true);
        }
    }
}