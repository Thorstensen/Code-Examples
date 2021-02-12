using MassTransit;
using System;
using System.Threading.Tasks;
using TransactionalMassTransit.Messages;

namespace TransactionalMassTransit.Consumers
{
    public class AMessageConsumer : IConsumer<AMessage>
    {
        public Task Consume(ConsumeContext<AMessage> context)
        {
            Console.WriteLine($"{nameof(AMessageConsumer)} consumed a message: {context.Message.Content}");
            return Task.CompletedTask;
        }
    }
}
