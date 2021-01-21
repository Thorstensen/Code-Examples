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
                                  )
            };
        }
    }
}