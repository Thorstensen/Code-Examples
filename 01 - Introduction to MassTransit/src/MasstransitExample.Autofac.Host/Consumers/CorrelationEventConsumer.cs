using System;
using System.Threading.Tasks;
using MassTransit;
using MasstransitExample.Autofac.Host.Events;

namespace MasstransitExample.Autofac.Host.Consumers
{
    public class CorrelationEventConsumer : IConsumer<CorrelationEventOne>, IConsumer<CorrelationEventTwo>
    {
        public Task Consume(ConsumeContext<CorrelationEventOne> context)
        {
            Console.WriteLine($"Consumed {context.Message.GetType()}. Conversation Id: {context.ConversationId}");
            context.Publish(new CorrelationEventTwo());
            return Task.CompletedTask;
        }

        public Task Consume(ConsumeContext<CorrelationEventTwo> context)
        {
            Console.WriteLine($"Consumed {context.Message.GetType()}. Conversation Id: {context.ConversationId}");
            return Task.CompletedTask;
        }
    }
}