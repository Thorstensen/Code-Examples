using System;
using System.Threading.Tasks;
using MassTransit;
using MasstransitExample.Autofac.Host.Events;

namespace MasstransitExample.Autofac.Host.Consumers
{
    public class ThisThrowsAnExceptionConsumer : IConsumer<ThisThrowsAnExceptionEvent>
    {
        public Task Consume(ConsumeContext<ThisThrowsAnExceptionEvent> context)
        {
            throw new System.Exception();
        }
    }
}