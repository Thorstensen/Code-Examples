using System;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MasstransitExample.Autofac.Host.Events;

namespace MasstransitExample.Autofac.Host.Consumers
{
    //This Consumer will get triggered once a message is moved to the queueName_error queue.
    public class FaultConsumer : IConsumer<Fault<IEvent>>
    {
        public Task Consume(ConsumeContext<Fault<IEvent>> context)
        {
            Console.WriteLine("Consuming a faulted message");
            context.Message.Exceptions.ToList().ForEach(exception => Console.WriteLine(exception.StackTrace));

            return Task.CompletedTask;
        }
    }
}