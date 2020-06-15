using System.Threading.Tasks;
using MassTransit;
using MasstransitExample.Autofac.Host.Events;

namespace MasstransitExample.Autofac.Host.Consumers
{
    public class FaultConsumer : IConsumer<Fault<IEvent>>
    {
        public Task Consume(ConsumeContext<Fault<IEvent>> context)
        {
            //This Consumer will get triggered once a message is moved to the queueName_error queue.
            return Task.CompletedTask;
        }
    }
}