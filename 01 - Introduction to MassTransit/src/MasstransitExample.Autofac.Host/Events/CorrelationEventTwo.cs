using System;
using MassTransit;

namespace MasstransitExample.Autofac.Host.Events
{
    public class CorrelationEventTwo : CorrelatedEvent
    {
        public string SomeCoolContent => "Some Cool Content from Event Two";
    }
}