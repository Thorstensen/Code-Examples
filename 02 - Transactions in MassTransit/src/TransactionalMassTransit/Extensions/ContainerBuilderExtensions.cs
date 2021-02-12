using Autofac;
using GreenPipes;
using MassTransit;
using System;

namespace TransactionalMassTransit.Extensions
{
    public static class Extensions
    {
        public static void ConfigureMasstransit(this ContainerBuilder builder)
        {
            builder.AddMassTransit(configurator =>
            {
                //Add all consumers in the current loaded domain to masstransit.
                //Definition: Every class that implements the IConsumer<,>
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                configurator.AddConsumers(assemblies);

                configurator.AddBus(ctx => {
                    return Bus.Factory.CreateUsingRabbitMq(rabbit =>
                    {
                        rabbit.Host("rabbitmq://localhost");
                        rabbit.ReceiveEndpoint("my-application", endpoint =>
                        {
                            //configure all consumers that Autofac added. 
                            endpoint.ConfigureConsumers(ctx);

                            //Prefetch count = Un-acked messages sent from the broker to MassTransit. 
                            //Concurrency limit = Acts as a semaphore to limit the numbers of concurrent tasks to run of this consumer
                            //For systems that is supposed to process alot of data, these values should be set to a "high value".
                            //There is not recommended values for these two, so you just have to play around with them. 
                            endpoint.PrefetchCount = 16;
                            endpoint.UseConcurrencyLimit(10);
                        });
                    });
                });
            });
        }
    }
}
