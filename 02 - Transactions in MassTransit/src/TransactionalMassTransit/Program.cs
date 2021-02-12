using Autofac;
using MassTransit;
using MassTransit.Transactions;
using System;
using System.Threading.Tasks;
using System.Transactions;
using TransactionalMassTransit.Contracts;
using TransactionalMassTransit.Domain;
using TransactionalMassTransit.Extensions;
using TransactionalMassTransit.Messages;

namespace TransactionalMassTransit
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.ConfigureMasstransit();
            containerBuilder.RegisterType<MyHorribleDomainService>().As<IHorribleDomainService>();

            var container = containerBuilder.Build();
            
            var busControl = container.Resolve<IBusControl>();
            var busHandle = await busControl.StartAsync();

            var bus = container.Resolve<IBus>();

            try
            {
                var transactionalBus = new TransactionalEnlistmentBus(bus);
                using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

                for(int i = 0; i < 5; i++)
                    await transactionalBus.Publish(new AMessage(Guid.NewGuid().ToString()));

                var domainService = container.Resolve<IHorribleDomainService>();
                domainService.MyMethodThatAlwaysFails();

                transaction.Complete();
            }
            catch (Exception)
            {
                Console.WriteLine("An exception occured. Hopefully no Consumers has printed out anything!");
            }

            Console.WriteLine("Press any key to exit");
            await Task.Run(() => Console.ReadKey());

            await busHandle.StopAsync();
        }
    }
}

