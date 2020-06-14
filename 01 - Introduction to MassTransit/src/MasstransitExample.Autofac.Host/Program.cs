using System;
using System.Threading.Tasks;
using Autofac;
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
            
            Console.WriteLine("Starting bus");
            await busControl.StartAsync();
            Console.WriteLine("Bus has started");

            for (var i = 0; i < 100; i++)
            {
                var msg = new SomethingCrazyHappendEvent
                {
                    What = RandomWordGenerator.Generate()
                };
                
                await busControl.Publish(msg);
            }
        }
    }
}