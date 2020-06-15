using System;
using System.Threading;

namespace MasstransitExample.Autofac.Host
{
    public class ThreadGreeter : IThreadGreeter
    {
        public void Greet(string context, string message)
        {
            var threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Context: {context}. Message: Greetings from thread: '{threadId}'. Content: '{message}'");
        }
    }

    public interface IThreadGreeter
    {
        void Greet(string context, string message);
    }
}