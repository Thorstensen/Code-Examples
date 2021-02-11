using System;
using MassTransit;

namespace MasstransitExample.Autofac.Host.Events
{
    public abstract class CorrelatedEvent : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; set; }
     }
}