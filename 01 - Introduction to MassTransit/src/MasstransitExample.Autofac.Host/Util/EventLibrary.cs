using System.Collections.Generic;
using MasstransitExample.Autofac.Host.Events;

namespace MasstransitExample.Autofac.Host.Util
{
    public static class EventLibrary
    {
        public static IEnumerable<EventDefinition> GetEventDefintion()
        {
            return new List<EventDefinition>
            {
               new EventDefinition(1, "Publish a regular event",
                                        new SomethingCrazyHappendEvent
                                        {
                                                What = RandomWordGenerator.Generate()
                                        }
                                  ),
                new EventDefinition(2, "Publish a event that correlates",
                                        new CorrelationEventOne()
                                  ),
                new EventDefinition(3, "Publish an event that causes exception",
                                        new ThisThrowsAnExceptionEvent()
                ),
            };
        }
    }
}