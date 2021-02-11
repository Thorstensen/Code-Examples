using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MassTransit;
using MasstransitExample.Autofac.Host.Events;
using MasstransitExample.Autofac.Host.Observers;
using MasstransitExample.Autofac.Host.Util;

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
            busControl.ConnectReceiveObserver(new AnObserver());
            
            Console.WriteLine("Starting bus");
            await busControl.StartAsync();
            Console.WriteLine("Bus has started");

            string command = string.Empty;
            while(!command.Equals("q", StringComparison.InvariantCultureIgnoreCase))
            {
                var availableActions = EventLibrary.GetEventDefintion();
                availableActions.ToList().ForEach(a => Console.WriteLine(a.ToString()));
                    
                Console.WriteLine("Please enter a command:");
                command = Console.ReadLine();
                
                if (command.Equals("q", StringComparison.InvariantCultureIgnoreCase))
                    break;

                var eventDefinition = availableActions.FirstOrDefault(p => p.Id == int.Parse(command));
                await busControl.Publish(eventDefinition.Event);
            }
            
            Console.WriteLine("Goodbye!");
        }
    }
}