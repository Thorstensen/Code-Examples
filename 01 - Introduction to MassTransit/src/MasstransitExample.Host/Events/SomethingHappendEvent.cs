namespace MasstransitExample.Host.Events
{
    public class SomethingHappendEvent : IEvent
    {
        public string Content { get; set; }
    }
}