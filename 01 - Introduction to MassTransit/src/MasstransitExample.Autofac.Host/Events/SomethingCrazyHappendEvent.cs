namespace MasstransitExample.Autofac.Host.Events
{
    public class SomethingCrazyHappendEvent
    {
        public string What { get; set; }
    }

    /// <summary>
    /// Marker interface
    /// </summary>
    public interface IEvent
    {
    }
}