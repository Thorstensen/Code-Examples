using MasstransitExample.Autofac.Host.Events;

namespace MasstransitExample.Autofac.Host.Util
{
    public class EventDefinition
    {
        public EventDefinition(int id, string displayName, object @event)
        {
            Id = id;
            DisplayName = displayName;
            Event = @event;
        }

        public int Id { get; private set; }
        public string DisplayName { get; private set; }
        public object Event { get; private set; }

        public override string ToString()
        {
            return $"{Id} - {DisplayName}";
        }
    }
}