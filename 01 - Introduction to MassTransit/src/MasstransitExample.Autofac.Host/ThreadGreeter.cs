using System;
using System.Threading;

namespace MasstransitExample.Autofac.Host
{
    public class ThreadGreeter : IThreadGreeter
    {
        public void Greet(string message)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Greeting from thread '{threadId}'. Message '{message}'");
        }
    }

    public interface IThreadGreeter
    {
        void Greet(string message);
    }
}