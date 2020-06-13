using System.Threading.Tasks;
using MassTransit;
using MasstransitExample.Autofac.Host.Events;

namespace MasstransitExample.Autofac.Host
{
    public class SomethingCrazyHappendConsumer : IConsumer<SomethingCrazyHappendEvent>
    {
        private readonly IThreadGreeter _threadGreeter;

        public SomethingCrazyHappendConsumer(IThreadGreeter threadGreeter)
        {
            _threadGreeter = threadGreeter;
        }
        public Task Consume(ConsumeContext<SomethingCrazyHappendEvent> context)
        {
            _threadGreeter.Greet(context.Message.What);
            return Task.CompletedTask;
        }
    }
}